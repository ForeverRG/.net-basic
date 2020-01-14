using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 资源管理器
{
    class CategoryInfo
    {
        private int _tId;

        public int TId
        {
            get { return _tId; }
            set { _tId = value; }
        }

        private string _tName;

        public string TName
        {
            get { return _tName; }
            set { _tName = value; }
        }

        private int _tParentId;

        public int TParentId
        {
            get { return _tParentId; }
            set { _tParentId = value; }
        }

        private string _tNote;

        public string TNote
        {
            get { return _tNote; }
            set { _tNote = value; }
        }
    }
}
