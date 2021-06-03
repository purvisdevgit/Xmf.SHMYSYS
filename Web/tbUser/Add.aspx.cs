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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtGUID.Text.Trim().Length==0)
			{
				strErr+="GUID不能为空！\\n";	
			}
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
			string GUID=this.txtGUID.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
