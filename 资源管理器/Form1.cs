using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            this.treeView1.Nodes.Clear();
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

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, param))
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

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //弹出对话框
            Form2 form2 = new Form2(-1, LoadTreeView);
            form2.Show();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断当前是否选中节点
            if (this.treeView1.SelectedNode != null)
            {
                Form2 form2 = new Form2(Convert.ToInt32(this.treeView1.SelectedNode.Tag), LoadTreeView);
                form2.Show();
            }
            else
            {
                MessageBox.Show("请选中类别");
            }

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode != null)
            {
                //获取选中类别的id
                int pid = (int)this.treeView1.SelectedNode.Tag;
                //设置文件选择器，打开对话框
                this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
                DialogResult result = this.openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //获取所有选中文件的路径
                    string[] path = this.openFileDialog1.FileNames;
                    //循环插入所有选中的文本文件
                    for (int i = 0; i < path.Length; i++)
                    {
                        //获取所有选中文件的文件名,不包含扩展名
                        string name = Path.GetFileNameWithoutExtension(path[i]);
                        //获取所有选中文件的内容
                        string content = File.ReadAllText(path[i], Encoding.Default);
                        //插入数据库
                        AddContent(pid, name, content);

                        //刷新listbox
                        LoadNameByID(pid);

                    }
                }
            }
            else
            {
                MessageBox.Show("请选中类别");
            }

        }

        private void AddContent(int pid, string name, string content)
        {
            string sql = "insert into ContentInfo (dTId,dName,dContent) values (@pid,@name,@content)";

            SqlParameter[] parameters = new SqlParameter[]{
              new SqlParameter("@pid",SqlDbType.Int)  {Value = pid},
              new SqlParameter("@name",SqlDbType.NVarChar,100){Value=name},
              new SqlParameter("@content",SqlDbType.NVarChar){Value=content}
            };
            SqlHelper.ExecuteNonQuery(sql, parameters);
        }

    }
}
