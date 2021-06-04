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
    public partial class member_list : System.Web.UI.Page
    {
        public List<GiftView> giftViews = new List<GiftView>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg Rms = new ReturnMsg();
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("qyguid=") || strQuery.Contains("jyguid="))//启用 禁用
            {
                try
                {
                    string strGuid = strQuery.Split('=')[1].ToString();
                    tbUser user = new tbUser();
                    Model.tbUser user1 = user.GetModel(strGuid);
                    if (strQuery.Contains("qyguid="))
                    {
                        user1.ISUSE = 1;
                    }
                    else
                    {
                        user1.ISUSE = 0;
                    }
                    user.Update(user1);
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
                        Rms.MESSAGE = "请选择需要删除人员！";
                        Rms.STATE = STATE.F;
                        Rms.SUCCESS = SUCCESS.F;
                        Response.Write(JsonConvert.SerializeObject(Rms));
                        return;
                    }
                    tbUser user = new tbUser();
                    foreach (var guid in strGuids)
                    {
                        if (guid == "")
                        {
                            continue;
                        }
                        user.Delete(guid);
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
                    tbUser user = new tbUser();
                    user.Delete(strDelGuid);
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
                tbUser user = new tbUser();
                tbRole role = new tbRole();
                DataTable dataTable = user.GetAllList().Tables[0];
                foreach (DataRow row in dataTable.Rows)
                {
                    GiftView giftView = new GiftView();
                    giftView.GUID = row["GUID"].ToString();
                    giftView.USERNAME = row["USERNAME"].ToString();
                    giftView.NICKNAME = row["NICKNAME"].ToString();
                    giftView.AVATAR = row["AVATAR"].ToString();
                    giftView.SEX = row["SEX"].ToString();
                    giftView.PHONE = row["PHONE"].ToString();
                    giftView.EMAIL = row["EMAIL"].ToString();
                    giftView.ADDRESS = row["ADDRESS"].ToString();
                    DataTable roledt = role.GetList(string.Format(" GUID= '{0}'", row["ROLE"].ToString())).Tables[0];
                    if (roledt.Rows.Count > 0)
                    {
                        giftView.ROLE = roledt.Rows[0]["ROLENAME"].ToString();
                    }
                    giftView.ADDTIME = Convert.ToDateTime(row["ADDTIME"].ToString()).ToString("yyyy年MM月dd日 HH:mm:ss");
                    giftView.ISUSE = row["ISUSE"].ToString() == "1" ? "已启用" : "未启用";
                    if (row["SUPERIOR"]!=DBNull.Value&& row["SUPERIOR"]!=null&& row["SUPERIOR"].ToString().Trim()!="")
                    {
                        giftView.SUPERIOR = user.GetModel(row["SUPERIOR"].ToString()).EMAIL;
                    }
                    giftViews.Add(giftView);
                }
            }
        }

        public class GiftView
        {
            public string GUID { get; set; }
            public string USERNAME { get; set; }
            public string NICKNAME { get; set; }
            public string AVATAR { get; set; }
            public string SEX { get; set; }
            public string PHONE { get; set; }
            public string EMAIL { get; set; }
            public string ADDRESS { get; set; }
            public string ROLE { get; set; }
            public string ADDTIME { get; set; }
            public string ISUSE { get; set; }
            public string SUPERIOR { get; set; }
        }
    }
}