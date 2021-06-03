using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmf.SHMYSYS.DAL;

namespace Xmf.SHMYSYS.Web.Service
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strQuery = HttpContext.Current.Request.Url.Query;
            strQuery = HttpUtility.UrlDecode(strQuery, System.Text.Encoding.UTF8);
            if (strQuery.Contains("avatar=1"))
            {
                HttpPostedFile _upfile = context.Request.Files["file"];
                if (_upfile == null)
                {
                    ResponseWriteEnd(context, "4");//请选择要上传的文件
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString("N");/*获取文件名： C:\Documents and Settings\Administrator\桌面\123.jpg*/
                    string suffix = _upfile.FileName.Substring(_upfile.FileName.LastIndexOf(".") + 1).ToLower();/*获取后缀名并转为小写： jpg*/
                    int bytes = _upfile.ContentLength;//获取文件的字节大小

                    if (suffix != "jpg")
                        ResponseWriteEnd(context, "2"); //只能上传JPG格式图片
                    if (bytes > 1024 * 1024)
                        ResponseWriteEnd(context, "3"); //图片不能大于1M
                    fileName = fileName + "." + suffix;

                    _upfile.SaveAs(HttpContext.Current.Server.MapPath(string.Format("~/UploadImgs/Avatar/{0}", fileName)));//保存图片
                    ResponseWriteEnd(context, "1", string.Format("../UploadImgs/Avatar/{0}", fileName)); //上传成功
                }
            }
            else
            {

                HttpPostedFile _upfile = context.Request.Files["file"];
                if (_upfile == null)
                {
                    ResponseWriteEnd(context, "4");//请选择要上传的文件
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString("N");/*获取文件名： C:\Documents and Settings\Administrator\桌面\123.jpg*/
                    string suffix = _upfile.FileName.Substring(_upfile.FileName.LastIndexOf(".") + 1).ToLower();/*获取后缀名并转为小写： jpg*/
                    int bytes = _upfile.ContentLength;//获取文件的字节大小

                    if (suffix != "jpg")
                        ResponseWriteEnd(context, "2"); //只能上传JPG格式图片
                    if (bytes > 1024 * 1024)
                        ResponseWriteEnd(context, "3"); //图片不能大于1M
                    fileName = fileName + "." + suffix;

                    _upfile.SaveAs(HttpContext.Current.Server.MapPath(string.Format("~/UploadImgs/Gift/{0}", fileName)));//保存图片
                    ResponseWriteEnd(context, "1", string.Format("../UploadImgs/Gift/{0}", fileName)); //上传成功
                }
            }
        }
        private void ResponseWriteEnd(HttpContext context, string msg)
        {
            ReturnUImgMsg returnMsg = new ReturnUImgMsg();
            returnMsg.code = msg;
            if (msg == "2")
            {
                returnMsg.msg = "只能上传JPG格式图片";
            }
            if (msg == "3")
            {
                returnMsg.msg = "图片不能大于1M";
            }
            if (msg == "4")
            {
                returnMsg.msg = "请选择要上传的文件";
            }
            ReturnUImgData returnUImgData = new ReturnUImgData();
            returnUImgData.src = "";
            returnMsg.data = returnUImgData;
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(returnMsg));
            context.Response.End();
        }
        private void ResponseWriteEnd(HttpContext context, string msg, string filePath)
        {
            ReturnUImgMsg returnMsg = new ReturnUImgMsg();
            returnMsg.code = msg;
            returnMsg.msg = "上传成功";
            ReturnUImgData returnUImgData = new ReturnUImgData();
            returnUImgData.src = filePath;
            returnMsg.data =returnUImgData;
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(returnMsg));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class ReturnUImgMsg
        {
            private string _code;
            private string _msg;
            private ReturnUImgData _data;

            public string code
            {
                set { _code = value; }
                get { return _code; }
            }
            public string msg
            {
                set { _msg = value; }
                get { return _msg; }
            }

            public ReturnUImgData data
            {
                set { _data = value; }
                get { return _data; }
            }
        }
        public class ReturnUImgData {
            public string src { get; set; }
        }
    }
}