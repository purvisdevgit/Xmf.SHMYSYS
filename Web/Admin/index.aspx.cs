using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.Model;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class index : System.Web.UI.Page
    {
        public tbUser TbUser = new tbUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {
                string strQuery = HttpContext.Current.Request.Url.Query;
                strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
                if (Session["GUID"] == null || string.IsNullOrEmpty(Session["GUID"].ToString()))
                {
                    Response.Clear();
                    Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');history.back();</script>");
                    Response.End();
                }
                else
                { //取到了Session
                    if (string.IsNullOrEmpty(TbUser.GUID))
                    {
                        TbUser = (tbUser)Session["UserInfo"];
                        Global.TbUser = TbUser;
                    }
                    if (!strQuery.Contains("op=grxx"))
                    {
                        if (TbUser.ROLE == "{1261305D-F882-44FE-9F0B-3E7D37DBEBD6}")
                        { //员工
                            Response.Redirect("yg-index.aspx");
                        }
                    }

                }

            }

        }
    }
}