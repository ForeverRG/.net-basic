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
    public partial class FormDiaryList : Form
    {
        public FormDiaryList()
        {
            InitializeComponent();
        }

        private void FormDiaryList_Load(object sender, EventArgs e)
        {
            //不允许自动添加列
            this.dataGridView1.AutoGenerateColumns = false;
            LoadDiariesToGridView();
        }
        /// <summary>
        /// 加载日记列表
        /// </summary>
        private void LoadDiariesToGridView()
        {
            //获取日记内容
            List<Diary> listDiary = GetDiaries();
            //绑定数据源
            this.dataGridView1.DataSource = listDiary;

        }
        /// <summary>
        /// 获取数据库中所有日记
        /// </summary>
        /// <returns></returns>
        private List<Diary> GetDiaries()
        {
            List<Diary> listD = new List<Diary>();

            string sql = "select id,title,content,createtime,userid,u.loginid from diaryinfo t inner join users u on t.userid=u.autoid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Diary diary = new Diary();
                        diary.Id = reader.GetInt32(0);
                        diary.Title = reader.GetString(1);
                        diary.Content = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        diary.CreateTime = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString();
                        diary.UserID = reader.IsDBNull(1) ? 0 : reader.GetInt32(4);

                        User user = new User();
                        user.LoginID = reader.GetString(5);

                        diary.User = user;

                        listD.Add(diary);
                    }
                }
            }

            return listD;
        }
        /// <summary>
        /// 获取作者名
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetUsername(int p)
        {
            string sql = "select loginId from users where autoid=@id";
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int) { Value = p };

            return (string)SqlHelper.ExecuteScalar(sql, parameter);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //委托实现刷新窗口
            FormRecordDiary frd = new FormRecordDiary(LoadDiariesToGridView);
            frd.Show();

        }
    }
}
