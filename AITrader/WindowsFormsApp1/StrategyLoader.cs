using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class StrategyLoader
    {
        private static string m_startPath = System.Windows.Forms.Application.StartupPath + "\\Strategy.dll";


        public static List<Type> LoadeStartegy()
        {
            if (!File.Exists(m_startPath))
            {
                throw new Exception("无法找到Startegy.dll文件,请检查");
            }

            List<Type> tList = new List<Type>();

            Assembly assem = Assembly.LoadFile(m_startPath);
            Type[] tys = assem.GetTypes();
            foreach (Type ty in tys)
            {
                tList.Add(ty);
            }
            return tList;
        }

        public static object CreateInstanceStrategy(Type type, string ins, int frame)
        {
            try
            {
                object o = new object();

                o = Activator.CreateInstance(type, ins, frame);//创建类实例

                return o;
            }
            catch(Exception ex)
            {
                throw new Exception("创建strategy对象发生异常:" + ex.Message);
            }

        }
    }
}
