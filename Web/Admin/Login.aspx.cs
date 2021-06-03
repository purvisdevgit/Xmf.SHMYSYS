using Maticsoft.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.DAL;
using Xmf.SHMYSYS.Model;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUsername = Request.Form["username"];
            string strPass = Request.Form["pass"];
            if (!string.IsNullOrEmpty(strUsername) && !string.IsNullOrEmpty(strPass))
            {
                #region 登录锁定
                //if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                //{
                //    int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                //    if (PassErroeCount > 3)
                //    {
                //        //txtUsername.Disabled = true;
                //        //txtPass.Disabled = true;
                //        //btnLogin.Enabled = false;
                //        //this.lblMsg.Text = "对不起，你错误登录了三次，系统登录锁定！";
                //        ReturnMsg rmsg = new ReturnMsg();
                //        rmsg.DATA = null;
                //        rmsg.MESSAGE = "对不起，你错误登录了三次，系统登录锁定！";
                //        rmsg.STATE = STATE.F;
                //        rmsg.SUCCESS = SUCCESS.F;
                //        Response.Write(JsonConvert.SerializeObject(rmsg));
                //        Response.End();
                //        return;
                //    }
                //}

                #endregion
                string userName = Maticsoft.Common.PageValidate.InputText(strUsername.Trim(), 30);
                string Password = Maticsoft.Common.PageValidate.InputText(strPass.Trim(), 30);
                //验证登录信息，如果验证通过则返回当前用户对象的安全上下文信息

                tbUser newUser = SysManage.ValidateLogin(userName, Password);
                if (newUser == null)//登录信息不对
                {
                    //this.lblMsg.Text = "登陆失败： " + userName;
                    if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                    {
                        int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                        Session["PassErrorCountAdmin"] = PassErroeCount + 1;
                    }
                    else
                    {
                        Session["PassErrorCountAdmin"] = 1;
                    }
                    ReturnMsg rmsg = new ReturnMsg();
                    rmsg.DATA = newUser;
                    rmsg.MESSAGE =  userName+"邮箱或密码错误！";
                    rmsg.STATE = STATE.F;
                    rmsg.SUCCESS = SUCCESS.F;
                    Response.Write(JsonConvert.SerializeObject(rmsg));
                    Response.End();
                }
                else
                {
                    //if (currentUser.UserType != "AA")
                    //{
                    //    this.lblMsg.Text = "你非管理员用户，你没有权限登录后台系统！";
                    //    return;
                    //}

                    //把当前用户对象实例赋给Context.User，这样做将会把完整的用户信息加载到ASP.NET提供的验证体系中
                    //Context.User = newUser;
                    //验证当前用户密码
                    //密码为空 或者 账号禁用
                    if (newUser.PASSWORD.ToString().Trim().Length == 0 || newUser.ISUSE == 0)
                    {
                        //this.lblMsg.Text = "你的密码无效！";
                        if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
                        {
                            int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
                            Session["PassErrorCountAdmin"] = PassErroeCount + 1;
                        }
                        else
                        {
                            Session["PassErrorCountAdmin"] = 1;
                        }
                        ReturnMsg rmsg = new ReturnMsg();
                        rmsg.DATA = newUser;
                        if (newUser.PASSWORD.ToString().Trim().Length == 0)
                        {

                            rmsg.MESSAGE = "密码为空！";
                        }
                        else if (newUser.ISUSE == 0)
                        {
                            rmsg.MESSAGE = "用户被禁用！";
                        }
                        else {
                            rmsg.MESSAGE = "错误！";
                        }
                        rmsg.STATE = STATE.F;
                        rmsg.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(rmsg));
                        Response.End();
                    }
                    else
                    {
                        //保存当前用户对象信息
                        FormsAuthentication.SetAuthCookie(userName, false);
                        Session["UserInfo"] = newUser;
                        Session["GUID"] = newUser.GUID;
                        ReturnMsg rmsg = new ReturnMsg();
                        rmsg.DATA = newUser;
                        rmsg.MESSAGE = "成功";
                        rmsg.STATE = STATE.T;
                        rmsg.SUCCESS = SUCCESS.T;
                        Response.Write(JsonConvert.SerializeObject(rmsg));
                        Response.End();
                    }
                }
            }
        }
    }
}