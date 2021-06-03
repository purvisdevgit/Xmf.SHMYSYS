<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
        <title>
            克诺尔礼品系统控制台v1.0
        </title>
        <meta name="renderer" content="webkit">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
        <meta name="apple-mobile-web-app-status-bar-style" content="black">
        <meta name="apple-mobile-web-app-capable" content="yes">
        <meta name="format-detection" content="telephone=no">
        <link rel="stylesheet" href="./css/x-admin.css" media="all">
    </head>
    <body>
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header header header-demo" style="background:#014188;border-bottom:1px solid #FFF">
                <div class="layui-main">
                    <a class="logo" href="./index.aspx">
                        克诺尔礼品系统控制台v1.0
                    </a>
                    <ul class="layui-nav" lay-filter="">
                      <li class="layui-nav-item"><img src="./images/logo.png" class="layui-circle" style="border: 2px solid #A9B7B7;" width="35px" alt=""></li>
                      <li class="layui-nav-item">
                        <a href="javascript:;"><%=TbUser.EMAIL %></a>
                        <dl class="layui-nav-child"> <!-- 二级菜单 -->
                          <dd><a href="">个人信息</a></dd>
                          <dd><a href="./Login.aspx">退出</a></dd>
                        </dl>
                      </li>
                      <!-- <li class="layui-nav-item">
                        <a href="" title="消息">
                            <i class="layui-icon" style="top: 1px;">&#xe63a;</i>
                        </a>
                        </li> -->
                      <li class="layui-nav-item x-index"><a href="/Admin/index.aspx">前台首页</a></li>
                    </ul>
                </div>
            </div>
            <div class="layui-side layui-bg-black x-side" style="background:#014188">
                <div class="layui-side-scroll">
                    <ul class="layui-nav layui-nav-tree site-demo-nav" lay-filter="side" style="background:#014188">
                         <%if(TbUser.ROLE=="{1261305D-F882-44FE-9F0B-3E7D37DBEBD6}")//员工
                             {
                                    %>
                        <li class="layui-nav-item">
                            <a class="javascript:;" _href="./yg-index.aspx" href="./yg-index.aspx" >
                                <i class="layui-icon" style="top: 3px;">&#xe608;</i><cite>申请礼品</cite>
                            </a>
                        </li>
                         <li class="layui-nav-item">
                            <a class="javascript:;" _href="./gift-list.aspx?giftstate=0" >
                                <i class="layui-icon" style="top: 3px;">&#xe649;</i><cite>申请记录</cite>
                            </a>
                        </li>
                        <% }
                                    %>
                         <%if(TbUser.ROLE=="{C95C99D2-382E-4670-8849-3802558E7778}")//主管
                             {
                                    %>
                         <li class="layui-nav-item">
                            <a class="javascript:;" _href="./gift-list.aspx?giftstate=1">
                                <i class="layui-icon" style="top: 3px;">&#xe605;</i><cite>审核礼品</cite>
                            </a>
                        </li>
                         <% }
                                    %>
                         <%if(TbUser.ROLE=="{3A918B1C-597C-417D-BF03-A7504B4CA411}")//系统管理员
                             {
                                    %>
                         <li class="layui-nav-item">
                            <a class="javascript:;" _href="./gift-list.aspx?giftstate=2">
                                <i class="layui-icon" style="top: 3px;">&#x1005;</i><cite>发放礼品</cite>
                            </a>
                        </li>
                        <li class="layui-nav-item">
                            <a class="javascript:;" _href="./gift-maintain.aspx">
                                <i class="layui-icon" style="top: 3px;">&#xe600;</i><cite>礼品维护</cite>
                            </a>
                        </li>
                        <li class="layui-nav-item">
                            <a class="javascript:;" _href="./member-list.aspx">
                                <i class="layui-icon" style="top: 3px;">&#xe650;</i><cite>人员维护</cite>
                            </a>
                        </li>
                        <% }
                                    %>
                   <%--     <li class="layui-nav-item">
                            <a class="javascript:;" href="javascript:;">
                                <i class="layui-icon" style="top: 3px;" >&#xe642;</i><cite>权限管理</cite>
                            </a>
                        </li>
                        <li class="layui-nav-item">
                            <a class="javascript:;" href="javascript:;">
                                <i class="layui-icon" style="top: 3px;">&#xe630;</i><cite>角色管理</cite>
                            </a>
                        </li>--%>
                    </ul>
                </div>

            </div>
            <div class="layui-tab layui-tab-card site-demo-title x-main" lay-filter="x-tab" lay-allowclose="true">
                <div class="x-slide_left"></div>
                <ul class="layui-tab-title">
                    <li class="layui-this">
                        个人信息
                        <i class="layui-icon layui-unselect layui-tab-close">ဆ</i>
                    </li>
                </ul>
                <div class="layui-tab-content site-demo site-demo-body">
                    <div class="layui-tab-item layui-show">
                        <iframe frameborder="0" src="./MyInfo.aspx?guid=<%=TbUser.GUID %>" class="x-iframe"></iframe>
                    </div>
                </div>
            </div>
            <div class="site-mobile-shade">
            </div>
        </div>
        <script src="./lib/layui/layui.js" charset="utf-8"></script>
        <script src="./js/x-admin.js"></script>
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
