using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 电话本管理程序
{
    class PhoneType
    {
        private int _id;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
