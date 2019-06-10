using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;//调用DLLIMPORT
using System.Diagnostics;

namespace Common
{
    public class WindowsHooker
    {
        //定义句柄的全局变量
        public int HANDLE;
        //定义回调函数的委托
        public delegate bool CALLBACK(int hwnd, int lparm);

        //用于获取前台窗口句柄,设置当前窗口句柄
        [DllImport("user32.dll")]
        public static extern int EnumWindows(CALLBACK x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowText(int hWnd, StringBuilder lpText, int nCount);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(int hWnd);

        public int MCPTR
        {
            set;
            get;
        }

        public void GetHwd()
        {
            CALLBACK myCallBack = new CALLBACK(Report);
            EnumWindows(myCallBack, 0);         
        }

        //实例化回调函数(可以在回调函数中根据窗体名称找到目标窗体句柄)
        public bool Report(int hwnd, int lparm)
        {
            //分配空间
            var sb = new StringBuilder(50);
            GetWindowText(hwnd, sb, sb.Capacity);
            //注意某些窗口没有标题
            if (sb.ToString() != String.Empty && sb.ToString().Contains("MultiCharts"))
            {
                Debug.WriteLine(sb.ToString());
                //if (sb.ToString() == "Microsoft PowerPoint - [les_03_使用_rman [兼容模式]]")
                Debug.WriteLine(hwnd.ToString());
                MCPTR = hwnd;
                SetForegroundWindow(hwnd);
            }

            return true;
        }
    }
}
