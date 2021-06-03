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
namespace Xmf.SHMYSYS.Web.tbRole
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
		Xmf.SHMYSYS.BLL.tbRole bll=new Xmf.SHMYSYS.BLL.tbRole();
		Xmf.SHMYSYS.Model.tbRole model=bll.GetModel(GUID);
		this.lblGUID.Text=model.GUID;
		this.txtROLENAME.Text=model.ROLENAME;
		this.txtISUSE.Text=model.ISUSE.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtROLENAME.Text.Trim().Length==0)
			{
				strErr+="ROLENAME不能为空！\\n";	
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
			string ROLENAME=this.txtROLENAME.Text;
			int ISUSE=int.Parse(this.txtISUSE.Text);


			Xmf.SHMYSYS.Model.tbRole model=new Xmf.SHMYSYS.Model.tbRole();
			model.GUID=GUID;
			model.ROLENAME=ROLENAME;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbRole bll=new Xmf.SHMYSYS.BLL.tbRole();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
