using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xmf.SHMYSYS.Model
{
    /// <summary>
    /// tbUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class tbUser
    {
        public tbUser()
        { }
        #region Model
        /// <summary>
        /// GUID
        /// </summary>		
        private string _guid;
        public string GUID
        {
            get { return _guid; }
            set { _guid = value; }
        }
        /// <summary>
        /// USERNAME
        /// </summary>		
        private string _username;
        public string USERNAME
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// NICKNAME
        /// </summary>		
        private string _nickname;
        public string NICKNAME
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        /// AVATAR
        /// </summary>		
        private string _avatar;
        public string AVATAR
        {
            get { return _avatar; }
            set { _avatar = value; }
        }
        /// <summary>
        /// PASSWORD
        /// </summary>		
        private string _password;
        public string PASSWORD
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// ROLE
        /// </summary>		
        private string _role;
        public string ROLE
        {
            get { return _role; }
            set { _role = value; }
        }
        /// <summary>
        /// ADDTIME
        /// </summary>		
        private DateTime _addtime;
        public DateTime ADDTIME
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// ISUSE
        /// </summary>		
        private int _isuse;
        public int ISUSE
        {
            get { return _isuse; }
            set { _isuse = value; }
        }
        /// <summary>
        /// SEX
        /// </summary>		
        private int _sex;
        public int SEX
        {
            get { return _sex; }
            set { _sex = value; }
        }
        /// <summary>
        /// PHONE
        /// </summary>		
        private string _phone;
        public string PHONE
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// EMAIL 
        /// </summary>		
        private string _email;
        public string EMAIL
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// ADDRESS 
        /// </summary>		
        private string _address;
        public string ADDRESS
        {
            get { return _address; }
            set { _address = value; }
        }
        #endregion
    }
}
