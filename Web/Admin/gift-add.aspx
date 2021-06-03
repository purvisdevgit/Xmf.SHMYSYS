<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift-add.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.gift_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>X-admin v1.0
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
                    <span class="x-red">*</span>礼品名称
                </label>
                <div class="layui-input-inline">
                    <select name="giftname" id="giftname"  lay-filter="giftChange">
                        <option value="">请选择礼品</option>
                        <%foreach (var gift in tbGifts)
                            {%>
                        <option id="<%= gift.GUID%>" value="<%= gift.GUID%>"><%= gift.GIFTNAME%></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    缩略图
                </label>

                <%--  <div class="layui-input-inline">
                      <div class="site-demo-upbar">
                        <input type="file" name="file" class="layui-upload-file" id="test">
                      </div>
                    </div>--%>
                <img id="slt" width="400" src="">
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                </label>
                （由于服务器资源有限，所以此处每次给你返回的是同一张图片)
            </div>
            <div class="layui-form-item">
                <label for="desc" class="layui-form-label">
                    <span class="x-red">*</span>数量
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="giftnum" name="giftnum" required="" lay-verify="required" readonly="readonly"
                        autocomplete="off" class="layui-input">
                </div>
                <%--     <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>
                    </div>--%>
            </div>
            <div class="layui-form-item">
                <label for="desc" class="layui-form-label">
                    <span class="x-red">*</span>详情
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="giftdetail" name="giftdetail" required="" lay-verify="required" readonly="readonly"
                        autocomplete="off" class="layui-input">
                </div>
                <%--     <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>
                    </div>--%>
            </div>
            <div class="layui-form-item">
                <label for="desc" class="layui-form-label">
                    <span class="x-red">*</span>申请的数量
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="applynum" name="applynum" required="" lay-verify="required"
                        autocomplete="off" class="layui-input">
                </div>
                <%--     <div class="layui-form-mid layui-word-aux">
                        <span class="x-red">*</span>
                    </div>--%>
            </div>

            <div class="layui-form-item">
                <label for="link" class="layui-form-label">
                    <span class="x-red">*</span>备注
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="remark" name="remark" required="" lay-verify="required"
                        autocomplete="off" class="layui-input">
                </div>
            </div>
            <div class="layui-form-item">
                <label for="L_repass" class="layui-form-label">
                </label>
                <button class="layui-btn" lay-filter="add" lay-submit="" >
                    增加
                </button>
            </div>
        </form>
    </div>
    <script src="./lib/layui/layui.js" charset="utf-8">
    </script>
    <script src="./js/x-layui.js" charset="utf-8">
    </script>
    <script src="js/jquery.min.js"></script>
<%--    <script type="text/JavaScript">
     
        function giftChange() {
            var ogift = document.getElementById("giftname");
            var vgift = ogift.options[ogift.selectedIndex].value;
            alert("0");
            if (vgift == "") {
                alert("1");
                $("#slt").attr("src", "");
                $("#giftnum").attr("value", "");
                $("#giftdetail").attr("value", "");
                return;
            } else {
                alert("2");
                $.post("./gift-add.aspx?giftguid=" + $(this).val(), function (data) {
                    console.log(data);
                    var data = JSON.parse(data);
                    if (data.SUCCESS === 'true') {

                        $("#slt").attr("src", "");
                        $("#giftnum").attr("value", "");
                        $("#giftdetail").attr("value", "");
                        return;
                    }

                });
            }
        }
    </script>--%>
    <script>
        layui.use(['form', 'layer', 'upload'], function () {
            $ = layui.jquery;
            var form = layui.form()
                , layer = layui.layer;


            //图片上传接口
            //layui.upload({
            //  url: './upload.json' //上传接口
            //  ,success: function(res){ //上传成功后的回调
            //      console.log(res);
            //    $('#LAY_demo_upload').attr('src',res.url);
            //  }
            //});


            //监听提交
            form.on('submit(add)', function (data) {
                $.post("./gift-add.aspx?add=1", { 'giftguid': data.field.giftname, 'applynum': data.field.applynum, 'remark': data.field.remark }, function (data) {

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

            form.on('select(giftChange)', function (data) {
                if (data.value == "") {
                    $("#slt").attr("src", "");
                    $("#giftnum").attr("value", "");
                    $("#giftdetail").attr("value", "");
                    return;
                } else {
                    $.post("./gift-add.aspx?giftguid=" + data.value, function (data) {
                        console.log(data);
                        var data = JSON.parse(data);
                        if (data.SUCCESS === 'true') {

                            $("#slt").attr("src", data.DATA.IMAGE);
                            $("#giftnum").attr("value", data.DATA.NUMBER);
                            $("#giftdetail").attr("value", data.DATA.DETAIL);
                            return;
                        }

                    });
                }
            });

        });
    </script>
    <script>
        var _hmt = _hmt || [];
        (function () {
            var hm = document.createElement("script");
            hm.src = "https://hm.baidu.com/hm.js?b393d153aeb26b46e9431fabaf0f6190";
            var s = document.getElementsByTagName("script")[0];
            s.parentNode.insertBefore(hm, s);
        })();
    </script>
</body>
</html>
