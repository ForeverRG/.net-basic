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
using 省市递归;

namespace 电话本管理程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //修改联系人
            Console.WriteLine((this.comboBox1.SelectedItem as PhoneType).Id);
            string sql = "update phonenum set ptypeid=@tid,pname=@name,pcellphone=@cellphone,phomephone=@homephone where pid=@id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tid", SqlDbType.Int) { Value = (this.comboBox1.SelectedItem as PhoneType).Id }, new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = this.textBox2.Text.Trim() }, new SqlParameter("@cellphone", SqlDbType.NVarChar, 50) { Value = this.textBox1.Text.Trim() }, new SqlParameter("@homephone", SqlDbType.NVarChar, 50) { Value = this.textBox3.Text.Trim() }, new SqlParameter("@id", SqlDbType.Int) { Value = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value)} };

            SqlHelper.ExecuteNonQuery(sql, parameters);

            Console.WriteLine("修改成功");

            LoadDataToGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            //加载gridiview数据
            LoadDataToGridView();
            //加载分组信息
            LoadTypeToGroupBox();
        }

        private void LoadTypeToGroupBox()
        {
            List<PhoneType> listPT = GetPhoneType();

            this.comboBoxGroupType.DataSource = listPT;

            this.comboBox1.DataSource = listPT;
        }

        private static List<PhoneType> GetPhoneType()
        {
            List<PhoneType> listPT = new List<PhoneType>();

            string sql = "select ptid,ptname from PhoneType";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhoneType pt = new PhoneType();
                        pt.Id = reader.GetInt32(0);
                        pt.Name = reader.GetString(1);

                        listPT.Add(pt);
                    }
                }
            }
            return listPT;
        }

        private void LoadDataToGridView()
        {
            //获取数据源
            List<PhoneNumber> listPN = GetDataSource();
            //绑定数据源
            this.dataGridView1.DataSource = listPN;
        }

        private static List<PhoneNumber> GetDataSource()
        {
            List<PhoneNumber> listPN = new List<PhoneNumber>();

            string sql = "select pid,pTypeId,pname,pCellphone,ptname,phomephone from PhoneType pt inner join PhoneNum pn on pt.ptId = pn.pTypeId";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhoneNumber pn = new PhoneNumber();
                        pn.Id = reader.GetInt32(0);
                        pn.TypeId = reader.GetInt32(1);
                        pn.Name = reader.GetString(2);
                        pn.Cellphone = reader.GetString(3);
                        pn.Homephone = reader.GetString(5);

                        PhoneType pt = new PhoneType();
                        pt.Id = reader.GetInt32(1);
                        pt.Name = reader.GetString(4);

                        pn.Pt = pt;

                        listPN.Add(pn);
                    }
                }
            }
            return listPN;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(e.RowIndex);
            //this.dataGridView1.Rows[e.RowIndex]
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = this.dataGridView1.Rows[e.RowIndex];
                dgvr.Cells[0].Value.ToString();

                this.textBox1.Text = dgvr.Cells[2].Value.ToString();
                this.textBox2.Text = dgvr.Cells[1].Value.ToString();
                this.textBox3.Text = dgvr.Cells[4].Value.ToString();

                foreach (var item in this.comboBox1.Items)
                {
                    if (item.ToString() == dgvr.Cells[3].Value.ToString())
                    {
                        this.comboBox1.SelectedItem = item;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //根据id删除联系人
            string sql = "delete from phonenum where pid=@id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int) { Value = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value) };

            SqlHelper.ExecuteNonQuery(sql, parameter);

            //清除窗口数据
            LoadDataToGridView();
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.textBox3.Text = string.Empty;

            Console.WriteLine("删除成功");
 
        }
    }
}
