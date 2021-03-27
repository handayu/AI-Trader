using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace WindowsFormsApp1
{
    public partial class AddInstruments : Form
    {
        private List<ItemComboBox> m_exthroughDataSourceList = new List<ItemComboBox>();

        public AddInstruments()
        {
            InitializeComponent();
        }

        public class ItemComboBox
        {
            public string DisplayName
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }

            public EXCHANGETHROUGH EnumValue
            {
                get;
                set;
            }

        }

        private void Form_Load(object sender, EventArgs e)
        {
            Type parematerType = typeof(EXCHANGETHROUGH);
            foreach (int index in Enum.GetValues(parematerType))
            {
                string name = Enum.GetName(parematerType, index);
                string value = index.ToString();
                //需要增加引用：System.Web
                //引用命名空间：using System.Web.UI.WebControls;
                //ListBox 也可用这个方法
                ItemComboBox iT = new ItemComboBox();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (EXCHANGETHROUGH)(iS);
                m_exthroughDataSourceList.Add(iT);
            }

            this.comboBox_dataSource.DisplayMember = "DisplayName";
            this.comboBox_dataSource.ValueMember = "EnumValue";
            this.comboBox_dataSource.DataSource = m_exthroughDataSourceList;
        }
    }
}
