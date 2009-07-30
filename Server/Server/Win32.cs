

using System;
using System.Runtime.InteropServices;

/// <summary>
/// Used to call some unmanaged code functions in MediaPlayer module.
/// Finds windows and sends messages to components. 
/// </summary>
public class Win32
{    
    /// <summary>
    /// The WM_COMMAND message is sent when the user
    /// selects a command item from a menu, 
    /// when a control sends a notification message
    /// to its parent window, or when an 
    /// accelerator keystroke is translated.
    /// </summary>
    public const int WM_COMMAND = 0x111;
    
    /// <summary>
    /// The FindWindow function retrieves a handle
    /// to the top-level window whose class name
    /// and window name match the specified strings.
    /// This function does not search child windows.
    /// This function does not perform a case-sensitive search.
    /// </summary>
    /// <param name="strClassName"></param>
    /// <param name="strWindowName"></param>
    /// <returns>Window handler.</returns>
    [DllImport("User32.dll")]
    public static extern int FindWindow(string strClassName, string strWindowName);   

    /// <summary>
    /// The FindWindowEx function retrieves
    /// a handle to a window whose class name 
    /// and window name match the specified strings.
    /// The function searches child windows, beginning
    /// with the one following the specified child window.
    /// This function does not perform a case-sensitive search.
    /// </summary>
    /// <param name="hwndParent"></param>
    /// <param name="hwndChildAfter"></param>
    /// <param name="strClassName"></param>
    /// <param name="strWindowName"></param>
    /// <returns>Window handler.</returns>
    [DllImport("User32.dll")]
    public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

    /// <summary>
    /// The SendMessage function sends the specified message to a 
    /// window or windows. It calls the window procedure for the specified 
    /// window and does not return until the window procedure
    /// has processed the message.     
    /// </summary>
    /// <param name="hWnd">handle to destination window</param>
    /// <param name="Msg">message</param>
    /// <param name="wParam">first message parameter</param>
    /// <param name="lParam">second message parameter</param>
    /// <returns></returns>
    [DllImport("User32.dll")]
    public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);
    
    /// <summary>
    /// Overrided method. The same as above except last param type.
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="Msg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [DllImport("User32.dll")]
    public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, int lParam);

}