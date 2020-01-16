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

namespace 地区表分页显示
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 通过编程实现分页
        //当前查看的页码
        private int pageIndex = 1;
        //每页显示条数
        private int pageSize = 7;
        //总页数
        private int totalPageNum;
        //总条数
        private int totalRecordNum;
        private void Form1_Load(object sender, EventArgs e)
        {
            ////获取表中总记录数
            //this.totalRecordNum = GetTotalRecordNum();
            //this.labelTotalRecordNum.Text = this.totalRecordNum.ToString();
            ////获取总页数
            //this.totalPageNum = (int)Math.Ceiling(this.totalRecordNum * 1.0 / this.pageSize);
            //this.labelTotalPage.Text = totalPageNum.ToString();
            //窗体加载时显示第一页
            LoadDataTOGridView();
        }

        private void LoadDataTOGridView()
        {
            //List<DicRegion> listDR = GetPageContent();
            //this.dataGridView1.DataSource = listDR;

            this.dataGridView1.DataSource = GetPageContent_();
        }

        private List<DicRegion> GetPageContent()
        {
            List<DicRegion> listDR = new List<DicRegion>();

            string sql = "select Id,Grade,ParentId,Description from (select row_number() over(order by Id asc) num,* from DicRegion) t where t.num between @from and @to";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@from", SqlDbType.Int) { Value = (pageIndex - 1) * pageSize + 1 }, 
                new SqlParameter("@to", SqlDbType.Int) { Value = pageIndex * pageSize } };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DicRegion dr = new DicRegion();

                        dr.Id = reader.GetString(0);
                        dr.Grade = reader.GetByte(1);   //tinyint类型的数据用getbyte（）来获取
                        dr.ParentId = reader.IsDBNull(2) ? "" : (string)reader.GetString(2);
                        dr.Description = reader.GetString(3);

                        //Console.Write(reader.GetString(0) + " \t | \t");
                        //Console.Write(reader.GetByte(1) + " \t | \t");
                        //Console.Write(reader.IsDBNull(2) ? "" : (string)reader.GetString(2) + " \t | \t");
                        //Console.Write(reader.GetString(3) + " \t | \t");

                        listDR.Add(dr);
                    }
                }
            }

            return listDR;
        }

        private DataTable GetPageContent_()
        {
            string sql = "usp_paging_mystudent";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pageindex",SqlDbType.Int){Value=this.pageIndex},
                new SqlParameter("@pagesize",SqlDbType.Int){Value=this.pageSize},
                new SqlParameter("@totalrecordnum",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@totalPageNum",SqlDbType.Int){Direction=ParameterDirection.Output}
            };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.StoredProcedure, parameters);

            //获取存储过程输出的值
            this.labelTotalRecordNum.Text = parameters[2].Value.ToString();
            this.labelTotalPage.Text = parameters[3].Value.ToString();

            return dt;
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (this.pageIndex < this.totalPageNum)
            {
                this.pageIndex++;
                LoadDataTOGridView();
            }
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.pageIndex > 1)
            {
                this.pageIndex--;
                LoadDataTOGridView();
            }
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1;
            LoadDataTOGridView();
        }

        private void buttonLastPage_Click(object sender, EventArgs e)
        {
            //显示最后一页内容
            this.pageIndex = this.totalPageNum;
            LoadDataTOGridView();
        }

        private int GetTotalRecordNum()
        {
            string sql = "select count(*) from DicRegion";
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text);
        }

        private void buttonSkipPage_Click(object sender, EventArgs e)
        {
            this.pageIndex = Convert.ToInt32(this.textBoxCurrentPage.Text.Trim());
            LoadDataTOGridView();
        }
        #endregion

        #region 通过存储过程实现分页



        #endregion
    }
}
