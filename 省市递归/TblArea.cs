using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 省市递归
{
    class TblArea
    {
        public TblArea() { }

        private int _areaId;

        public int AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        private string _areaName;

        public string AreaName
        {
            get { return _areaName; }
            set { _areaName = value; }
        }
        //重写tostring方法，返回地区名称
        public override string ToString()
        {
            return AreaName;
        }
    }
}
