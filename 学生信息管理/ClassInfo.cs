using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 学生信息管理
{
    class ClassInfo
    {
        //班级id
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //班级名称
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //班级描述
        private string _des;

        public string Des
        {
            get { return _des; }
            set { _des = value; }
        }
    }
}
