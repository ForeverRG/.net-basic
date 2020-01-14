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

namespace 资源管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            LoadDataToTreeView(-1, this.treeView1.Nodes);
        }

        private static List<CategoryInfo> GetDataByParentID(int pid)
        {
            List<CategoryInfo> listCategoryInfo = new List<CategoryInfo>();
            string sql = string.Format("select * from Category where tParentId=@pid");
            SqlParameter param = new SqlParameter("@pid", SqlDbType.Int) { Value = pid };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, param))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CategoryInfo cgi = new CategoryInfo();
                        cgi.TId = reader.GetInt32(0);
                        cgi.TName = reader.GetString(1);
                        cgi.TParentId = reader.GetInt32(2);
                        cgi.TNote = reader.GetString(3);

                        listCategoryInfo.Add(cgi);
                    }
                }
            }
            return listCategoryInfo;
        }

        private void LoadDataToTreeView(int p, TreeNodeCollection treeNodeCollection)
        {
            List<CategoryInfo> listCategoryInfo = GetDataByParentID(p);

            foreach (CategoryInfo item in listCategoryInfo)
            {
                TreeNode node = treeNodeCollection.Add(item.TName);
                node.Tag = item.TId;
                LoadDataToTreeView(item.TId, node.Nodes);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.listBox1.Items.Clear();
            int id = (int)e.Node.Tag;
            //根据id获取文章标题
            LoadNameByID(id);
        }

        private void LoadNameByID(int id)
        {
            List<ContentInfo> listContentInfo = new List<ContentInfo>();
            string sql = string.Format("select dId,dName from ContentInfo where dTId = @id");

            SqlParameter param = new SqlParameter("@id", SqlDbType.Int) { Value = id };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql,param))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContentInfo contentInfo = new ContentInfo();
                        contentInfo.DId = reader.GetInt32(0);
                        contentInfo.DName = reader.GetString(1);

                        listContentInfo.Add(contentInfo);
                    }
                }
            }

            foreach (ContentInfo item in listContentInfo)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ContentInfo contentInfo = this.listBox1.SelectedItem as ContentInfo;
            if (contentInfo != null)
            {
                int id = contentInfo.DId;

                LoadContentByID(id);
            }
            
            
        }

        private void LoadContentByID(int id)
        {
            string sql = string.Format("select dContent from ContentInfo where dId = @id");

            SqlParameter param = new SqlParameter("@id", SqlDbType.Int) { Value = id };

            object objContent = SqlHelper.ExecuteScalar(sql, param);
            string content = objContent == null ? string.Empty : objContent.ToString();
            
            this.textBox1.Text = content;
        }


    }
}
