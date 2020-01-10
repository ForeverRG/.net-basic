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

namespace 学生信息管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 加载数据库数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //创建数据源集合
            List<ClassInfo> dataSource = new List<ClassInfo>();
            //连接字符串
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";
            //连接对象
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                //sql语句
                string sql = "SELECT * FROM TblClass";
                //创建命令对象
                using (SqlCommand sqlCom = new SqlCommand(sql, sqlConn))
                {
                    //连接数据库
                    sqlConn.Open();
                    //执行sql语句
                    SqlDataReader reader = sqlCom.ExecuteReader();
                    //判断是否获取到数据
                    if (reader.HasRows)
                    {
                        //循环获取数据
                        while (reader.Read())
                        {
                            //创建数据接收对象
                            ClassInfo classinfo = new ClassInfo();
                            classinfo.Id = reader.GetInt32(0);
                            classinfo.Name = reader.GetString(1);
                            classinfo.Des = reader.GetString(2);
                            //Console.WriteLine(reader.GetInt32(0) + "\t|\t");
                            //Console.Write(reader.GetString(1) + "\t|\t");
                            //Console.Write(reader.GetString(2) + "\t|\t");
                            dataSource.Add(classinfo);
                        }
                    }
                    else
                    {
                        this.Text = "无数据";
                    }
                    //Console.WriteLine();
                }
            }
            //将数据源list与datagridview进行数据绑定
            this.dataGridView1.DataSource = dataSource;
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = this.textBoxAddName.Text.Trim();
            string des = this.textBoxAddDes.Text.Trim();

            //创建连接字符串
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";
            //创建连接对象
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                //创建sql语句
                string sql = string.Format("INSERT INTO TblClass values (N'{0}',N'{1}')", this.textBoxAddName.Text.Trim(), this.textBoxAddDes.Text.Trim());
                //创建命令对象
                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    //打开连接
                    sqlConn.Open();
                    //执行sql语句
                    int r = sqlComm.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = "新增" + r + "个班级";
                    }
                    LoadData();
                }
            } 

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取选中行的数据
            DataGridViewRow dgv = this.dataGridView1.Rows[e.RowIndex];
            //获取id值
            //this.labelID.Text = dgv.Cells[0].Value.ToString(); //此方法可以获取id值
            //通过数据绑定对象来获取选中行的值
            ClassInfo classinfo = dgv.DataBoundItem as ClassInfo;
            if (classinfo != null)
            {
                this.labelID.Text = classinfo.Id.ToString();
                this.textBoxUpdName.Text = classinfo.Name;
                this.textBoxUpdDes.Text = classinfo.Des;
            }
        }
        /// <summary>
        /// 修改班级信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd_Click(object sender, EventArgs e)
        {
            //创建连接字符串
            string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";
            //连接对象
            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                //sql
                string sql = string.Format("UPDATE TblClass SET tClassName=N'{0}',tClassDesc=N'{1}' WHERE tClassId={2}", this.textBoxUpdName.Text, this.textBoxUpdDes.Text, Convert.ToInt32(this.labelID.Text));
                //命令对象
                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    //打开连接
                    sqlConn.Open();
                    //执行语句
                    int r = sqlComm.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = "成功修改" + r + "行";
                    }
                }
            }
            LoadData();
        }
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dRes = MessageBox.Show("确定要删除么?", "删除班级", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dRes==DialogResult.OK)
            {
                string conStr = "Data Source=192.168.1.171;Initial Catalog=Itcast2014;User ID=sa;Password=1234567";
                using (SqlConnection sqlConn = new SqlConnection(conStr))
                {
                    string sql = string.Format("DELETE FROM TblClass WHERE tClassId={0}", Convert.ToInt32(this.labelID.Text));
                    using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                    {
                        sqlConn.Open();
                        int r = sqlComm.ExecuteNonQuery();
                        if (r > 0)
                        {
                            this.Text = "成功删除了" + r + "行";
                        }
                    }
                }
                LoadData();
            }
        }
    }
}
