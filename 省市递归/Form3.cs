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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> city = new List<string>();

            TblArea tblArea = this.comboBox1.SelectedItem as TblArea;

            if (tblArea != null)
            {
                string sql = "SELECT AreaId,AreaName FROM TblArea WHERE AreaPId=@AreaPId";
                SqlParameter parameters = new SqlParameter("@AreaPId", SqlDbType.Int) { Value = tblArea.AreaId };

                using (SqlDataReader reader = SqlHelper.ExecuteReader(sql,parameters))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            city.Add(reader.GetString(1));
                        }
                    }
                }
                //数据绑定
                this.comboBox2.DataSource = city;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<TblArea> listArea = new List<TblArea>();
            //Dictionary<int, string> listArea = new Dictionary<int, string>();

            string sql = "SELECT AreaId,AreaName FROM TblArea WHERE AreaPId=@AreaPId";

            SqlParameter parameters = new SqlParameter() { ParameterName = "@AreaPId", Value = 0 };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql,parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea area = new TblArea();
                        area.AreaId = reader.GetInt32(0);
                        area.AreaName = reader.GetString(1);
                        listArea.Add(area);
                        
                        //listArea.Add(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
            //数据绑定
            this.comboBox1.DisplayMember = "AreaIName";
            this.comboBox2.ValueMember = "AreaId";
            this.comboBox1.DataSource = listArea;
            //foreach (KeyValuePair<int,string> item in listArea)
            //{
            //    this.comboBox1.Items.Add(item.Value);
            //}
        }
    }
}
