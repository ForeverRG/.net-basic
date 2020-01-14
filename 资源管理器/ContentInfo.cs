using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 资源管理器
{
    class ContentInfo
    {
        private string _dName;
        private int _dId;

        public int DId
        {
            get { return _dId; }
            set { _dId = value; }
        }

        public string DName
        {
            get { return _dName; }
            set { _dName = value; }
        }

        public override string ToString()
        {
            return DName;
        }
    }
}
