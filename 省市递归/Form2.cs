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

namespace 省市递归
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //要执行的sql语句
            string sql = "select count(*) from Users where loginId=@loginId and loginPwd=@loginPwd";

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@loginId", SqlDbType.VarChar, 50) { Value = this.textBox1.Text.Trim() }, new SqlParameter("@loginPwd", SqlDbType.VarChar, 50) { Value = this.textBox2.Text } };

            int r = (int)SqlHelper.ExecuteScalar(sql, parameters);
            if (r > 0)
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }
    }
}
