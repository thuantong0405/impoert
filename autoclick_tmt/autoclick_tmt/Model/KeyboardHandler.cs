using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace autoclick_tmt.Model
{
    class KeyboardHandler : IDisposable
    {
        public const int WM_HOTKEY = 0x0312;
        public const int VIRTUALKEYCODE_FOR_CAPS_LOCK = 0x14;
        public const int VK_CONTROL = 2;
        public const int VK_RIGHT = 0x27;
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly Window _mainWindow;
        WindowInteropHelper _host;

        public KeyboardHandler(Window mainWindow)
        {
            _mainWindow = mainWindow;
            _host = new WindowInteropHelper(_mainWindow);

            SetupHotKey(_host.Handle);
            ComponentDispatcher.ThreadPreprocessMessage -= ComponentDispatcher_ThreadPreprocessMessage;
            ComponentDispatcher.ThreadPreprocessMessage += ComponentDispatcher_ThreadPreprocessMessage;
        }

        void ComponentDispatcher_ThreadPreprocessMessage(ref MSG msg, ref bool handled)
        {
            if (msg.message == WM_HOTKEY)
            {
                MessageBox.Show("s");
                //Handle hot key kere
            }
        }

        private void SetupHotKey(IntPtr handle)
        {
            RegisterHotKey(handle, GetType().GetHashCode(), KeyEnum.CONTROL, KeyEnum.RIGHT);
        }
        public void Dispose()
        {
            UnregisterHotKey(_host.Handle, GetType().GetHashCode());
        }
    }
}
