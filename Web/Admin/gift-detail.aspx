<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift-detail.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.gift_detail" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 	<title>克诺尔礼品系统控制台v1.0</title>
	<meta charset="utf-8">
	<%--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">--%>
	<script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
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
                      <li class="layui-nav-item"><img src="<%if (string.IsNullOrEmpty(user.AVATAR))
                                                     {%>./images/logo.png<%}
                                                     else
                                                     {%><%=user.AVATAR %> <%}%>"" class="layui-circle" style="border: 2px solid #A9B7B7;" width="35px" alt=""></li>
                      <li class="layui-nav-item">
                        <a href="javascript:;"><%=user.EMAIL %></a>
                        <dl class="layui-nav-child"> <!-- 二级菜单 -->
                         <dd><a href="./index.aspx?op=grxx">个人信息</a></dd>
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
  <div class="detail-container">
  	 <div class="content">
  	 	<div class="left">
  	 		<img src="<%=vgift.IMAGE %>"/>
  	 	</div>
  	 	<div class="right">
  	 		<h5><%=vgift.GIFTNAME %></h5>
  	 		<p><%=vgift.DETAIL %></p>
               <%--<p><%=vgift.ADDTIME %></p>--%>
  	 	</div>
  	 </div>
  	 <div class="content-type">
  	 	<div class="type-top">
  	 		<span style="width:285px">编号</span>
  	 		<span>名称</span>
  	 		<span>数量</span>
  	 		<span>上架时间</span>
  	 	</div>
  	 	<div class="type-con">
  	 		<span style="width:285px"><%=vgift.GUID %></span>
  	 		<span><%=vgift.GIFTNAME %></span>
  	 		<span><%=vgift.NUMBER %></span>
  	 		<span><%=vgift.ADDTIME %></span>
  	 	</div>
           <div class="bom">
            	<div class="left">
            	</div>
               <a href="./gift-shop.aspx?giftguid=<%=vgift.GUID %>">
            	<div class="right">
            		<span>挑选</span>
            	</div>
                   </a>
            </div>
  	 </div>
  </div>
       </div>

  <style type="text/css">
  	*{
  		padding: 0;
  		margin: 0;
  	}
  	header{
  		width: 800px;
  		background: #004186;
   	 	height: 50px;
   	 	margin: 0 auto;
  	}
  	.detail-container{
  		width: 800px;
  		margin: 0 auto;
  	}
  	.detail-container .content{
  		padding: 40px 0;
  		display: flex;
  		color: #004186;
  		justify-content: space-between;
  	}
  	.detail-container .content img{
  		width: 300px;
  	}
  	.detail-container .content .right{
  		width: 400px;
  		padding: 50px 0 0;
  	}
  	.detail-container .content h5{
  		font-size: 24px;
  		margin-bottom: 30px;
  	}
  	.detail-container .content-type{
  		margin-top: 20px;
  		margin-bottom: 50px;
  		border-bottom: 1px solid #ddd;
  	}
  	.detail-container .content-type .type-top{
  		background: #004186;
  		min-height: 40px;
  		line-height: 40px;
  		color: #fff;
  	}
  	.detail-container .content-type span{
       display: inline-block;
       width: 20%;
       text-align: center;
  	}
  	.detail-container .content-type .type-con{
  		line-height: 50px;
  		margin-bottom: 50px;
  	}
       	.bom{
   		margin-top: 20px;
   		display: flex;
   		color: #004186;
   	}
   	.bom .left{
   		border: 1px solid #004186;
   		width: 680px;
   		line-height: 50px;
   		display: flex;
   		padding: 0 25px;
   	}
   	.bom .cir{
   		width: 12px;
   		height: 12px;
   		border-radius: 6px;
   		background: #004186;
   		margin-top: 20px;
   	}
   	.bom .text{
   		margin-left: 20px;
   		font-weight: bold;
   	}
   	.bom .right span {
   		display: inline-block;
   		background: #004186;
   		color: #FFF;
   		line-height: 54px;
   		height: 54px;
   		width: 130px;
   		text-align: center;
   	}
  </style>
</body>
</html>
   <script src="./lib/layui/layui.js" charset="utf-8"></script>
        <script src="./js/x-admin.js"></script>
        <script>
            var _hmt = _hmt || [];
            (function () {
                var hm = document.createElement("script");
                hm.src = "https://hm.baidu.com/hm.js?b393d153aeb26b46e9431fabaf0f6190";
                var s = document.getElementsByTagName("script")[0];
                s.parentNode.insertBefore(hm, s);
            })();
        </script>