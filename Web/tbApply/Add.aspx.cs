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
			string GUID=this.txtGUID.Text;
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
