using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.DAL;
using Xmf.SHMYSYS.Model;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class giftm_add : System.Web.UI.Page
    {
        private Xmf.SHMYSYS.BLL.tbGift gift = new Xmf.SHMYSYS.BLL.tbGift();

        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();

            string strQuery = HttpContext.Current.Request.Url.Query;
            //if (strQuery.Length > 0)//编辑
            //{
            //    string[] strParam = strQuery.Split('&');
            //}
            //else
            //{ //新增
            if (strQuery.Length > 0 && strQuery.Contains("add=1"))//编辑
            {
                try
                {
                    string strGiftname = Request.Form["giftname"];
                    string strFile = Request.Form["file"];
                    string strNum = Request.Form["num"];
                    string strDetails = Request.Form["details"];
                    #region 验证
                    if (strGiftname.Trim().Length <= 0)
                    {
                        Rms.MESSAGE = "名称不能为空！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    else if (strNum.Trim().Length <= 0)
                    {
                        Rms.MESSAGE = "数量不能为空！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    int INum = 0;
                    if (!int.TryParse(strNum.Trim(), out INum))
                    {
                        Rms.MESSAGE = "数量转换失败！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    #endregion
                    tbGift TbGift = new tbGift();
                    TbGift.ADDTIME = DateTime.Now;
                    TbGift.DETAIL = strDetails;
                    TbGift.GIFTNAME = strGiftname;
                    TbGift.GUID = Guid.NewGuid().ToString("B");
                    TbGift.IMAGE = strFile;
                    TbGift.ISUSE = 1;
                    TbGift.NUMBER = Convert.ToInt32(strNum);
                    gift.Add(TbGift);
                    Rms.MESSAGE = "新增成功！";
                    Rms.STATE = STATE.T;
                    Rms.SUCCESS = SUCCESS.T;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    //}



                }
                catch (Exception ex)
                {
                    Rms.MESSAGE = ex.Message;
                    Rms.STATE = STATE.F;
                    Rms.SUCCESS = SUCCESS.F;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                }
                finally
                {
                    Response.End();
                }
            }
        }
    }
}