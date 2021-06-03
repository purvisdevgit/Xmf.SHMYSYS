using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xmf.SHMYSYS.BLL;
using Xmf.SHMYSYS.DAL;

namespace Xmf.SHMYSYS.Web.Admin
{
    public partial class gift_maintain : System.Web.UI.Page
    {
        public List<GiftView> giftViews = new List<GiftView>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("delChk"))
            {
                try
                {
                    string strGuid = Request.Form["chkGuid"];
                    string[] strGuids = strGuid.Split(',');
                    if (strGuids.Length <= 1)
                    {
                        Rms.MESSAGE = "请选择需要删除的礼品！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    tbGift gift = new tbGift();
                    foreach (var guid in strGuids)
                    {
                        if (guid == "")
                        {
                            continue;
                        }
                        gift.Delete(guid);
                    }
                    Rms.MESSAGE = "成功！";
                    Rms.STATE = STATE.T;
                    Rms.SUCCESS = SUCCESS.T;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;
                }
                catch (Exception ex)
                {
                    Rms.MESSAGE = ex.Message;
                    Rms.STATE = STATE.F;
                    Rms.SUCCESS = SUCCESS.F;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;
                }
                finally
                {
                    Response.End();
                }
            }
            else if (strQuery.Contains("delid="))
            {
                try
                {
                    string strDelGuid = strQuery.Split('=')[1].ToString();
                    tbGift gift = new tbGift();
                    gift.Delete(strDelGuid);
                    Rms.MESSAGE = "成功！";
                    Rms.STATE = STATE.T;
                    Rms.SUCCESS = SUCCESS.T;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;

                }
                catch (Exception ex)
                {
                    Rms.MESSAGE = ex.Message;
                    Rms.STATE = STATE.F;
                    Rms.SUCCESS = SUCCESS.F;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;
                }
                finally
                {
                    Response.End();
                }
            }
            else if (strQuery.Contains("qyguid=")|| strQuery.Contains("jyguid="))//启用 禁用
            {
                try
                {
                    string strGuid = strQuery.Split('=')[1].ToString();
                    tbGift gift = new tbGift();
                    Model.tbGift gift1= gift.GetModel(strGuid);
                    if (strQuery.Contains("qyguid="))
                    {
                        gift1.ISUSE = 1;
                    }
                    else {
                        gift1.ISUSE = 0;
                    }
                    gift.Update(gift1);
                    Rms.MESSAGE = "成功！";
                    Rms.STATE = STATE.T;
                    Rms.SUCCESS = SUCCESS.T;
                    Response.Write(JsonConvert.SerializeObject(Rms));
                    return;

                }
                catch (Exception ex)
                {
                    Rms.MESSAGE = ex.Message;
                    Rms.STATE = STATE.F;
                    Rms.SUCCESS = SUCCESS.F;
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
                tbGift gift = new tbGift();
                DataTable dataTable = gift.GetAllList().Tables[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    GiftView giftView = new GiftView();
                    giftView.GUID = row["GUID"].ToString();
                    giftView.GIFTNAME = row["GIFTNAME"].ToString();
                    giftView.IMAGE = row["IMAGE"].ToString();
                    giftView.NUMBER = row["NUMBER"].ToString();
                    giftView.DETAIL = row["DETAIL"].ToString();
                    giftView.ADDTIME = Convert.ToDateTime(row["ADDTIME"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                    giftView.ISUSE = row["ISUSE"].ToString() == "1" ? "已启用" : "未启用";
                    giftViews.Add(giftView);
                }
            }
        }
    }
    public class GiftView
    {
        public string GUID { get; set; }
        public string GIFTNAME { get; set; }
        public string IMAGE { get; set; }
        public string NUMBER { get; set; }
        public string DETAIL { get; set; }
        public string ADDTIME { get; set; }
        public string ISUSE { get; set; }
    }
}