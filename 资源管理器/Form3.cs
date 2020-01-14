using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 省市递归;

namespace 资源管理器
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string sql = "select * from TblClass";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);

            this.dataGridView1.DataSource = dt;
        }
    }
}
