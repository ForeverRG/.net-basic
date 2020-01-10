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

namespace 人物信息管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";

            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM TblPerson";

                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();

                    SqlDataReader reader = sqlComm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.Write(reader.GetInt32(0) + "\t|\t");
                            Console.Write(reader.GetString(1) + "\t|\t");
                            Console.Write(reader.GetInt32(2) + "\t|\t");

                            //int?和bool?表示这两种数据类型可以赋值为null
                            Console.Write(reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3) + "\t|\t");
                            Console.Write(reader.IsDBNull(4) ? null : (bool?)reader.GetBoolean(4) + "\t|\t");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";

            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                string sql = string.Format("INSERT INTO TblPerson output inserted.autoId VALUES (N'{0}',{1},{2},{3})", this.textBoxAddName.Text.Trim(), Convert.ToInt32(this.textBoxAddAge.Text.Trim()), Convert.ToInt32(this.textBoxHeight.Text.Trim()), Convert.ToInt32(this.textBoxUpdGender.Text.Trim()));
            } 

        }
    }
}
