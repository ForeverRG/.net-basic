using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 查询字符串拼接
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private string GetSql()
        {
            List<string> listSB = new List<string>();
            StringBuilder sbSql = new StringBuilder();
            string sql = "select * from test ";
            sbSql.Append(sql);

            if (this.textBox1.Text.Length > 0)
            {
                listSB.Add(" a like '%" + this.textBox1.Text.Trim() + "%'");
            }

            if (this.textBox2.Text.Length > 0)
            {
                listSB.Add(" a like '%" + this.textBox2.Text.Trim() + "%'");
            }

            if (this.textBox3.Text.Length > 0)
            {
                listSB.Add(" a like '%" + this.textBox3.Text.Trim() + "%'");
            }

            if (listSB.Count > 0)
            {
                sbSql.Append("where");
                sbSql.Append(string.Join(" and", listSB));
            }

            return sbSql.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetSql());
        }

    }
}
