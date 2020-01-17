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

namespace 日记系统
{
    public partial class FormRecordDiary : Form
    {
        public FormRecordDiary()
        {
            InitializeComponent();
        }

        public Action _getMethod;

        public FormRecordDiary(Action method)
            : this()
        {
            _getMethod = method;
        }

        private void FormRecordDiary_Load(object sender, EventArgs e)
        {
            //加载所有作者
            LoadAuthor();
        }
        /// <summary>
        /// 加载所有作者到下拉列表
        /// </summary>
        private void LoadAuthor()
        {
            //获取所有作者
            List<User> listUser = GetAllUser();
            //加载到列表
            this.comboBox1.DataSource = listUser;
        }

        private List<User> GetAllUser()
        {
            List<User> listU = new List<User>();

            string sql = "select autoid,loginid,loginpwd from users";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.AutoID = reader.GetInt32(0);
                        user.LoginID = reader.GetString(1);
                        user.LoginPwd = reader.GetString(2);

                        listU.Add(user);
                    }
                }
            }
            return listU;
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //获取标题，内容，添加时间，作者id
            string title = this.textBox1.Text.Trim();
            string content = this.textBoxContent.Text.Trim();
            DateTime datetime = DateTime.Now;
            User user = this.comboBox1.SelectedItem as User;
            if (user != null)
            {
                //添加日志
                AddDiary(title, content, datetime, user.AutoID);
            }
            //更新主窗体日记列表
            this._getMethod();
            //清除窗口
            this.textBox1.Text = string.Empty;
            this.textBoxContent.Text = string.Empty;
        }
        /// <summary>
        /// 数据库表中插入日志
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="datetime"></param>
        /// <param name="p"></param>
        private void AddDiary(string title, string content, DateTime datetime, int p)
        {
            string sql = "insert into DiaryInfo(title,content,createtime,userid) values(@title,@content,@datetime,@userid)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@title",SqlDbType.NVarChar,50){Value=title},
                new SqlParameter("@content",SqlDbType.NVarChar,500){Value=content},
                new SqlParameter("@datetime",SqlDbType.DateTime){Value=datetime},
                new SqlParameter("@userid",SqlDbType.Int){Value=p}
            };

            SqlHelper.ExecuteNoQuery(sql, parameters);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
