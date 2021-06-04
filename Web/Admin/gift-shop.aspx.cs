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
    public partial class gift_shop : System.Web.UI.Page
    {
        public Xmf.SHMYSYS.Model.tbUser user = new Model.tbUser();
        public tbGift gift = new tbGift();
        private tbGiftTemp giftTemp = new tbGiftTemp();
        public Model.tbGift vgift = new Model.tbGift();
        public List<Model.tbGiftTemp> tbGiftTemps = new List<Model.tbGiftTemp>();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Global.TbUser;
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            ReturnMsg Rms = new ReturnMsg();
            if (strQuery.Contains("op=numchange")) //数字改变
            {
                try
                {
                    string[] strParam = strQuery.Split('&');
                    string strGuid = strParam[1].Split('=')[1].ToString();
                    string strApplyNum = strParam[2].Split('=')[1].ToString();
                    int INum = 0; //新数量
                    if (!int.TryParse(strApplyNum.Trim(), out INum)|| INum==0)
                    {
                        ;
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        if (INum == 0)
                        {
                            Rms.MESSAGE = "申请数量不能为0！";
                        }
                        else if (strApplyNum.Trim() != "")
                        {
                            Rms.MESSAGE = "数量转换失败！";

                        }
                        else {
                            Rms.MESSAGE = "请填写数量！";
                        }
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    List<Model.tbGiftTemp> giftTemps = giftTemp.GetModelList(string.Format(" guid='{0}'", strGuid));
                    if (giftTemps.Count > 0)
                    {
                        Model.tbGiftTemp giftTemp1 = giftTemps[0];
                        string strGiftGuid = giftTemp1.GIFTGUID;
                        int GiftOldNum = Convert.ToInt32(giftTemp1.APPLYNUM); //老数量
                        Model.tbGift gift1 = gift.GetModel(strGiftGuid);
                        int GiftNum = 0; //礼品数量
                        int.TryParse(gift1.NUMBER.ToString(), out GiftNum);
                        if ((INum - GiftOldNum) > GiftNum)
                        {
                            giftTemp1.APPLYNUM = GiftNum+ GiftOldNum;
                            giftTemp.Update(giftTemp1);
                            gift1.NUMBER = GiftNum - GiftNum;
                            gift.Update(gift1);
                            Rms.MESSAGE = "礼品数量不足，最终提交将按最大库存计算！";
                            Rms.STATE = STATE.F;
                            Rms.SUCCESS = SUCCESS.F;
                            Response.Write(JsonConvert.SerializeObject(Rms));
                            return;
                        }
                        giftTemp1.APPLYNUM = INum;
                        giftTemp.Update(giftTemp1);
                        gift1.NUMBER = GiftNum - (INum - GiftOldNum);
                        gift.Update(gift1);
                        Rms.MESSAGE = "成功！";
                        Rms.STATE = STATE.T;
                        Rms.SUCCESS = SUCCESS.T;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }

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
            else if (strQuery.Contains("op=delgift"))//删除
            {
                try
                {
                    string[] strParam = strQuery.Split('&');
                    string strGuid = strParam[1].Split('=')[1].ToString();
                    List<Model.tbGiftTemp> giftTemps = giftTemp.GetModelList(string.Format(" guid='{0}'", strGuid));
                    if (giftTemps.Count > 0)
                    {
                        Model.tbGiftTemp giftTemp1 = giftTemps[0];
                        string giftguid = giftTemp1.GIFTGUID;
                        Model.tbGift gift1 = gift.GetModel(giftguid);
                        gift1.NUMBER = gift1.NUMBER + giftTemp1.APPLYNUM;
                        gift.Update(gift1);
                    }
                    giftTemp.Delete(strGuid);
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
            else if (strQuery.Contains("op=submit")) //提交
            {
                try
                {
                    List<Model.tbGiftTemp> giftTemps = giftTemp.GetModelList(string.Format(" userguid='{0}'", user.GUID)); //获取到需要提交的礼品
                    tbApply apply1 = new tbApply();
                    foreach (var gifttemp in giftTemps)
                    {
                        Model.tbApply apply = new Model.tbApply();
                        apply.GUID = Guid.NewGuid().ToString("B");
                        apply.GIFTGUID = gifttemp.GIFTGUID;
                        apply.APPLYNUM = gifttemp.APPLYNUM;
                        apply.APPLYNAME = gifttemp.APPLYNAME;
                        apply.APPLYSTATE = 0; //流程1 申请  0   审核 1 配发 2
                        apply.APPLYDATE = DateTime.Now;
                        apply.ISUSE = 1;
                        apply.REMARK = "";
                        apply.GIFTNAME = gifttemp.GIFTNAME;
                        apply.IMAGE = gifttemp.IMAGE;
                        apply.DETAIL = gifttemp.DETAIL;
                        if (apply1.Add(apply))
                        {
                            giftTemp.Delete(gifttemp.GUID);
                        }
                    }

                    Rms.SUCCESS = SUCCESS.T;
                    Rms.STATE = STATE.T;
                    Rms.MESSAGE = "成功";
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
            else if (strQuery.Contains("giftguid="))//添加
            {
                try
                {
                    string strGiftGuid = strQuery.Split('=')[1].ToString();
                    vgift = gift.GetModel(strGiftGuid);
                    if (giftTemp.GetModelList(string.Format(" userguid='{0}' and giftguid='{1}'", user.GUID, vgift.GUID)).Count <= 0)
                    {
                        if (vgift.NUMBER <= 0)
                        {
                            Response.Write("<script language=javascript>alert('礼品数量不足！');</script>");
                            return;
                        }
                        vgift.NUMBER = vgift.NUMBER - 1;
                        gift.Update(vgift);
                        Model.tbGiftTemp vgiftTemp = new Model.tbGiftTemp();
                        vgiftTemp.GUID = Guid.NewGuid().ToString("B");
                        vgiftTemp.USERGUID = user.GUID;
                        vgiftTemp.GIFTGUID = vgift.GUID;
                        vgiftTemp.GIFTNAME = vgift.GIFTNAME;
                        vgiftTemp.IMAGE = vgift.IMAGE;
                        vgiftTemp.DETAIL = vgift.DETAIL;
                        vgiftTemp.APPLYNAME = user.EMAIL;
                        vgiftTemp.APPLYNUM = 1;
                        vgiftTemp.APPLYDATE = DateTime.Now;
                        vgiftTemp.ISUSE = 1;
                        giftTemp.Add(vgiftTemp);
                    }
                    return;
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    tbGiftTemps = giftTemp.GetModelList(string.Format(" userguid={0}", user.GUID));
                }
            }
            else
            {
                tbGiftTemps = giftTemp.GetModelList(string.Format(" userguid={0}", user.GUID));
            }
        }
    }
}