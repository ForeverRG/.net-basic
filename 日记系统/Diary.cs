using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日记系统
{
    class Diary
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        private string _createTime;

        public string CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
