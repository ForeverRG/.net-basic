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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //using (SqlConnection sqlConn = new SqlConnection(conStr))
            //{
            List<TblArea> listArea = new List<TblArea>();
            //先获取根节点
            string sql = string.Format("SELECT AreaId,AreaName FROM TblArea WHERE AreaPId=@AreaPId");
            //绑定参数
            SqlParameter parameters = new SqlParameter() { ParameterName = "@AreaPId", Value = 0 };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, parameters))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea tblArea = new TblArea();
                        tblArea.AreaId = reader.GetInt32(0);
                        tblArea.AreaName = reader.GetString(1);
                        listArea.Add(tblArea);
                    }
                }
            }
            //向treeview中添加节点
            foreach (TblArea item in listArea)
            {
                TreeNode node = this.treeView1.Nodes.Add(item.AreaName);
                node.Tag = item.AreaId;
                LoadTreeView(item.AreaId, node.Nodes);
            }
            
            //using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
            //{
            //    sqlConn.Open();

            //    using (SqlDataReader reader = sqlComm.ExecuteReader())
            //    {
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                TreeNode node = this.treeView1.Nodes.Add(reader.GetString(1));
            //                LoadTreeView(reader.GetInt32(0), node.Nodes);
            //            }
            //        }
            //    }
            //}
            //}
        }
        /// <summary>
        /// 递归加载省市
        /// </summary>
        /// <param name="p"></param>
        /// <param name="treeNodeCollection"></param>
        private void LoadTreeView(int p, TreeNodeCollection treeNodeCollection)
        {
            string conStr = "Data Source = 192.168.1.171; Initial Catalog = Itcast2014; User ID = sa; Password=1234567";

            using (SqlConnection sqlConn = new SqlConnection(conStr))
            {
                string sql = string.Format("SELECT AreaId,AreaName FROM TblArea WHERE AreaPId = {0}", p);

                using (SqlCommand sqlComm = new SqlCommand(sql, sqlConn))
                {
                    sqlConn.Open();

                    using (SqlDataReader reader = sqlComm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TreeNode node = treeNodeCollection.Add(reader.GetString(1));
                                LoadTreeView(reader.GetInt32(0), node.Nodes);
                            }
                        }
                    }
                }
            }
        }
    }
}
