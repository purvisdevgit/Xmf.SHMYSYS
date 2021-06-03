using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Xmf.SHMYSYS.Web.tbApply
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string GUID= strid;
					ShowInfo(GUID);
				}
			}
		}
		
	private void ShowInfo(string GUID)
	{
		Xmf.SHMYSYS.BLL.tbApply bll=new Xmf.SHMYSYS.BLL.tbApply();
		Xmf.SHMYSYS.Model.tbApply model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.lblGIFTGUID.Text=model.GIFTGUID;
		this.lblAPPLYNUM.Text=model.APPLYNUM.ToString();
		this.lblAPPLYNAME.Text=model.APPLYNAME;
		this.lblAPPLYSTATE.Text=model.APPLYSTATE.ToString();
		this.lblAPPLYDATE.Text=model.APPLYDATE.ToString();
		this.lblAUDITDATE.Text=model.AUDITDATE.ToString();
		this.lblRELEASEDATE.Text=model.RELEASEDATE.ToString();
		this.lblISUSE.Text=model.ISUSE.ToString();

	}


    }
}
