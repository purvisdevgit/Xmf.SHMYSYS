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
    public partial class gift_list : System.Web.UI.Page
    {
        public List<SQGiftView> giftViews = new List<SQGiftView>();
        public Xmf.SHMYSYS.Model.tbUser user = new Model.tbUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Global.TbUser;
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("audit=1"))
            {
                try
                {
                    string strGuid = Request.Form["chkGuid"];
                    string[] strGuids = strGuid.Split(',');
                    if (strGuids.Length <= 0)
                    {
                        Rms.MESSAGE = "请选择需要审核的礼品！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }

                    tbApply apply = new tbApply();
                    foreach (var guid in strGuids)
                    {
                        if (guid == "")
                        {
                            continue;
                        }
                        Model.tbApply apply1 = apply.GetModel(guid);
                        apply1.AUDITDATE = DateTime.Now;
                        apply1.AUDITNAME = Global.TbUser.EMAIL;
                        apply1.APPLYSTATE = 1; //审核成功
                        apply.AUDITUpdate(apply1);
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
            else if (strQuery.Contains("release=1"))
            {
                try
                {
                    string strGuid = Request.Form["chkGuid"];
                    string[] strGuids = strGuid.Split(',');
                    if (strGuids.Length <= 0)
                    {
                        Rms.MESSAGE = "请选择需要发放的礼品！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }

                    tbApply apply = new tbApply();
                    foreach (var guid in strGuids)
                    {
                        if (guid == "")
                        {
                            continue;
                        }

                        Model.tbApply apply1 = apply.GetModel(guid);
                        //tbGift gift = new tbGift();
                        //Model.tbGift gift1= gift.GetModel(apply1.GIFTGUID);
                        //int giftNum=Convert.ToInt32(gift1.NUMBER);
                        //int applyNum = Convert.ToInt32(apply1.APPLYNUM);
                        //if (applyNum> giftNum)
                        //{
                        //    Rms.MESSAGE = "礼物数量不足！";
                        //    Rms.STATE = STATE.F;
                        //    Rms.SUCCESS = SUCCESS.F;
                        //    Response.Write(JsonConvert.SerializeObject(Rms));
                        //    return;
                        //}
                        //gift1.NUMBER = giftNum - applyNum;
                        //gift.Update(gift1);
                        apply1.RELEASEDATE = DateTime.Now;
                        apply1.RELEASENAME = Global.TbUser.EMAIL;
                        apply1.APPLYSTATE = 2; //发放成功
                        apply.RELEASEUpdate(apply1);
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
                    tbApply apply = new tbApply();
                    apply.Delete(strDelGuid);
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
            else if (strQuery.Contains("delChk"))
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
                    tbApply apply = new tbApply();
                    foreach (var guid in strGuids)
                    {
                        if (guid == "")
                        {
                            continue;
                        }
                        apply.Delete(guid);
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
            else
            {
                if (strQuery.Contains("giftstate=0")) //已申请 显示所有
                {
                    tbApply apply = new tbApply();
                    DataTable dtApply = apply.GetList(string.Format(" APPLYNAME='{0}'", user.EMAIL)).Tables[0];
                    DataView dv = dtApply.DefaultView;
                    dv.Sort = "APPLYDATE DESC";
                    dtApply = dv.ToTable();
                    foreach (DataRow dr in dtApply.Rows)
                    {
                        SQGiftView sQGiftView = new SQGiftView();
                        sQGiftView.GUID = dr["GUID"].ToString();
                        sQGiftView.GIFTGUID = dr["GIFTGUID"].ToString();
                        tbGift gift = new tbGift();
                        //DataSet dsGift = gift.GetList(string.Format(" GUID='{0}'", sQGiftView.GIFTGUID));
                        //if (dsGift.Tables.Count > 0 && dsGift.Tables[0].Rows.Count > 0)
                        //{
                        //    sQGiftView.GIFTNAME = dsGift.Tables[0].Rows[0]["GIFTNAME"].ToString();
                        //    sQGiftView.IMAGE = dsGift.Tables[0].Rows[0]["IMAGE"].ToString();
                        //    sQGiftView.DETAIL = dsGift.Tables[0].Rows[0]["DETAIL"].ToString();
                        //}
                        sQGiftView.GIFTNAME = dr["GIFTNAME"].ToString();
                        sQGiftView.IMAGE = dr["IMAGE"].ToString();
                        sQGiftView.DETAIL = dr["DETAIL"].ToString();
                        sQGiftView.APPLYNUM = dr["APPLYNUM"].ToString();
                        sQGiftView.APPLYNAME = dr["APPLYNAME"].ToString();
                        DateTime tmpTime = new DateTime();
                        if (DateTime.TryParse(dr["APPLYDATE"].ToString(), out tmpTime))
                            sQGiftView.APPLYDATE = Convert.ToDateTime(dr["APPLYDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.AUDITNAME = dr["AUDITNAME"].ToString();
                        if (DateTime.TryParse(dr["AUDITDATE"].ToString(), out tmpTime))
                            sQGiftView.AUDITDATE = Convert.ToDateTime(dr["AUDITDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.RELEASENAME = dr["RELEASENAME"].ToString();
                        if (DateTime.TryParse(dr["RELEASEDATE"].ToString(), out tmpTime))
                            sQGiftView.RELEASEDATE = Convert.ToDateTime(dr["RELEASEDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.APPLYSTATE = dr["APPLYSTATE"].ToString() == "0" ? "未审核" : dr["APPLYSTATE"].ToString() == "1" ? "已审核" : "已发放";
                        sQGiftView.ISUSE = dr["ISUSE"].ToString();
                        sQGiftView.REMARK = dr["REMARK"].ToString();
                        giftViews.Add(sQGiftView);
                    }

                }
                else if (strQuery.Contains("giftstate=1"))//已审核 //显示未审核的
                {
                    tbApply apply = new tbApply();
                    DataTable dtApply = apply.GetList(" APPLYSTATE=0").Tables[0];
                    tbUser userBll = new tbUser();
                    DataTable dtQxUser= userBll.GetList(" SUPERIOR='"+ Global.TbUser.GUID+ "'").Tables[0];
                    DataTable dtApplyAdd = dtApply.Clone();
                    foreach (DataRow dr1 in dtApply.Rows)
                    {
                        foreach (DataRow dr2 in dtQxUser.Rows)
                        {
                            if (dr1["APPLYNAME"].ToString()== dr2["EMAIL"].ToString())
                            {
                                dtApplyAdd.Rows.Add(dr1.ItemArray);
                            }
                        }
                    }
                    DataView dv = dtApplyAdd.DefaultView;
                    dv.Sort = "APPLYDATE DESC";
                    dtApplyAdd = dv.ToTable();
                    foreach (DataRow dr in dtApplyAdd.Rows)
                    {
                        SQGiftView sQGiftView = new SQGiftView();
                        sQGiftView.GUID = dr["GUID"].ToString();
                        sQGiftView.GIFTGUID = dr["GIFTGUID"].ToString();
                        tbGift gift = new tbGift();
                        //DataSet dsGift = gift.GetList(string.Format(" GUID='{0}'", sQGiftView.GIFTGUID));
                        //if (dsGift.Tables.Count > 0 && dsGift.Tables[0].Rows.Count > 0)
                        //{
                        //    sQGiftView.GIFTNAME = dsGift.Tables[0].Rows[0]["GIFTNAME"].ToString();
                        //    sQGiftView.IMAGE = dsGift.Tables[0].Rows[0]["IMAGE"].ToString();
                        //    sQGiftView.DETAIL = dsGift.Tables[0].Rows[0]["DETAIL"].ToString();
                        //}
                        sQGiftView.GIFTNAME = dr["GIFTNAME"].ToString();
                        sQGiftView.IMAGE = dr["IMAGE"].ToString();
                        sQGiftView.DETAIL = dr["DETAIL"].ToString();
                        sQGiftView.APPLYNUM = dr["APPLYNUM"].ToString();
                        sQGiftView.APPLYNAME = dr["APPLYNAME"].ToString();
                        DateTime tmpTime = new DateTime();
                        if (DateTime.TryParse(dr["APPLYDATE"].ToString(), out tmpTime))
                            sQGiftView.APPLYDATE = Convert.ToDateTime(dr["APPLYDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.AUDITNAME = dr["AUDITNAME"].ToString();
                        if (DateTime.TryParse(dr["AUDITDATE"].ToString(), out tmpTime))
                            sQGiftView.AUDITDATE = Convert.ToDateTime(dr["AUDITDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.RELEASENAME = dr["RELEASENAME"].ToString();
                        if (DateTime.TryParse(dr["RELEASEDATE"].ToString(), out tmpTime))
                            sQGiftView.RELEASEDATE = Convert.ToDateTime(dr["RELEASEDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.APPLYSTATE = dr["APPLYSTATE"].ToString() == "0" ? "未审核" : dr["APPLYSTATE"].ToString() == "1" ? "已审核" : "已发放";
                        sQGiftView.ISUSE = dr["ISUSE"].ToString();
                        sQGiftView.REMARK = dr["REMARK"].ToString();
                        giftViews.Add(sQGiftView);
                    }
                }
                else if (strQuery.Contains("giftstate=2"))//已发放 显示已经审核的
                {
                    tbApply apply = new tbApply();
                    DataTable dtApply = apply.GetList(" APPLYSTATE=1").Tables[0];
                    DataView dv = dtApply.DefaultView;
                    dv.Sort = "APPLYDATE DESC";
                    dtApply = dv.ToTable();
                    foreach (DataRow dr in dtApply.Rows)
                    {
                        SQGiftView sQGiftView = new SQGiftView();
                        sQGiftView.GUID = dr["GUID"].ToString();
                        sQGiftView.GIFTGUID = dr["GIFTGUID"].ToString();
                        tbGift gift = new tbGift();
                        //DataSet dsGift = gift.GetList(string.Format(" GUID='{0}'", sQGiftView.GIFTGUID));
                        //if (dsGift.Tables.Count > 0 && dsGift.Tables[0].Rows.Count > 0)
                        //{
                        //    sQGiftView.GIFTNAME = dsGift.Tables[0].Rows[0]["GIFTNAME"].ToString();
                        //    sQGiftView.IMAGE = dsGift.Tables[0].Rows[0]["IMAGE"].ToString();
                        //    sQGiftView.DETAIL = dsGift.Tables[0].Rows[0]["DETAIL"].ToString();
                        //}
                        sQGiftView.GIFTNAME = dr["GIFTNAME"].ToString();
                        sQGiftView.IMAGE = dr["IMAGE"].ToString();
                        sQGiftView.DETAIL = dr["DETAIL"].ToString();
                        sQGiftView.APPLYNUM = dr["APPLYNUM"].ToString();
                        sQGiftView.APPLYNAME = dr["APPLYNAME"].ToString();
                        DateTime tmpTime = new DateTime();
                        if (DateTime.TryParse(dr["APPLYDATE"].ToString(), out tmpTime))
                            sQGiftView.APPLYDATE = Convert.ToDateTime(dr["APPLYDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.AUDITNAME = dr["AUDITNAME"].ToString();
                        if (DateTime.TryParse(dr["AUDITDATE"].ToString(), out tmpTime))
                            sQGiftView.AUDITDATE = Convert.ToDateTime(dr["AUDITDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.RELEASENAME = dr["RELEASENAME"].ToString();
                        if (DateTime.TryParse(dr["RELEASEDATE"].ToString(), out tmpTime))
                            sQGiftView.RELEASEDATE = Convert.ToDateTime(dr["RELEASEDATE"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                        sQGiftView.APPLYSTATE = dr["APPLYSTATE"].ToString() == "0" ? "未审核" : dr["APPLYSTATE"].ToString() == "1" ? "已审核" : "已发放";
                        sQGiftView.ISUSE = dr["ISUSE"].ToString();
                        sQGiftView.REMARK = dr["REMARK"].ToString();
                        giftViews.Add(sQGiftView);
                    }
                }

            }
        }
        public class SQGiftView
        {
            /// <summary>
            /// 唯一键
            /// </summary>
            public string GUID { get; set; }
            /// <summary>
            /// 礼物GUID
            /// </summary>
            public string GIFTGUID { get; set; }
            /// <summary>
            /// 礼物名
            /// </summary>
            public string GIFTNAME { get; set; }
            /// <summary>
            /// 缩略图
            /// </summary>
            public string IMAGE { get; set; }
            /// <summary>
            /// 详情
            /// </summary>
            public string DETAIL { get; set; }
            /// <summary>
            /// 申请数量
            /// </summary>
            public string APPLYNUM { get; set; }
            ///申请人
            public string APPLYNAME { get; set; }
            /// <summary>
            /// 申请日期
            /// </summary>
            public string APPLYDATE { get; set; }
            /// <summary>
            /// 审核人
            /// </summary>
            public string AUDITNAME { get; set; }
            /// <summary>
            /// 审核日期
            /// </summary>
            public string AUDITDATE { get; set; }
            /// <summary>
            /// 发放人
            /// </summary>
            public string RELEASENAME { get; set; }
            /// <summary>
            /// 发放日期
            /// </summary>
            public string RELEASEDATE { get; set; }
            /// <summary>
            /// 申请状态
            /// </summary>
            public string APPLYSTATE { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            public string REMARK { get; set; }
            /// <summary>
            /// 是否使用
            /// </summary>
            public string ISUSE { get; set; }
        }
    }
}