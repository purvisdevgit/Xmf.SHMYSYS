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
namespace Xmf.SHMYSYS.Web.tbPower
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
		Xmf.SHMYSYS.BLL.tbPower bll=new Xmf.SHMYSYS.BLL.tbPower();
		Xmf.SHMYSYS.Model.tbPower model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.lblROLE.Text=model.ROLE;
		this.lblCATALOG.Text=model.CATALOG;
		this.lblISUSE.Text=model.ISUSE.ToString();

	}


    }
}
