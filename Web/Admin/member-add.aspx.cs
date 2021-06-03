using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.BLL;
using Xmf.SHMYSYS.DAL;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class member_add : System.Web.UI.Page
    {
        public List<Model.tbRole> tbRoles = new List<Model.tbRole>();
        private tbRole role = new tbRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("add=1"))
            {
                try
                {
                    string strUsername = Request.Form["username"];
                    string strNickname = Request.Form["nickname"];
                    string strAvatarfile = Request.Form["avatarfile"];
                    string strRole = Request.Form["role"];
                    string strSex = Request.Form["sex"];
                    string strPhone = Request.Form["phone"];
                    string strEmail = Request.Form["email"];
                    string strAddress = Request.Form["address"];
                    string strPassword = Request.Form["password"];
                    Model.tbUser user = new Model.tbUser();
                    user.GUID = Guid.NewGuid().ToString("B");
                    user.USERNAME = strUsername;
                    user.NICKNAME = strNickname;
                    user.AVATAR = strAvatarfile;
                    user.PASSWORD = strPassword;
                    user.SEX = Convert.ToInt32(strSex);
                    user.PHONE = strPhone;
                    user.EMAIL = strEmail;
                    user.ADDRESS = strAddress;
                    user.ROLE = strRole;
                    user.ADDRESS = strAddress;
                    user.ADDTIME = DateTime.Now;
                    user.ISUSE = 1;
                    tbUser user1 = new tbUser();
                    if(user1.GetList(string.Format(" EMAIL = '{0}'", strEmail)).Tables[0].Rows.Count > 0){
                        Rms.SUCCESS = SUCCESS.F;
                        Rms.STATE = STATE.F;
                        Rms.MESSAGE = "邮箱已经存在";
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    user1.Add(user);
                    Rms.SUCCESS = SUCCESS.T;
                    Rms.STATE = STATE.T;
                    Rms.MESSAGE = "成功";
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;
                }
                catch (Exception ex)
                {
                    Rms.SUCCESS = SUCCESS.F;
                    Rms.STATE = STATE.F;
                    Rms.MESSAGE = ex.Message;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;
                }
                finally
                {
                    Response.End();
                }
            }
            else
            {
                tbRoles = role.GetModelList(" 1=1");
            }
        }
    }
}