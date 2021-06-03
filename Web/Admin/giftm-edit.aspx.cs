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
    public partial class giftm_edit : System.Web.UI.Page
    {
        public Model.tbGift mGift = new Model.tbGift();
        public List<Model.tbGift> tbGifts = new List<Model.tbGift>();
        private tbGift gift = new tbGift();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("guid="))
            {
                string strParam = strQuery.Split('=')[1];
                mGift = gift.GetModel(strParam);

            }
            else if (strQuery.Contains("edit=1"))
            {
                try
                {
                    string strGuid = Request.Form["guid"];
                    string strGiftName = Request.Form["giftname"];
                    string strSltSrc = Request.Form["sltsrc"];
                    string strNumber = Request.Form["number"];
                    string strDetail = Request.Form["detail"];
                    int INum = 0;
                    if (!int.TryParse(strNumber.Trim(), out INum))
                    {
                        Rms.MESSAGE = "数量转换失败！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    tbGift gift1 = new tbGift();
                    Model.tbGift gift = gift1.GetModel(strGuid);
                    gift.GIFTNAME = strGiftName;
                    gift.IMAGE = strSltSrc;
                    gift.NUMBER = INum;
                    gift.DETAIL = strDetail;
                    gift1.Update(gift);
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
        }
    }
}