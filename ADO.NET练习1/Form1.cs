using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO.NET练习1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int DBConnection(string sql)
        {
            //创建连接字符串
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";
            //创建连接对象
            using (SqlConnection sqlconn = new SqlConnection(conStr))
            {

                //创建命令对象
                using (SqlCommand sqlComm = new SqlCommand(sql, sqlconn))
                {
                    //打开数据库连接
                    sqlconn.Open();
                    //执行sql语句
                    return sqlComm.ExecuteNonQuery();
                }
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string sql = "insert into NewPerson values (N'" + this.textBoxName.Text.Trim() + "'," + Convert.ToInt32(this.textBox1.Text.Trim()) + ")";
            int count = DBConnection(sql);
            MessageBox.Show("成功添加" + count + "名用户");
        }

    }

}
