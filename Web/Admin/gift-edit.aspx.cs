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
    public partial class gift_edit : System.Web.UI.Page
    {
        public Model.tbGift mGift = new Model.tbGift();
        public Model.tbApply mApply = new Model.tbApply();
        public List<Model.tbGift> tbGifts = new List<Model.tbGift>();
        private tbGift gift = new tbGift();
        private tbApply apply = new tbApply();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("guid="))
            {
                string strParam = strQuery.Split('=')[1];
                mApply = apply.GetModel(strParam);
                mGift = gift.GetModel(mApply.GIFTGUID);
                tbGifts = gift.GetModelList(" 1=1");

            }
            else if (strQuery.Contains("edit=1"))
            {
                try
                {
                    string strGuid = Request.Form["guid"];
                    string strGiftguid = Request.Form["giftguid"];
                    string strApplynum = Request.Form["applynum"];
                    string strRemark = Request.Form["remark"];
                    int INum = 0;
                    if (!int.TryParse(strApplynum.Trim(), out INum))
                    {
                        Rms.MESSAGE = "数量转换失败！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    tbApply apply1 = new tbApply();
                    Model.tbApply apply=  apply1.GetModel(strGuid);
                    apply.GIFTGUID = strGiftguid;
                    apply.APPLYNUM = INum;
                    apply.APPLYNAME = Global.TbUser.USERNAME;
                    apply.APPLYSTATE = 0; //流程1 申请  0   审核 1 配发 2
                    apply.APPLYDATE = DateTime.Now;
                    apply.ISUSE = 1;
                    apply.REMARK = strRemark;
                    apply1.Update(apply);
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