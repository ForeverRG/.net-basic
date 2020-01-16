using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 电话本管理程序
{
    class PhoneNumber
    {
        private string _name;
        private string _cellphone;
        private string _homephone;
        private int _id;
        private int _typeId;

        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        private PhoneType _pt;

        public PhoneType Pt
        {
            get { return _pt; }
            set { _pt = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
       
        public string Homephone
        {
            get { return _homephone; }
            set { _homephone = value; }
        } 

        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
    }
}
