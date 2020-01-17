using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 日记系统
{
    class User
    {
        private int _autoID;

        public int AutoID
        {
            get { return _autoID; }
            set { _autoID = value; }
        }

        private string _loginID;

        public string LoginID
        {
            get { return _loginID; }
            set { _loginID = value; }
        }

        private string _loginPwd;

        public string LoginPwd
        {
            get { return _loginPwd; }
            set { _loginPwd = value; }
        }

        public override string ToString()
        {
            return this.LoginID;
        }
    }
}
