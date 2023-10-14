using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows;
using System;

namespace HarmonyAssistant.UI.Windows
{
    public static class WindowHelper
    {
        const int WS_BORDER = 8388608;
        const int WS_DLGFRAME = 4194304;
        const int WS_CAPTION = WS_BORDER | WS_DLGFRAME;
        const int WS_SYSMENU = 524288;
        const int WS_THICKFRAME = 262144;
        const int WS_MINIMIZE = 536870912;
        const int WS_MAXIMIZEBOX = 65536;
        const int GWL_STYLE = -16;
        const int GWL_EXSTYLE = -20;
        const int WS_EX_DLGMODALFRAME = 0x1;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public static void RemoveSysMenu(Window window)
        {
            if (null == window)
            {
                return;
            }

            var hwnd = new WindowInteropHelper(window).Handle;

            int Style = 0;
            Style = GetWindowLong(hwnd, GWL_STYLE);
            //Style = Style & ~WS_CAPTION;
            Style = Style & ~WS_SYSMENU;
            //Style = Style & ~WS_THICKFRAME;
            Style = Style & ~WS_MINIMIZE;
            Style = Style & ~WS_MAXIMIZEBOX;
            SetWindowLong(hwnd, GWL_STYLE, Style);
            Style = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, Style | WS_EX_DLGMODALFRAME);
        }

        public static void RemoveSysMenu(Object sender, EventArgs e)
        {
            RemoveSysMenu(sender as Window);
        }
    }
}
