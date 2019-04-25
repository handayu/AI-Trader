using LuaInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        class TestClass
        {
            private int value = 0;

            public void TestPrint(int num)
            {
                value = num * num;
                throw new Exception();
            }

            public static void TestStaticPrint()
            {
                //return "CSharp" + "TestStaticPrint";
                throw new Exception();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lua lua = new Lua();

            //lua调用c#函数
            TestClass obj = new TestClass();

            // 注册CLR对象方法到Lua，供Lua调用   typeof(TestClass).GetMethod("TestPrint")
            lua.RegisterFunction("TestPrint", obj, obj.GetType().GetMethod("TestPrint"));

            // 注册CLR静态方法到Lua，供Lua调用
            lua.RegisterFunction("TestStaticPrint", null, typeof(TestClass).GetMethod("TestStaticPrint"));

            object[] str1 = lua.DoString("TestPrint(10)");
            object[] str2 = lua.DoString("TestStaticPrint()");

        }
    }
}
