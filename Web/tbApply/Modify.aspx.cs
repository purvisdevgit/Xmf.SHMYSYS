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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Xmf.SHMYSYS.Web.tbApply
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string GUID= Request.Params["id"];
					ShowInfo(GUID);
				}
			}
		}
			
	private void ShowInfo(string GUID)
	{
		Xmf.SHMYSYS.BLL.tbApply bll=new Xmf.SHMYSYS.BLL.tbApply();
		Xmf.SHMYSYS.Model.tbApply model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.txtGIFTGUID.Text=model.GIFTGUID;
		this.txtAPPLYNUM.Text=model.APPLYNUM.ToString();
		this.txtAPPLYNAME.Text=model.APPLYNAME;
		this.txtAPPLYSTATE.Text=model.APPLYSTATE.ToString();
		this.txtAPPLYDATE.Text=model.APPLYDATE.ToString();
		this.txtAUDITDATE.Text=model.AUDITDATE.ToString();
		this.txtRELEASEDATE.Text=model.RELEASEDATE.ToString();
		this.txtISUSE.Text=model.ISUSE.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtGIFTGUID.Text.Trim().Length==0)
			{
				strErr+="GIFTGUID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAPPLYNUM.Text))
			{
				strErr+="APPLYNUM格式错误！\\n";	
			}
			if(this.txtAPPLYNAME.Text.Trim().Length==0)
			{
				strErr+="APPLYNAME不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAPPLYSTATE.Text))
			{
				strErr+="APPLYSTATE格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAPPLYDATE.Text))
			{
				strErr+="APPLYDATE格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtAUDITDATE.Text))
			{
				strErr+="AUDITDATE格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRELEASEDATE.Text))
			{
				strErr+="RELEASEDATE格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtISUSE.Text))
			{
				strErr+="ISUSE格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string GUID=this.lblGUID.Text;
			string GIFTGUID=this.txtGIFTGUID.Text;
			int APPLYNUM=int.Parse(this.txtAPPLYNUM.Text);
			string APPLYNAME=this.txtAPPLYNAME.Text;
			int APPLYSTATE=int.Parse(this.txtAPPLYSTATE.Text);
			DateTime APPLYDATE=DateTime.Parse(this.txtAPPLYDATE.Text);
			DateTime AUDITDATE=DateTime.Parse(this.txtAUDITDATE.Text);
			DateTime RELEASEDATE=DateTime.Parse(this.txtRELEASEDATE.Text);
			int ISUSE=int.Parse(this.txtISUSE.Text);


			Xmf.SHMYSYS.Model.tbApply model=new Xmf.SHMYSYS.Model.tbApply();
			model.GUID=GUID;
			model.GIFTGUID=GIFTGUID;
			model.APPLYNUM=APPLYNUM;
			model.APPLYNAME=APPLYNAME;
			model.APPLYSTATE=APPLYSTATE;
			model.APPLYDATE=APPLYDATE;
			model.AUDITDATE=AUDITDATE;
			model.RELEASEDATE=RELEASEDATE;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbApply bll=new Xmf.SHMYSYS.BLL.tbApply();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
