using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Common
{
    public class MCDataLooper
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        private const int WM_SETTEXT = 0x000C;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        private int WM_GETTEXT = 0x0D;

        private IntPtr m_intPtr;

        public MCDataLooper(IntPtr outPutHandle)
        {
            try
            {
                m_intPtr = outPutHandle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetMCData()
        {

            const int buffer_size = 65536;
            StringBuilder buffer = new StringBuilder(buffer_size);
            SendMessage(m_intPtr, WM_GETTEXT, buffer_size, buffer);
            string str = buffer.ToString();
            if (str == "" || str == null) return "";
            //2.清空输出窗口
            SendMessage(m_intPtr, WM_SETTEXT, IntPtr.Zero, "");
            return str;
        }

    }
}
