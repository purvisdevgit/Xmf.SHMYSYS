<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giftm-add.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.giftm_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
        <title>
            X-admin v1.0
        </title>
        <meta name="renderer" content="webkit">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <meta name="apple-mobile-web-app-status-bar-style" content="black">
        <meta name="apple-mobile-web-app-capable" content="yes">
        <meta name="format-detection" content="telephone=no">
        <link rel="stylesheet" href="./css/x-admin.css" media="all">
    </head>
<body>
       <div class="x-body">
            <form class="layui-form">
                 <div class="layui-form-item">
                    <label for="link" class="layui-form-label">
                        <span class="x-red">*</span>名称
                    </label>
                    <div class="layui-input-inline">
                        <input type="text" id="giftname" name="giftname" required="" lay-verify="required"
                        autocomplete="off" class="layui-input">
                    </div>
                </div>
                 <div class="layui-form-item">
                    <label  class="layui-form-label">缩略图
                    </label>
                    
                    <div class="layui-input-inline">
                      <div class="site-demo-upbar">
                        <input type="file" name="file" class="layui-upload-file" id="ImgUrlbtn">
                      </div>
                    </div>
                    <img id="LAY_demo_upload" width="400" src="">
                </div>
                <div class="layui-form-item">
                    <label  class="layui-form-label">
                    </label>
                    （由于服务器资源有限，所以此处每次给你返回的是同一张图片)
                </div>
                
                <div class="layui-form-item">
                    <label for="desc" class="layui-form-label">
                        <span class="x-red">*</span>数量
                    </label>
                    <div class="layui-input-inline">
                        <input type="text" id="num" name="num" required="" lay-verify="required"
                        autocomplete="off" class="layui-input">
                    </div>
               <%--     <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>
                    </div>--%>
                </div>
                
                <div class="layui-form-item">
                    <label for="link" class="layui-form-label">
                        详情
                    </label>
                    <div class="layui-input-inline">
                        <input type="text" id="details" name="details" required=""
                        autocomplete="off" class="layui-input">
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="L_repass" class="layui-form-label">
                    </label>
                    <button  class="layui-btn" lay-filter="add" lay-submit="">
                        增加</button>
                </div>
            </form>
        </div>
        <script src="./lib/layui/layui.js" charset="utf-8">
        </script>
        <script src="./js/x-layui.js" charset="utf-8">
        </script>
        <script>
            layui.use(['form','layer','upload'], function(){
                $ = layui.jquery;
              var form = layui.form()
              ,layer = layui.layer;

                //图片上传接口
                layui.upload({
                    url: 'Service/UploadHandler.ashx?gift=1' //上传接口
                    , success: function (res) { //上传成功后的回调
                        console.log(res);
                        if (res.code == "1") {
                            $("#LAY_demo_upload").attr("src", res.data.src);
                        } else {
                            layer.alert(res.msg, { icon: 5 });
                        }
                        return false;
                    }
                });
              //监听提交
                form.on('submit(add)', function (data) {
                    $.post("./giftm-add.aspx?add=1", { 'giftname': data.field.giftname, 'file': $("#LAY_demo_upload").attr("src"), 'num': data.field.num, 'details': data.field.details }, function (data) {

                      console.log(data);
                      var data = JSON.parse(data);
                      if (data.SUCCESS === 'true') {

                          //发异步，把数据提交给php
                          layer.alert("增加成功", { icon: 6 }, function () {
                              // 获得frame索引
                              var index = parent.layer.getFrameIndex(window.name);
                              //关闭当前frame
                              parent.layer.close(index);
                              parent.location.replace(parent.location.href);
                          });
                          return false;
                      } else {

                          //发异步，把数据提交给php
                          layer.alert(data.MESSAGE, { icon: 5 });
                          return false;
                      }
                  });
                  return false;

              });
              
              
            });
        </script>
        <script>
        var _hmt = _hmt || [];
        (function() {
          var hm = document.createElement("script");
          hm.src = "https://hm.baidu.com/hm.js?b393d153aeb26b46e9431fabaf0f6190";
          var s = document.getElementsByTagName("script")[0]; 
          s.parentNode.insertBefore(hm, s);
        })();
        </script>
</body>
</html>
