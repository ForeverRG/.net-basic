using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 地区表分页显示
{
    class DicRegion
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _grade;

        public int Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        private string _parentId;

        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _descriptionEng;

        public string DescriptionEng
        {
            get { return _descriptionEng; }
            set { _descriptionEng = value; }
        }
        private int _orderNo;

        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private string _mapBarName;

        public string MapBarName
        {
            get { return _mapBarName; }
            set { _mapBarName = value; }
        }
        private decimal _lng;

        public decimal Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        private decimal _lat;

        public decimal Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        private string _abbr;

        public string Abbr
        {
            get { return _abbr; }
            set { _abbr = value; }
        }
        private string _areaCode;

        public string AreaCode
        {
            get { return _areaCode; }
            set { _areaCode = value; }
        }
        private bool _isUsed;

        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; }
        }
        private bool _isDel;

        public bool IsDel
        {
            get { return _isDel; }
            set { _isDel = value; }
        }
        private string _firstLetter;

        public string FirstLetter
        {
            get { return _firstLetter; }
            set { _firstLetter = value; }
        }

    }
}
