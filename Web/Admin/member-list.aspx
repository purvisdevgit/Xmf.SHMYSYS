<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member-list.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.member_list" %>

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
    <div class="x-nav">
            <span class="layui-breadcrumb">
              <a><cite>首页</cite></a>
              <a><cite>人员维护</cite></a>
            </span>
            <a class="layui-btn layui-btn-small" style="line-height:1.6em;margin-top:3px;float:right"  href="javascript:location.replace(location.href);" title="刷新"><i class="layui-icon" style="line-height:30px">ဂ</i></a>
        </div>
        <div class="x-body">
            <form class="layui-form x-center" action="" style="width:800px">
                <div class="layui-form-pane" style="margin-top: 15px;">
                 <%-- <div class="layui-form-item">
                    <label class="layui-form-label">日期范围</label>
                    <div class="layui-input-inline">
                      <input class="layui-input" placeholder="开始日" id="LAY_demorange_s">
                    </div>
                    <div class="layui-input-inline">
                      <input class="layui-input" placeholder="截止日" id="LAY_demorange_e">
                    </div>
                    <div class="layui-input-inline">
                      <input type="text" name="username"  placeholder="请输入用户名" autocomplete="off" class="layui-input">
                    </div>
                    <div class="layui-input-inline" style="width:80px">
                        <button class="layui-btn"  lay-submit="" lay-filter="sreach"><i class="layui-icon">&#xe615;</i></button>
                    </div>
                  </div>--%>
                </div> 
            </form>
            <xblock><button class="layui-btn layui-btn-danger" onclick="delAll()"><i class="layui-icon">&#xe640;</i>批量删除</button><button class="layui-btn" onclick="member_add('添加用户','member-add.aspx','600','500')"><i class="layui-icon">&#xe608;</i>添加</button><span class="x-right" style="line-height:40px">共有数据：<%=giftViews.Count %> 条</span></xblock>
            <table class="layui-table" id="tb">
                <thead>
                    <tr>
                        <th>
                                <input type="checkbox" name="" value="" onclick="ischeckall()" >
                        </th>
                        <th>
                            唯一键
                        </th>
                      <%--  <th>
                            用户名
                        </th>
                         <th>
                            昵称
                        </th>
                        <th>
                            头像
                        </th>
                        <th>
                            性别
                        </th>
                        <th>
                            手机
                        </th>--%>
                        <th>
                            邮箱
                        </th>
                       <%-- <th>
                            地址
                        </th>--%>
                          <%--<th>
                            密码
                        </th>--%>
                            <th>
                            角色
                        </th>
                            <th>
                            员工上级
                        </th>
                        <th>
                            添加日期
                        </th>
                        <th>
                            是否使用
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                          <%foreach (var gv in giftViews)
                              {%>
                           
                    <tr>
                        <td>
                           <input type="checkbox" class="isChk" value="<%=gv.GUID %>" name="">
                        </td>
                        <td>
                              <%=gv.GUID %>
                        </td>
              <%--          <td>
                            <u style="cursor:pointer" onclick="member_show('张三','member-show.html','10001','360','400')">
                                 <%=gv.USERNAME %>
                            </u>
                        </td>--%>
                      <%--  <td >
                             <%=gv.NICKNAME %>
                        </td>--%>
             <%--           <td >
                           <img src="<%if (string.IsNullOrEmpty(gv.AVATAR)){%>./images/logo.png<%} else {%><%=gv.AVATAR %> <%}%>"" class="layui-circle" style="border: 2px solid #A9B7B7;" width="35px" alt="">
                        </td>
                        <td >
                          <%=gv.SEX %>
                        </td>--%>
               <%--         <td >
                             <%=gv.PHONE %>
                        </td>--%>
                         <td >
                            <%=gv.EMAIL %>
                        </td>
                       <%--  <td >
                           <%=gv.ADDRESS %>
                        </td>--%>
                         <td >
                            <%=gv.ROLE %>
                        </td>
                         <td >
                            <%=gv.SUPERIOR %>
                        </td>
                      <%--   <td >
                            北京市 海淀区
                        </td>--%>
                        <td>
                             <%=gv.ADDTIME %>
                        </td>
                        <td class="td-status">
                            <span class="layui-btn layui-btn-normal layui-btn-mini">
                                <%=gv.ISUSE %>
                            </span>
                        </td>
                        <td class="td-manage">
                           <a style="text-decoration:none" onclick="member_stop(this,'<%=gv.GUID %>')" href="javascript:;" title="<%if (gv.ISUSE == "已启用")
                              {%>停用<%}
                              else
                              { %>启用<%} %>"
                                <i class="layui-icon">&#xe601;</i>
                            </a>
                            <a title="编辑" href="javascript:;" onclick="member_edit('编辑','member-edit.aspx','<%=gv.GUID %>','','510')"
                            class="ml-5" style="text-decoration:none">
                                <i class="layui-icon">&#xe642;</i>
                            </a>
                            <a style="text-decoration:none"  onclick="member_password('修改密码','member-password.aspx','<%=gv.GUID %>','600','400')"
                            href="javascript:;" title="修改密码">
                                <i class="layui-icon">&#xe631;</i>
                            </a>
                            <a title="删除" href="javascript:;" onclick="member_del(this,'<%=gv.GUID %>')" 
                            style="text-decoration:none">
                                <i class="layui-icon">&#xe640;</i>
                            </a>
                        </td>
                    </tr>
                    <%}%>
                </tbody>
            </table>

            <%--<div id="page"></div>--%>
        </div>
        <script src="./lib/layui/layui.js" charset="utf-8"></script>
        <script src="./js/x-layui.js" charset="utf-8"></script>
        <script>
            layui.use(['laydate','element','laypage','layer'], function(){
                $ = layui.jquery;//jquery
              laydate = layui.laydate;//日期插件
              lement = layui.element();//面包导航
              laypage = layui.laypage;//分页
              layer = layui.layer;//弹出层

              //以上模块根据需要引入

              laypage({
                cont: 'page'
                ,pages: 100
                ,first: 1
                ,last: 100
                ,prev: '<em><</em>'
                ,next: '<em>></em>'
              }); 
              
              var start = {
                min: laydate.now()
                ,max: '2099-06-16 23:59:59'
                ,istoday: false
                ,choose: function(datas){
                  end.min = datas; //开始日选好后，重置结束日的最小日期
                  end.start = datas //将结束日的初始值设定为开始日
                }
              };
              
              var end = {
                min: laydate.now()
                ,max: '2099-06-16 23:59:59'
                ,istoday: false
                ,choose: function(datas){
                  start.max = datas; //结束日选好后，重置开始日的最大日期
                }
              };
              
              document.getElementById('LAY_demorange_s').onclick = function(){
                start.elem = this;
                laydate(start);
              }
              document.getElementById('LAY_demorange_e').onclick = function(){
                end.elem = this
                laydate(end);
              }
              
            });

            //批量删除提交
             function delAll () {
                 var param = '';
                 var tb = document.getElementById("tb");
                 if (tb.rows.length < 2) {
                     return;
                 }
                 var row;
                 var cell;
                 var chk;
                 //倒着迭代可以少做一些处理
                 for (var i = tb.rows.length - 1; i > 0; i--) {//如果要迭代第一行(i > -1)即可
                     row = tb.rows[i];//迭代当前行
                     cell = row.cells[0];//复选框所在的单元格
                     chk = cell.getElementsByClassName("isChk")[0];//为单元格中第几个INPUT元素
                     if (chk.checked) {//如果选中
                         param += chk.value + ',';
                     }
                 }
                 layer.confirm('确认要删除吗？', function (index) {
                     $.post("./member-list.aspx?delChk=1", { 'chkGuid': param }, function (data) {
                         console.log(data);
                         var data = JSON.parse(data);
                         if (data.SUCCESS === 'true') {
                             //捉到所有被选中的，发异步进行删除
                             layer.msg('删除成功', { icon: 1 }, function () {
                                 location.replace(location.href);
                             });
                             return false;
                         } else {

                             //发异步，把数据提交给php
                             layer.alert(data.MESSAGE, { icon: 5 });
                             return false;
                         }
                     });
                 });
             }
             /*用户-添加*/
            function member_add(title,url,w,h){
                x_admin_show(title,url,w,h);
            }
            /*用户-查看*/
            function member_show(title,url,id,w,h){
                x_admin_show(title,url,w,h);
            }

             /*用户-停用*/
            function member_stop(obj,id){
                if (obj.title == "启用") {
                    layer.confirm('确认要启用吗？', function (index) {
                        $.post("./member-list.aspx?qyguid=" + id, function (data) {
                            console.log(data);
                            var data = JSON.parse(data);
                            if (data.SUCCESS === 'true') {
                                layer.alert("已启用！", { icon: 6 }, function () {
                                    location.replace(location.href);
                                });
                                return false;
                            } else {

                                //发异步，把数据提交给php
                                layer.alert(data.MESSAGE, { icon: 5 });
                                return false;
                            }
                        });
                    });
                } else {
                    layer.confirm('确认要禁用吗？', function (index) {
                        $.post("./member-list.aspx?jyguid=" + id, function (data) {
                            console.log(data);
                            var data = JSON.parse(data);
                            if (data.SUCCESS === 'true') {
                                layer.alert("已禁用！", { icon: 6 }, function () {
                                    location.replace(location.href);
                                });
                                return false;
                            } else {

                                //发异步，把数据提交给php
                                layer.alert(data.MESSAGE, { icon: 5 });
                                return false;
                            }
                        });
                    });
                }
            }

            /*用户-启用*/
            //function member_start(obj,id){
            //    layer.confirm('确认要启用吗？',function(index){
            //        //发异步把用户状态进行更改
            //        $(obj).parents("tr").find(".td-manage").prepend('<a style="text-decoration:none" onClick="member_stop(this,id)" href="javascript:;" title="停用"><i class="layui-icon">&#xe601;</i></a>');
            //        $(obj).parents("tr").find(".td-status").html('<span class="layui-btn layui-btn-normal layui-btn-mini">已启用</span>');
            //        $(obj).remove();
            //        layer.msg('已启用!',{icon: 6,time:1000});
            //    });
            //}
            // 用户-编辑
            function member_edit (title,url,id,w,h) {
                x_admin_show(title, url + "?guid=" + id, w, h);
            }
            /*密码-修改*/
            function member_password(title, url, id, w, h) {
                x_admin_show(title, url + "?guid=" + id, w, h);
            }
            /*用户-删除*/
            function member_del(obj,id){
                layer.confirm('确认要删除吗？', function (index) {
                    $.post("./member-list.aspx?delid=" + id, function (data) {
                        console.log(data);
                        var data = JSON.parse(data);
                        if (data.SUCCESS === 'true') {
                            //发异步删除数据
                            $(obj).parents("tr").remove();
                            layer.msg('已删除!', { icon: 1, time: 3000 });
                            return false;
                        } else {

                            //发异步，把数据提交给php
                            layer.alert(data.MESSAGE, { icon: 5 });
                            return false;
                        }
                    });
                });
            }
            //全选与取消全选
            let ischecked = false;
            function ischeckall() {
                if (ischecked) {
                    $('tbody tr td input[type="checkbox"]').each(function () {
                        this.checked = false;
                    });
                    ischecked = false;
                } else {
                    $('tbody tr td input[type="checkbox"]').each(function () {
                        this.checked = true;
                    });
                    ischecked = true;
                }
            }
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
