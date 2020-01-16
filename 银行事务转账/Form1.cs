using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 银行事务转账
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "usp_bank";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@from",SqlDbType.Char,4){Value=this.textBox1.Text.Trim()},
                new SqlParameter("@to",SqlDbType.Char,4){Value=this.textBox2.Text.Trim()},
                new SqlParameter("@balance",SqlDbType.Money){Value=this.textBox3.Text.Trim()},
                new SqlParameter("@status",SqlDbType.Int){Direction= ParameterDirection.Output}
            };

            省市递归.SqlHelper.ExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            int status = (int)parameters[3].Value;
            switch (status)
            {
                case 1:
                    MessageBox.Show("转账成功");
                    break;
                case 2:
                    MessageBox.Show("转账失败");
                    break;
                case 3:
                    MessageBox.Show("余额不足");
                    break;
                default:
                    break;
            }
        }
    }
}
