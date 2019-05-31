using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class IndicatorsLoader
    {
        private static string m_startPath = System.Windows.Forms.Application.StartupPath + "\\TALibraryInCSharp.dll";

        /// <summary>
        /// 获取ta.lib Core里面的所有指标(方法)的信息
        /// </summary>
        /// <returns></returns>
        public static List<MemberInfo> LoadeIndicatorsFuncAisa()
        {
            if (!File.Exists(m_startPath))
            {
                throw new Exception("无法找到TALibraryInCSharp.dll文件,请检查");
            }

            List<Type> tList = new List<Type>();

            Assembly assem = Assembly.LoadFile(m_startPath);
            Type[] tys = assem.GetTypes();
            foreach (Type ty in tys)
            {
                tList.Add(ty);
            }

            List<MemberInfo> infos = new List<MemberInfo>();

            for (int i = 0; i < tList.Count; i++)
            {
                if (tList[i].Name == "Core")
                {
                    infos = tList[i].GetMembers().ToList();
                }
            }

            return infos;
        }

    }
}
