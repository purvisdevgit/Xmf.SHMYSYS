using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.BLL;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class gift_detail : System.Web.UI.Page
    {
        public Xmf.SHMYSYS.Model.tbUser user = new Model.tbUser();
        private tbGift gift = new tbGift();
        public Model.tbGift vgift = new Model.tbGift();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Global.TbUser;
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("giftguid="))
            {
                try
                {
                    string strGiftGuid = strQuery.Split('=')[1].ToString();
                    vgift = gift.GetModel(strGiftGuid);
                    return;
                }
                catch (Exception ex)
                {
                    return;
                }
                //finally
                //{
                //    Response.End();
                //}
            }
        }
    }
}