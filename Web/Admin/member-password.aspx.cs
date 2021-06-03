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
    public partial class member_password : System.Web.UI.Page
    {
        public Model.tbUser user = new Model.tbUser();
        private tbUser user1 = new tbUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("guid="))
            {
                string strParam = strQuery.Split('=')[1];
                user = user1.GetModel(strParam);

            }
            else if (strQuery.Contains("alterpwd=1"))
            {
                try
                {
                    string strGuid = Request.Form["guid"];
                    string strOldrepass = Request.Form["L_oldrepass"];
                    string strPass = Request.Form["L_pass"];
                    string StrRepass = Request.Form["L_repass"];
                    Model.tbUser Nuser = user1.GetModel(strGuid);
                    if (Nuser.PASSWORD != strOldrepass)
                    {
                        Rms.SUCCESS = SUCCESS.F;
                        Rms.STATE = STATE.F;
                        Rms.MESSAGE = "旧密码不正确，请重试！";
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    if (strPass != StrRepass)
                    {
                        Rms.SUCCESS = SUCCESS.F;
                        Rms.STATE = STATE.F;
                        Rms.MESSAGE = "两次新密码输入不一致、请重试！";
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    if (StrRepass.Length < 6)
                    {
                        Rms.SUCCESS = SUCCESS.F;
                        Rms.STATE = STATE.F;
                        Rms.MESSAGE = "新密码强度不够、请输入6位以上密码！";
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    Nuser.PASSWORD = StrRepass;
                    user1.Update(Nuser);
                    Rms.SUCCESS = SUCCESS.T;
                    Rms.STATE = STATE.T;
                    Rms.MESSAGE = "成功！";
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
        }
    }
}