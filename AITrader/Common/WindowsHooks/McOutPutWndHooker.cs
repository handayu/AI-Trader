using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class McOutPutWndHooker
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        private const int WM_SETTEXT = 0x000C;


        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        private int WM_GETTEXT = 0x0D;


        private IntPtr m_intPtr;

        public McOutPutWndHooker(IntPtr ptr)
        {
            //初始化CommandLine的窗口句柄
            m_intPtr = ptr;
        }

        public void SendMessageToOutPutWnd(string messageInfo)
        {
            SendMessage(m_intPtr, WM_SETTEXT, IntPtr.Zero, messageInfo);
        }

        public string SendMessageToHoldOutPutMessage()
        {
            const int buffer_size = 1024;
            StringBuilder buffer = new StringBuilder(buffer_size);
            SendMessage(m_intPtr, WM_GETTEXT, buffer_size, buffer);
            string str = buffer.ToString();
            return str;
        }
    }
}
