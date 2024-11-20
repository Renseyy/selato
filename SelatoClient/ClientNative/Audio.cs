using OpenTK.Mathematics;

namespace SelatoClient.ClientNative;
using OpenTK.Audio.OpenAL;
public class Audio
{
    public static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
    {
        ArgumentNullException.ThrowIfNull(stream);

        using var reader = new BinaryReader(stream);
        // RIFF header
        var signature = new string(reader.ReadChars(4));
        if (signature != "RIFF")
            throw new NotSupportedException("Specified stream is not a wave file.");

        reader.ReadInt32(); // riffChunkSize

        var format = new string(reader.ReadChars(4));
        if (format != "WAVE")
            throw new NotSupportedException("Specified stream is not a wave file.");

        // WAVE header
        var formatSignature = new string(reader.ReadChars(4));
        if (formatSignature != "fmt ")
            throw new NotSupportedException("Specified wave file is not supported.");

        reader.ReadInt32(); // formatChunkSize 
        reader.ReadInt16(); // audioFormat 
        var channelsCount = reader.ReadInt16();
        var sampleRate = reader.ReadInt32();
        reader.ReadInt32(); // byteRate
        reader.ReadInt16(); // blockAlign
        var bitsPerSample = reader.ReadInt16();

        var dataSignature = new string(reader.ReadChars(4));
        if (dataSignature != "data")
            throw new NotSupportedException("Specified wave file is not supported.");

        reader.ReadInt32(); // dataChunkSize

        channels = channelsCount;
        bits = bitsPerSample;
        rate = sampleRate;

        return reader.ReadBytes((int)reader.BaseStream.Length);
    }
    
    public static ALFormat GetSoundFormat(int channels, int bits)
    {
        return channels switch
        {
            1 => bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16,
            2 => bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16,
            _ => throw new NotSupportedException("The specified sound format is not supported.")
        };
    }
    
    public class AudioTask : AudioCi
	{
		public AudioTask(GameExit gameexit, AudioDataCs sample, AudioOpenAl audio)
		{
			this.gameexit = gameexit;
			this.sample = sample;
			this.audio = audio;
		}
		AudioOpenAl audio;
		GameExit gameexit;
		AudioDataCs sample;
		public Vector3 position;
		public void Play()
		{
			if (started)
			{
				shouldplay = true;
				return;
			}
			started = true;
			ThreadPool.QueueUserWorkItem(delegate
			{
				play();
			});
		}
		//bool resume = true;
		bool started = false;
		void play()
		{
			try
			{
				DoPlay();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	    
		private void DoPlay()
		{
			int source = OpenTK.Audio.OpenAL.AL.GenSource();
			int state;
			//using ()
			{
				//Trace.WriteLine("Testing WaveReader({0}).ReadToEnd()", filename);

				int buffer = OpenTK.Audio.OpenAL.AL.GenBuffer();

				OpenTK.Audio.OpenAL.AL.BufferData(buffer, GetSoundFormat(sample.Channels, sample.BitsPerSample), sample.Pcm, sample.Pcm.Length, sample.Rate);
				//audiofiles[filename]=buffer;

				OpenTK.Audio.OpenAL.AL.DistanceModel(OpenTK.Audio.OpenAL.ALDistanceModel.InverseDistance);
				OpenTK.Audio.OpenAL.AL.Source(source, OpenTK.Audio.OpenAL.ALSourcef.RolloffFactor, 0.3f);
				OpenTK.Audio.OpenAL.AL.Source(source, OpenTK.Audio.OpenAL.ALSourcef.ReferenceDistance, 1);
				OpenTK.Audio.OpenAL.AL.Source(source, OpenTK.Audio.OpenAL.ALSourcef.MaxDistance, (int)(64 * 1));
				OpenTK.Audio.OpenAL.AL.Source(source, OpenTK.Audio.OpenAL.ALSourcei.Buffer, buffer);
				OpenTK.Audio.OpenAL.AL.SourcePlay(source);

				// Query the source to find out when it stops playing.
				for (; ;)
				{
					OpenTK.Audio.OpenAL.AL.GetSource(source, OpenTK.Audio.OpenAL.ALGetSourcei.SourceState, out state);
					if ((!loop) && (OpenTK.Audio.OpenAL.ALSourceState)state != OpenTK.Audio.OpenAL.ALSourceState.Playing)
					{
						break;
					}
					if (stop)
					{
						break;
					}
					if (gameexit.GetExit())
					{
						break;
					}
					if (loop)
					{
						if (state == (int)OpenTK.Audio.OpenAL.ALSourceState.Playing && (!shouldplay))
						{
							OpenTK.Audio.OpenAL.AL.SourcePause(source);
						}
						if (state != (int)OpenTK.Audio.OpenAL.ALSourceState.Playing && (shouldplay))
						{
							if (restart)
							{
								OpenTK.Audio.OpenAL.AL.SourceRewind(source);
								restart = false;
							}
							OpenTK.Audio.OpenAL.AL.SourcePlay(source);
						}
					}
	                
					OpenTK.Audio.OpenAL.AL.Source(source, OpenTK.Audio.OpenAL.ALSource3f.Position, position.X, position.Y, position.Z);
	 
					/*
	                if (stop)
	                {
	                    AL.SourcePause(source);
	                    resume = false;
	                }
	                if (resume)
	                {
	                    AL.SourcePlay(source);
	                    resume = false;
	                }
	                */
					Thread.Sleep(1);
				}
				Finished = true;
				OpenTK.Audio.OpenAL.AL.SourceStop(source);
				OpenTK.Audio.OpenAL.AL.DeleteSource(source);
				OpenTK.Audio.OpenAL.AL.DeleteBuffer(buffer);
			}
		}
		public bool loop = false;
		bool stop;
		public void Stop()
		{
			stop = true;
		}
		public bool shouldplay;
		public bool restart;
		public void Restart()
		{
			restart = true;
		}

		internal void Pause()
		{
			shouldplay = false;
		}


		internal bool Finished;
	}
}