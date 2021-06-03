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
    public partial class MyInfo : System.Web.UI.Page
    {
        public List<Model.tbRole> tbRoles = new List<Model.tbRole>();
        private tbRole role = new tbRole();
        public Model.tbUser user = new Model.tbUser();
        private tbUser user1 = new tbUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("edit=1"))
            {
                try
                {
                    string strGuid = Request.Form["guid"];
                    string strUsername = Request.Form["username"];
                    string strNickname = Request.Form["nickname"];
                    string strAvatarfile = Request.Form["avatarfile"];
                    string strRole = Request.Form["role"];
                    string strSex = Request.Form["sex"];
                    string strPhone = Request.Form["phone"];
                    string strEmail = Request.Form["email"];
                    string strAddress = Request.Form["address"];
                    tbUser user1 = new tbUser();
                    Model.tbUser user = user1.GetModel(strGuid);
                    user.USERNAME = strUsername;
                    user.NICKNAME = strNickname;
                    user.AVATAR = strAvatarfile;
                    user.SEX = Convert.ToInt32(strSex);
                    user.PHONE = strPhone;
                    user.EMAIL = strEmail;
                    user.ADDRESS = strAddress;
                    user.ROLE = strRole;
                    user.ADDRESS = strAddress;
                    user.ADDTIME = DateTime.Now;
                    user.ISUSE = 1;
                    user1.Update(user);
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
            else if (strQuery.Contains("guid="))
            {
                string strParam = strQuery.Split('=')[1];
                user = user1.GetModel(strParam);
                tbRoles = role.GetModelList(" 1=1");

            }
        }

    }
}