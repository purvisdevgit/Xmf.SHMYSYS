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
			string GUID=this.txtGUID.Text;
			string ROLENAME=this.txtROLENAME.Text;
			int ISUSE=int.Parse(this.txtISUSE.Text);

			Xmf.SHMYSYS.Model.tbRole model=new Xmf.SHMYSYS.Model.tbRole();
			model.GUID=GUID;
			model.ROLENAME=ROLENAME;
			model.ISUSE=ISUSE;

			Xmf.SHMYSYS.BLL.tbRole bll=new Xmf.SHMYSYS.BLL.tbRole();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
