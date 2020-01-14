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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private int _pid;
        private Action flushTreeView;
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        public Form2(int id,Action method)
            : this()
        {
            this.Pid = id;
            this.flushTreeView = method;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into Category values (@tName,@tParentId,@tNote)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tName",SqlDbType.NVarChar,100){Value=this.textBox1.Text.Trim()},
                new SqlParameter("@tParentId",SqlDbType.Int){Value=this.Pid},
                new SqlParameter("@tNote",SqlDbType.NVarChar,1000){Value=this.textBox2.Text.Trim()}
            };

            if (SqlHelper.ExecuteNonQuery(sql, parameters) > 0)
            {
                if (this.flushTreeView != null)
                {
                    this.flushTreeView();
                }

                this.Close();
            }
        }
    }
}
