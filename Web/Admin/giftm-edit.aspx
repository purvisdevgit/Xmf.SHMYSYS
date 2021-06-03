<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giftm-edit.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.giftm_edit" %>

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
                        <input type="text" id="giftname" name="giftname" required="" lay-verify="required" value="<%=mGift.GIFTNAME %>" 
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
                    <img id="LAY_demo_upload" width="400" src="<%=mGift.IMAGE %>">
                </div>
                <div class="layui-form-item">
                    <label  class="layui-form-label">
                    </label>
                </div>
                <div class="layui-form-item">
                    <label for="desc" class="layui-form-label">
                        <span class="x-red">*</span>数量
                    </label>
                    <div class="layui-input-inline">
                        <input type="text" id="number" name="number" required="" lay-verify="required" value="<%=mGift.NUMBER %>" 
                        autocomplete="off" class="layui-input">
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="link" class="layui-form-label">
                        <span class="x-red">*</span>详情
                    </label>
                    <div class="layui-input-inline">
                        <input type="text" id="detail" name="detail" required="" lay-verify="required" value="<%=mGift.DETAIL %>" 
                        autocomplete="off" class="layui-input">
                    </div>
                </div>
                <div class="layui-form-item">
                    <label for="L_repass" class="layui-form-label">
                    </label>
                    <button  class="layui-btn" lay-filter="add" lay-submit="">
                        保存
                    </button>
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
                    $.post("./giftm-edit.aspx?edit=1", {
                        'guid': '<%=mGift.GUID%>', 'giftname': $("#giftname").val(), 'sltsrc': $("#LAY_demo_upload").attr("src"), 'number': $("#number").val(), 'detail': $("#detail").val()
                    }, function (data) {

                      console.log(data);
                      var data = JSON.parse(data);
                      if (data.SUCCESS === 'true') {

                          //发异步，把数据提交给php
                          layer.alert("保存成功", { icon: 6 }, function () {
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
