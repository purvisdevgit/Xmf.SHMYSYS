using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xmf.SHMYSYS.DAL
{
    public class ReturnMsg
    {
        private string _success;
        private string _message;
        private string _state;
        private object _data;

        public string SUCCESS
        {
            set { _success = value; }
            get { return _success; }
        }
        public string MESSAGE
        {
            set { _message = value; }
            get { return _message; }
        }

        public string STATE
        {
            set { _state = value; }
            get { return _state; }
        }
        public object DATA
        {
            set { _data = value; }
            get { return _data; }
        }
    }
    public static class SUCCESS
    {
        public static string T = "true";
        public static string F = "false";
    }
    public static class STATE
    {
        public static string T = "1";
        public static string F = "0";
    }
}
