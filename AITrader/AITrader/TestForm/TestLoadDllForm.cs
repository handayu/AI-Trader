using Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TestLoadDllForm : Form
    {
        /// <summary>
        /// Load-dll-test
        /// </summary>

        public TestLoadDllForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OK_Click(object sender, EventArgs e)
        {

            //Byte[] byte1 = System.IO.File.ReadAllBytes(path);//也是可以的
            //Assembly assem = Assembly.Load(byte1);

            Assembly assem = Assembly.LoadFile(this.textBox_dll.Text);


            //string t_class = "mydll.Class1";//理论上已经加载了dll文件，可以通过命名空间加上类名获取类的类型，这里应该修改为如下：

            //string t_class = "mydll.Class1,mydll";//如果你想要得到的是被本工程内部的类，可以“命名空间.父类……类名”;如果是外部的，需要在后面加上“,链接库名”;

            //再次感谢thy38的帮助。

            //Type ty = Type.GetType("VolatityStrategy");//这儿在调试的时候ty=null，一直不理解，望有高人可以解惑

            Type[] tys = assem.GetTypes();//只好得到所有的类型名，然后遍历，通过类型名字来区别了
            foreach (Type ty in tys)//huoquleiming
            {
                if (ty.Name == "VolatityStrategy")
                {
                    object obj = Activator.CreateInstance(ty,"BTC",0);
                    MethodInfo mi = ty.GetMethod("saybeautiful");
                    //object aa = mi.Invoke(magicClassObject, null);//方法有参数时，需要把null替换为参数的集合
                    //MessageBox.Show(aa.ToString());

                }
            }

        }
    }
}
