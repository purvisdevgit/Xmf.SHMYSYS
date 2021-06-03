<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.MyInfo" %>

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
           <%-- <div class="layui-form-item">
                <label for="L_username" class="layui-form-label">
                    <span class="x-red">*</span>用户名
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="username" name="username" required="" lay-verify="username"
                        autocomplete="off" readonly="readonly" class="layui-input" value="<%=user.USERNAME %>">
                </div>
            </div>
            <div class="layui-form-item">
                <label for="L_username" class="layui-form-label">
                    <span class="x-red">*</span>昵称
                </label>
                <div class="layui-input-inline">
                    <input type="text" id="nickname" name="nickname" lay-verify="" value="<%=user.NICKNAME %>"
                        autocomplete="off" class="layui-input">
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">
                    头像
                </label>

                <div class="layui-input-inline">
                    <div class="site-demo-upbar">
                        <input type="file" name="file" class="layui-upload-file" id="avatarfile">
                    </div>
                </div>
                <img id="avatar" width="200" src="<%=user.AVATAR %>">
            </div>--%>
            <div class="layui-form-item">
                <label for="L_username" class="layui-form-label">
                    <span class="x-red">*</span>角色
                </label>
                <div class="layui-input-inline">
                    <select name="role" id="role" disabled="disabled">
                        <option value="">请选择角色</option>
                        <%foreach (var role in tbRoles)
                            {%>
                        <option id="<%= role.GUID%>" <%if (user.ROLE == role.GUID)
                            {%>
                            selected="selected" <%} %> value="<%= role.GUID%>"><%= role.ROLENAME%></option>
                        <% } %>
                    </select>
                </div>
               <%-- <div class="layui-form-item">
                    <label for="L_username" class="layui-form-label">
                        <span class="x-red">*</span>性别
                    </label>
                    <div class="layui-inline">
                        <div class="layui-input-inline">
                            <input type="radio" name="sex" value="0" <%if (user.SEX == 0)
                                {%>
                                checked <%} %> title="男">
                            <input type="radio" name="sex" value="1" <%if (user.SEX == 1)
                                {%>
                                checked <%} %> title="女">
                        </div>
                    </div>
                    <div class="layui-form-item">
                        <label for="L_email" class="layui-form-label">
                            <span class="x-red">*</span>手机
                        </label>
                        <div class="layui-input-inline">
                            <input type="text" id="phone" name="phone" value="<%=user.PHONE %>" lay-verify=""
                                autocomplete="off" class="layui-input">
                        </div>
                    </div>--%>
                    <div class="layui-form-item">
                        <label for="L_email" class="layui-form-label">
                            <span class="x-red">*</span>邮箱
                        </label>
                        <div class="layui-input-inline">
                            <input type="text" id="email" name="email" value="<%=user.EMAIL %>" lay-verify=""
                                autocomplete="off" class="layui-input">
                        </div>
                    </div>
                    <div class="layui-form-item">
                    <%--    <label for="L_email" class="layui-form-label">
                            <span class="x-red">*</span>地址
                        </label>
                        <div class="layui-input-inline">
                            <input type="text" id="address" name="address" value="<%=user.ADDRESS %>" lay-verify=""
                                autocomplete="off" class="layui-input">
                        </div>--%>
                        <div class="layui-form-item">
                        </div>
                        <div class="layui-form-item">
                            <label for="L_sign" class="layui-form-label">
                            </label>
                            <button class="layui-btn" lay-filter="save" lay-submit="" id="btnManage">修改</button>
                            <%--    <button class="layui-btn" id="btnCancel" style="display: none" onclick="cancel">取消</button>--%>
                            <%--      <button class="layui-btn" id="alterPwd" onclick="member_password('修改密码','member-password.aspx','<%=user.GUID %>','600','400')">修改密码</button>--%>
                            <input type="button" onclick="member_password('修改密码','member-password.aspx','<%=user.GUID %>','600','400')" value="修改密码" class="layui-btn" id="alterPwd" />
                        </div>
        </form>
    </div>
    <script src="./lib/layui/layui.js" charset="utf-8">
    </script>
    <script src="./js/x-layui.js" charset="utf-8">
    </script>
    <script>
        layui.use(['form', 'layer', 'upload'], function () {
            $ = layui.jquery;
            var form = layui.form()
                , layer = layui.layer;


            //图片上传接口
            layui.upload({
                url: 'Service/UploadHandler.ashx?avatar=1' //上传接口
                , success: function (res) { //上传成功后的回调
                    console.log(res);
                    if (res.code == "1") {
                        $("#avatar").attr("src", res.data.src);
                    } else {
                        layer.alert(res.msg, { icon: 5 });
                    }
                    return false;
                }
            });
            //监听提交
            form.on('submit(save)', function (data) {
                //if ($("#btnManage").text() == "点此修改") {
                //    $("#username").attr("readonly", false);
                //    $("#nickname").attr("readonly", false);
                //    $("#avatarfile").attr("disabled", false);
                //    $("#role").attr("disabled", false);
                //    $("input[name='sex']").attr("disabled", false);
                //    $("#phone").attr("readonly", false);
                //    $("#email").attr("readonly", false);
                //    $("#address").attr("readonly", false);
                //    $("#btnCancel").attr("style", "display:inline-block");
                //    $("#btnManage").text("保存");
                //    $("#nickname").attr("lay-verify", "nickname");
                //    $("#phone").attr("lay-verify", "phone");
                //    $("#email").attr("lay-verify", "email");
                //    $("#address").attr("lay-verify", "address");
                //    return false;
                //} else {
                console.log(data);
                $.post("./MyInfo.aspx?edit=1", { 'guid': '<%=user.GUID%>', 'username': $("#username").val(), 'nickname': $("#nickname").val(), 'avatarfile': $("#avatar").attr("src"), 'role': $("#role option:selected").val(), 'sex': $("input[name='sex']:checked").val(), 'phone': $("#phone").val(), 'email': $("#email").val(), 'address': $("#address").val() }, function (data) {

                    console.log(data);
                    var data = JSON.parse(data);
                    if (data.SUCCESS === 'true') {

                        //发异步，把数据提交给php
                        layer.alert("保存成功", { icon: 6 }, function () {
                            // 获得frame索引
                            //var index = parent.layer.getFrameIndex(window.name);
                            ////关闭当前frame
                            //parent.layer.close(index);
                            location.replace(location.href);
                        });
                        return false;
                    } else {

                        //发异步，把数据提交给php
                        layer.alert(data.MESSAGE, { icon: 5 });
                        return false;
                    }
                });
                return false;
                //}
                //return false;
            });
            //form.on('submit(cancel)', function (data) {
            //    $("#username").attr("readonly", true);
            //    $("#nickname").attr("readonly", true);
            //    $("#avatarfile").attr("disabled", true);
            //    $("#role").attr("disabled", true);
            //    $("input[name='sex']").attr("disabled", true);
            //    $("#phone").attr("readonly", true);
            //    $("#email").attr("readonly", true);
            //    $("#address").attr("readonly", true);
            //    $("#btnCancel").attr("style", "display:none");
            //    $("#btnManage").text("点此修改");
            //    $("#nickname").attr("lay-verify", "");
            //    $("#phone").attr("lay-verify", "");
            //    $("#email").attr("lay-verify", "");
            //    $("#address").attr("lay-verify", "");
            //    return false;
            //});
            return false;
        });

        /*密码-修改*/
        function member_password(title, url, id, w, h) {
            x_admin_show(title, url + "?guid=" + id, w, h);
            return false;
        }
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
