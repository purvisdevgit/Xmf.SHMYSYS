using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.Model;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class yg_index : System.Web.UI.Page
    {

        public tbUser TbUser = new tbUser();
        public List<Model.tbGift> tbGifts = new List<Model.tbGift>();
        private Xmf.SHMYSYS.BLL.tbGift gift = new Xmf.SHMYSYS.BLL.tbGift();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {

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
                    tbGifts = gift.GetModelList(" ISUSE=1");


                }

            }
        }
    }
}