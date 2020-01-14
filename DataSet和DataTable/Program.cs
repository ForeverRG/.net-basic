using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSet和DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建内存数据库
            DataSet dataset = new DataSet("Class");
            //创建数据表
            DataTable datatable = new DataTable("student");
            //创建列
            DataColumn dcID = new DataColumn("id", typeof(int));
            dcID.AutoIncrement = true;
            dcID.AutoIncrementSeed = 1;
            dcID.AutoIncrementStep = 1;

            DataColumn dcName = new DataColumn("name", typeof(string));
            dcName.AllowDBNull = false;

            DataColumn dcAge = new DataColumn("age", typeof(int));

            //向表中添加列
            datatable.Columns.Add(dcID);
            datatable.Columns.Add(dcName);
            datatable.Columns.Add(dcAge);

            //向表中添加数据
            DataRow dr1 = datatable.NewRow();
            dr1["name"] = "路人甲";
            dr1["age"] = 18;
            datatable.Rows.Add(dr1);

            DataRow dr2 = datatable.NewRow();
            dr2["name"] = "路人乙";
            dr2["age"] = 19;
            datatable.Rows.Add(dr2);


            //将表添加到内存数库中
            dataset.Tables.Add(datatable);

            //获取内存数据库中的表数据
            for (int i = 0; i < dataset.Tables.Count; i++)
            {
                for (int j = 0; j < dataset.Tables[i].Rows.Count; j++)
                {
                    for (int k = 0; k < dataset.Tables[i].Columns.Count; k++)
                    {
                        Console.WriteLine(dataset.Tables[i].Rows[j][k]);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
