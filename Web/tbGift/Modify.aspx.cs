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
namespace Xmf.SHMYSYS.Web.tbGift
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
		Xmf.SHMYSYS.BLL.tbGift bll=new Xmf.SHMYSYS.BLL.tbGift();
		Xmf.SHMYSYS.Model.tbGift model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.txtGIFTNAME.Text=model.GIFTNAME;
		this.txtIMAGE.Text=model.IMAGE;
		this.txtNUMBER.Text=model.NUMBER.ToString();
		this.txtDETAIL.Text=model.DETAIL;
		this.txtADDTIME.Text=model.ADDTIME.ToString();
		this.txtISUSE.Text=model.ISUSE.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtGIFTNAME.Text.Trim().Length==0)
			{
				strErr+="GIFTNAME不能为空！\\n";	
			}
			if(this.txtIMAGE.Text.Trim().Length==0)
			{
				strErr+="IMAGE不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtNUMBER.Text))
			{
				strErr+="NUMBER格式错误！\\n";	
			}
			if(this.txtDETAIL.Text.Trim().Length==0)
			{
				strErr+="DETAIL不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtADDTIME.Text))
			{
				strErr+="ADDTIME格式错误！\\n";	
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
			string GIFTNAME=this.txtGIFTNAME.Text;
			string IMAGE=this.txtIMAGE.Text;
			int NUMBER=int.Parse(this.txtNUMBER.Text);
			string DETAIL=this.txtDETAIL.Text;
			DateTime ADDTIME=DateTime.Parse(this.txtADDTIME.Text);
			int ISUSE=int.Parse(this.txtISUSE.Text);


			Xmf.SHMYSYS.Model.tbGift model=new Xmf.SHMYSYS.Model.tbGift();
			model.GUID=GUID;
			model.GIFTNAME=GIFTNAME;
			model.IMAGE=IMAGE;
			model.NUMBER=NUMBER;
			model.DETAIL=DETAIL;
			model.ADDTIME=ADDTIME;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbGift bll=new Xmf.SHMYSYS.BLL.tbGift();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
