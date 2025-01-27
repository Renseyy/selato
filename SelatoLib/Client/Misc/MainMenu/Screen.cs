using SelatoLib.Client;
using SelatoLib.Client.Misc.Platform;
using SelatoLib.Client.Misc.Platform.EventArgs;

namespace  SelatoLib.Client.Misc.MainMenu;

public class Screen(int widgetCount = 64)
{
     private int _widgetCount = widgetCount;
     private MenuWidget?[] _widgets = new MenuWidget?[widgetCount];
     private Client.MainMenu _menu; 

     public virtual void Render(float dt) { }
     public virtual void OnKeyDown(KeyEventArgs e) { _keyDown(e); }
     public virtual void OnKeyPress(KeyPressEventArgs e) { KeyPress(e); }
     public virtual void OnKeyUp(KeyEventArgs e) {  }
     public virtual void OnTouchStart(TouchEventArgs e) { MouseDown(e.X, e.Y); }
     public virtual void OnTouchMove(TouchEventArgs e) { }
     public virtual void OnTouchEnd(TouchEventArgs e) { MouseUp(e.X, e.Y); }
     public virtual void OnMouseDown(MouseEventArgs e) { MouseDown(e.X, e.Y); }
     public virtual void OnMouseUp(MouseEventArgs e) { MouseUp(e.X, e.Y); }
     public virtual void OnMouseMove(MouseEventArgs e) { MouseMove(e); }
     public virtual void OnBackPressed() { }
     public virtual void LoadTranslations() { }
    
 private void _keyDown(KeyEventArgs @event)
 {
     for (var i = 0; i < WidgetCount; i++)
     {
         var widget = _widgets[i];
         if (widget == null)
         {
             continue;
         }
         if (widget.HasKeyboardFocus)
         {
             if (@event.KeyCode is Key.Tab or Key.Enter)
             {
                 if (widget.Type == WidgetType.Button && @event.KeyCode == Key.Enter)
                 {
                     //Call OnButton when enter is pressed and widget is a button
                     OnButton(widget);
                     return;
                 }
                 if (widget.NextWidget != null)
                 {
                     //Just switch focus otherwise
                     widget.LoseFocus();
                     widgets[(uint) widget.NextWidget].GetFocus();
                     return;
                 }
             }
         }

         if (widget.Type != WidgetType.Textbox || !widget.Editing) continue;
         var key = @event.KeyCode;
         // pasting text from clipboard
         
         if (@event.IsCtrlPressed && key == Key.V)
         {
             if (_menu.Platform.ClipboardContainsText())
             {
                 widget.Text = StringTools.StringAppend(menu.p, widget.text, menu.p.ClipboardGetText());
             }
             return;
         }
         // deleting characters using backspace
         if (key == Key.BackSpace)
         {
             if (menu.StringLength(widget.text) > 0)
             {
                 widget.text = StringTools.StringSubstring(menu.p, widget.text, 0, menu.StringLength(widget.text) - 1);
             }
             return;
         }
     }
 }

 void KeyPress(KeyPressEventArgs e)
 {
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             if (w.type == WidgetType.Textbox)
             {
                 if (w.editing)
                 {
                     if (menu.p.IsValidTypingChar(e.GetKeyChar()))
                     {
                         w.text = StringTools.StringAppend(menu.p, w.text, menu.CharToString(e.GetKeyChar()));
                     }
                 }
             }
         }
     }
 }

 void MouseDown(int x, int y)
 {
     bool editingChange = false;
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             if (w.type == WidgetType.Button)
             {
                 w.pressed = pointInRect(x, y, w.x, w.y, w.sizex, w.sizey);
             }
             if (w.type == WidgetType.Textbox)
             {
                 w.pressed = pointInRect(x, y, w.x, w.y, w.sizex, w.sizey);
                 bool wasEditing = w.editing;
                 w.editing = w.pressed;
                 if (w.editing && (!wasEditing))
                 {
                     menu.p.ShowKeyboard(true);
                     editingChange = true;
                 }
                 if ((!w.editing) && wasEditing && (!editingChange))
                 {
                     menu.p.ShowKeyboard(false);
                 }
             }
             if (w.pressed)
             {
                 //Set focus to new element when clicked on
                 AllLoseFocus();
                 w.GetFocus();
             }
         }
     }
 }
 
 void AllLoseFocus()
 {
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             w.LoseFocus();
         }
     }
 }
 
 void MouseUp(int x, int y)
 {
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             w.pressed = false;
         }
     }
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             if (w.type == WidgetType.Button)
             {
                 if (pointInRect(x, y, w.x, w.y, w.sizex, w.sizey))
                 {
                     OnButton(w);
                 }
             }
         }
     }
 }

 public virtual void OnButton(MenuWidget w) { }

 void MouseMove(MouseEventArgs e)
 {
     if (e.GetEmulated() && !e.GetForceUsage())
     {
         return;
     }
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             w.hover = pointInRect(e.GetX(), e.GetY(), w.x, w.y, w.sizex, w.sizey);
         }
     }
 }

 bool pointInRect(float x, float y, float rx, float ry, float rw, float rh)
 {
     return x >= rx && y >= ry && x < rx + rw && y < ry + rh;
 }

 public virtual void OnMouseWheel(MouseWheelEventArgs e) { }
 internal int WidgetCount;
 internal MenuWidget[] widgets;
 public void DrawWidgets()
 {
     for (int i = 0; i < WidgetCount; i++)
     {
         MenuWidget w = widgets[i];
         if (w != null)
         {
             if (!w.visible)
             {
                 continue;
             }
             string text = w.text;
             if (w.selected)
             {
                 text = StringTools.StringAppend(menu.p, "&2", text);
             }
             if (w.type == WidgetType.Button)
             {
                 if (w.buttonStyle == ButtonStyle.Text)
                 {
                     if (w.image != null)
                     {
                         menu.Draw2dQuad(menu.GetTexture(w.image), w.x, w.y, w.sizex, w.sizey);
                     }
                     menu.DrawText(text, w.font, w.x, w.y + w.sizey / 2, TextAlign.Left, TextBaseline.Middle);
                 }
                 else if (w.buttonStyle == ButtonStyle.Button)
                 {
                     menu.DrawButton(text, w.font, w.x, w.y, w.sizex, w.sizey, (w.hover || w.hasKeyboardFocus));
                     if (w.description != null)
                     {
                         menu.DrawText(w.description, w.font, w.x, w.y + w.sizey / 2, TextAlign.Right, TextBaseline.Middle);
                     }
                 }
             }
             if (w.type == WidgetType.Textbox)
             {
                 if (w.password)
                 {
                     text = menu.CharRepeat(42, menu.StringLength(w.text)); // '*'
                 }
                 if (w.editing)
                 {
                     text = StringTools.StringAppend(menu.p, text, "_");
                 }
                 if (w.buttonStyle == ButtonStyle.Text)
                 {
                     if (w.image != null)
                     {
                         menu.Draw2dQuad(menu.GetTexture(w.image), w.x, w.y, w.sizex, w.sizey);
                     }
                     menu.DrawText(text, w.font, w.x, w.y, TextAlign.Left, TextBaseline.Top);
                 }
                 else
                 {
                     menu.DrawButton(text, w.font, w.x, w.y, w.sizex, w.sizey, (w.hover || w.editing || w.hasKeyboardFocus));
                 }
                 if (w.description != null)
                 {
                     menu.DrawText(w.description, w.font, w.x, w.y + w.sizey / 2, TextAlign.Right, TextBaseline.Middle);
                 }
             }
         }
     }
 }
}