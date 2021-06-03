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
namespace Xmf.SHMYSYS.Web.tbUser
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
		Xmf.SHMYSYS.BLL.tbUser bll=new Xmf.SHMYSYS.BLL.tbUser();
		Xmf.SHMYSYS.Model.tbUser model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.txtUSERNAME.Text=model.USERNAME;
		this.txtNICKNAME.Text=model.NICKNAME;
		this.txtAVATAR.Text=model.AVATAR;
		this.txtPASSWORD.Text=model.PASSWORD;
		this.txtROLE.Text=model.ROLE;
		this.txtADDTIME.Text=model.ADDTIME.ToString();
		this.txtISUSE.Text=model.ISUSE.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUSERNAME.Text.Trim().Length==0)
			{
				strErr+="USERNAME不能为空！\\n";	
			}
			if(this.txtNICKNAME.Text.Trim().Length==0)
			{
				strErr+="NICKNAME不能为空！\\n";	
			}
			if(this.txtAVATAR.Text.Trim().Length==0)
			{
				strErr+="AVATAR不能为空！\\n";	
			}
			if(this.txtPASSWORD.Text.Trim().Length==0)
			{
				strErr+="PASSWORD不能为空！\\n";	
			}
			if(this.txtROLE.Text.Trim().Length==0)
			{
				strErr+="ROLE不能为空！\\n";	
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
			string USERNAME=this.txtUSERNAME.Text;
			string NICKNAME=this.txtNICKNAME.Text;
			string AVATAR=this.txtAVATAR.Text;
			string PASSWORD=this.txtPASSWORD.Text;
			string ROLE=this.txtROLE.Text;
			DateTime ADDTIME=DateTime.Parse(this.txtADDTIME.Text);
			int ISUSE=int.Parse(this.txtISUSE.Text);


			Xmf.SHMYSYS.Model.tbUser model=new Xmf.SHMYSYS.Model.tbUser();
			model.GUID=GUID;
			model.USERNAME=USERNAME;
			model.NICKNAME=NICKNAME;
			model.AVATAR=AVATAR;
			model.PASSWORD=PASSWORD;
			model.ROLE=ROLE;
			model.ADDTIME=ADDTIME;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbUser bll=new Xmf.SHMYSYS.BLL.tbUser();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
