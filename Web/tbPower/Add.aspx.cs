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
namespace Xmf.SHMYSYS.Web.tbPower
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
			if(this.txtROLE.Text.Trim().Length==0)
			{
				strErr+="ROLE不能为空！\\n";	
			}
			if(this.txtCATALOG.Text.Trim().Length==0)
			{
				strErr+="CATALOG不能为空！\\n";	
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
			string ROLE=this.txtROLE.Text;
			string CATALOG=this.txtCATALOG.Text;
			int ISUSE=int.Parse(this.txtISUSE.Text);

			Xmf.SHMYSYS.Model.tbPower model=new Xmf.SHMYSYS.Model.tbPower();
			model.GUID=GUID;
			model.ROLE=ROLE;
			model.CATALOG=CATALOG;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbPower bll=new Xmf.SHMYSYS.BLL.tbPower();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
