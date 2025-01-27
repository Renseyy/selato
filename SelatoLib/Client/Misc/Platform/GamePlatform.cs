using SelatoLib.Client.Misc.Game;
using SelatoLib.Client.Misc.MainMenu;
using SelatoLib.Client.Misc.Platform.Handler;
using SelatoLib.Common.NetworkDummy;

namespace SelatoLib.Client.Misc.Platform;

public abstract class GamePlatform
{
    // Primitive
    public abstract int FloatToInt(float value);
    public abstract float MathSin(float a);
    public abstract float MathCos(float a);
    public abstract float MathSqrt(float value);
    public abstract float MathAcos(float p);
    public abstract float MathTan(float p);
    public abstract float FloatModulo(float a, int b);

    public abstract bool IntTryParse(string value, out int result);
    public abstract float FloatParse(string value);
    public abstract string IntToString(int value);
    public abstract string FloatToString(float value);
    public abstract bool FloatTryParse(string value, out float ret);
    public abstract string StringFormat(string format, string arg0);
    public abstract string StringFormat2(string format, string arg0, string arg1);
    public abstract string StringFormat3(string format, string arg0, string arg1, string arg2);
    public abstract string StringFormat4(string format, string arg0, string arg1, string arg2, string arg3);
    public abstract int[] StringToCharArray(string s, ref int length);
    public abstract string CharArrayToString(int[] charArray, int length);
    public abstract bool StringEmpty(string data);
    public abstract bool StringContains(string a, string b);
    public abstract string StringReplace(string s, string from, string to);
    public abstract bool StringStartsWithIgnoreCase(string a, string b);
    public abstract int StringIndexOf(string s, string p);
    public abstract string StringTrim(string value);
    public abstract string StringToLower(string p);
    public abstract string StringFromUtf8ByteArray(byte[] value, int valueLength);
    public abstract byte[] StringToUtf8ByteArray(string s, ref int retLength);
    public abstract string[] StringSplit(string value, string separator, ref int returnLength);
    public abstract string StringJoin(string[] value, string separator);

    // Misc
    public abstract string Timestamp();
    public abstract void ClipboardSetText(string s);
    public abstract void TextSize(string text, Font font, ref int outWidth, ref int outHeight);
    public abstract void Exit();
    public abstract bool ExitAvailable();
    public abstract string PathSavegames();
    public abstract string PathCombine(string part1, string part2);
    public abstract string[] DirectoryGetFiles(string path, ref int length);
    public abstract string[] FileReadAllLines(string path, ref int length);
    public abstract void WebClientDownloadDataAsync(string url, HttpResponse response);
    public abstract void ThumbnailDownloadAsync(string ip, int port, ThumbnailResponse response);
    public abstract string FileName(string fullpath);
    public abstract void AddOnNewFrame(NewFrameHandler handler);
    public abstract void AddOnKeyEvent(KeyEventHandler handler);
    public abstract void AddOnMouseEvent(MouseEventHandler handler);
    public abstract void AddOnTouchEvent(TouchEventHandler handler);
    public abstract int GetCanvasWidth();
    public abstract int GetCanvasHeight();
    public abstract string GetLanguageIso6391();
    public abstract int TimeMillisecondsFromStart();
    public abstract void ThrowException(string message);
    public abstract Bitmap BitmapCreate(int width, int height);
    public abstract void BitmapSetPixelsArgb(Bitmap bmp, int[] pixels);
    public abstract Bitmap CreateTextTexture(Text t);
    public abstract void SetTextRendererFont(int fontId);
    public abstract float BitmapGetWidth(Bitmap bmp);
    public abstract float BitmapGetHeight(Bitmap bmp);
    public abstract void BitmapDelete(Bitmap bmp);
    public abstract void ConsoleWriteLine(string p);
    public abstract MonitorObject MonitorCreate();
    public abstract void MonitorEnter(MonitorObject monitorObject);
    public abstract void MonitorExit(MonitorObject monitorObject);
    public abstract void SaveScreenshot();
    public abstract Bitmap GrabScreenshot();
    public abstract AviWriter AviWriterCreate();
    public abstract Uri ParseUri(string uri);
    public abstract Random RandomCreate();
    public abstract string PathStorage();
    public abstract void SetVSync(bool enabled);
    public abstract string GetGameVersion();
    public abstract void GzipDecompress(byte[] compressed, int compressedLength, byte[] ret);
    public abstract bool ChatLog(string servername, string p);
    public abstract bool IsValidTypingChar(int c);
    public abstract void WindowExit();
    public abstract void MessageBoxShowError(string text, string caption);
    public abstract int ByteArrayLength(byte[] arr);
    public abstract Bitmap BitmapCreateFromPng(byte[] data, int dataLength);
    public abstract void BitmapGetPixelsArgb(Bitmap bitmap, int[] bmpPixels);
    public abstract string[] ReadAllLines(string p, ref int retCount);
    public abstract bool ClipboardContainsText();
    public abstract string ClipboardGetText();
    public abstract void SetTitle(string applicationname);
    public abstract bool Focused();
    public abstract void AddOnCrash(OnCrashHandler handler);
    public abstract string KeyName(int key);
    public abstract DisplayResolution[] GetDisplayResolutions(ref int resolutionsCount);
    public abstract WindowState GetWindowState();
    public abstract void SetWindowState(WindowState value);
    public abstract void ChangeResolution(int width, int height, int bitsPerPixel, float refreshRate);
    public abstract DisplayResolution GetDisplayResolutionDefault();
    public abstract void WebClientUploadDataAsync(string url, byte[] data, int dataLength, HttpResponse response);
    public abstract string FileOpenDialog(string extension, string extensionName, string initialDirectory);
    public abstract void MouseCursorSetVisible(bool value);
    public abstract bool MouseCursorIsVisible();
    public abstract void ApplicationDoEvents();
    public abstract void ThreadSpinWait(int iterations);
    public abstract void ShowKeyboard(bool show);
    public abstract bool IsFastSystem();
    public abstract Preferences GetPreferences();
    public abstract void SetPreferences(Preferences preferences);
    public abstract bool IsMousePointerLocked();
    public abstract void RequestMousePointerLock();
    public abstract void ExitMousePointerLock();
    public abstract bool MultithreadingAvailable();
    public abstract void QueueUserWorkItem(Action action);
    public abstract void LoadAssetsAsyc(List<Asset> list, ref float progress);
    public abstract byte[] GzipCompress(byte[] data, int dataLength, ref int retLength);
    public abstract bool IsDebuggerAttached();
    public abstract bool IsSmallScreen();
    public abstract void OpenLinkInBrowser(string url);
    public abstract void SaveAssetToCache(Asset tosave);
    public abstract Asset LoadAssetFromCache(string md5);
    public abstract bool IsCached(string md5);
    public abstract bool IsChecksum(string checksum);
    public abstract string DecodeHtmlEntities(string htmlencodedstring);
    public abstract string QueryStringValue(string key);
    public abstract void SetWindowCursor(int hotx, int hoty, int sizex, int sizey, byte[] imgdata, int imgdataLength);
    public abstract void RestoreWindowCursor();

    // Audio
    public abstract AudioData AudioDataCreate(byte[] data, int dataLength);
    public abstract bool AudioDataLoaded(AudioData data);
    public abstract Audio AudioCreate(AudioData data);
    public abstract void AudioPlay(Audio audio);
    public abstract void AudioPause(Audio audio);
    public abstract void AudioDelete(Audio audioCi);
    public abstract bool AudioFinished(Audio audio);
    public abstract void AudioSetPosition(Audio audio, float x, float y, float z);
    public abstract void AudioUpdateListener(float posX, float posY, float posZ, float orientX, float orientY, float orientZ);
    
    // Tcp
    public abstract bool TcpAvailable();
    public abstract void TcpConnect(string ip, int port, ref bool isConnected);
    public abstract void TcpSend(byte[] data, int length);
    public abstract int TcpReceive(byte[] data, int dataLength);

    // Enet
    public abstract bool EnetAvailable();
    public abstract EnetHost EnetCreateHost();
    public abstract bool EnetHostService(EnetHost host, int timeout, EnetEventRef enetEvent);
    public abstract bool EnetHostCheckEvents(EnetHost host, EnetEventRef event_);
    public abstract EnetPeer EnetHostConnect(EnetHost host, string hostName, int port, int data, int channelLimit);
    public abstract void EnetPeerSend(EnetPeer peer, byte channelID, byte[] data, int dataLength, int flags);
    public abstract void EnetHostInitialize(EnetHost host, IPEndPointCi address, int peerLimit, int channelLimit, int incomingBandwidth, int outgoingBandwidth);

    // WebSocket
    public abstract bool WebSocketAvailable();
    public abstract void WebSocketConnect(string ip, int port);
    public abstract void WebSocketSend(byte[] data, int dataLength);
    public abstract int WebSocketReceive(byte[] data, int dataLength);
    
    // OpenGl
    public abstract void GlViewport(int x, int y, int width, int height);
    public abstract void GlClearColorBufferAndDepthBuffer();
    public abstract void GlDisableDepthTest();
    public abstract void GlClearColorRgbaf(float r, float g, float b, float a);
    public abstract void GlEnableDepthTest();
    public abstract void GlDisableCullFace();
    public abstract void GlEnableCullFace();
    public abstract void GlEnableTexture2d();
    public abstract void GlLineWidth(int width);
    public abstract void GlDisableAlphaTest();
    public abstract void GlEnableAlphaTest();
    public abstract void GlDeleteTexture(int id);
    public abstract void GlClearDepthBuffer();
    public abstract void GlLightModelAmbient(int r, int g, int b);
    public abstract void GlEnableFog();
    public abstract void GlHintFogHintNicest();
    public abstract void GlFogFogModeExp2();
    public abstract void GlFogFogColor(int r, int g, int b, int a);
    public abstract void GlFogFogDensity(float density);
    public abstract int GlGetMaxTextureSize();
    public abstract void GlDepthMask(bool flag);
    public abstract void GlCullFaceBack();
    public abstract void GlEnableLighting();
    public abstract void GlEnableColorMaterial();
    public abstract void GlColorMaterialFrontAndBackAmbientAndDiffuse();
    public abstract void GlShadeModelSmooth();
    public abstract void GlDisableFog();
    public abstract void BindTexture2d(int texture);
    public abstract Model CreateModel(ModelData modelData);
    public abstract void DrawModel(Model model);
    public abstract void InitShaders();
    public abstract void SetMatrixUniformProjection(float[] pMatrix);
    public abstract void SetMatrixUniformModelView(float[] mvMatrix);
    public abstract void DrawModels(Model[] model, int count);
    public abstract void DrawModelData(ModelData data);
    public abstract void DeleteModel(Model model);
    public abstract int LoadTextureFromBitmap(Bitmap bmp);
    
    // Game
    public abstract bool SinglePlayerServerAvailable();
    public abstract void SinglePlayerServerStart(string saveFilename);
    public abstract void SinglePlayerServerExit();
    public abstract bool SinglePlayerServerLoaded();
    public abstract void SinglePlayerServerDisable();
    public abstract DummyNetwork SinglePlayerServerGetNetwork();
    public abstract PlayerInterpolationState CastToPlayerInterpolationState(InterpolatedObject a);
}