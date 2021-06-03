<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gift-shop.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.gift_shop" %>

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
  <div class="shop-container">
    	<div class="main">
    		<h5>克诺尔礼品</h5>
            <div class="pro-list">
                
                <hr style="border-block-color:#004186" />
                	<div class="item-pro"  style="color:darkred">
            		<div  class=""></div>
                        <div class=""></div>
            		<div class="title"></div>
            		<div class="name-title">礼品</div>
                    <div class="stock-title">库存</div>
            		<div class="input-number-title">
            			数量
            		</div>
            		<div class="del-title">
            			操作
            		</div>
            	</div>
                <%foreach (var giftTemp in tbGiftTemps)
                    {%>
            	<div class="item-pro">
            		<div class="cir"></div>
            		<div class="product">
            			<img src="<%=gift.GetModel(giftTemp.GIFTGUID).IMAGE %>"/>
            		</div>
            		<div class="name"><%=giftTemp.GIFTNAME %></div>
                    <div class="stock"><%=gift.GetModel(giftTemp.GIFTGUID).NUMBER %></div>
            		<div class="input-number">
            			 <input type="text" id="base3" class="numPositive" value="<%=giftTemp.APPLYNUM %>" title="<%=giftTemp.GUID %>" oninput="NumChange('<%=giftTemp.GUID %>',this.value)"/>
            		</div>
            		<div class="del">
            			<span onclick="delgift('<%=giftTemp.GUID %>')">删除</span>
            		</div>
            	</div>
                   <% } %>
            </div>
            <div class="bom">
            	<div class="left">
            		<div class="cir"></div>
            		<a href="yg-index.aspx"><div class="text">继续添加</div></a>
            	</div>
            	<div class="right">
            		<%if (tbGiftTemps.Count > 0)
                        {%>
                    <span onclick="SubmitData()">提交</span>
                       <% } %>
            	</div>
            </div>
    	</div>
    </div>
    <link rel="stylesheet" type="text/css" href="./css/inputNumber.css"/>
    <script type="text/javascript" src="./js/jquery.inputNumber.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input.numPositive').inputNumber({
                negative: false //deny negative numbers
            });

        })
        function delgift(guid) {
            $.post("./gift-shop.aspx?op=delgift&guid=" + guid, function (data) {
                console.log(data);
                var data = JSON.parse(data);
                if (data.SUCCESS === 'true') {
                    window.location = './gift-shop.aspx';
                } else {
                    layer.alert(data.MESSAGE, { icon: 5 });
                    return false;
                }

            });
        }
        //提交
        function SubmitData() { //从库中获取是哪几个礼品
            $.post("./gift-shop.aspx?op=submit", function (data) {
                console.log(data);
                var data = JSON.parse(data);
                if (data.SUCCESS === 'true') {
                    window.location = './gift-shop.aspx';
                } else {
                    layer.alert(data.MESSAGE, { icon: 5 });
                    return false;
                }

            });
        }
        //数字改变
        function NumChange(guid, val) {
            $.post("./gift-shop.aspx?op=numchange&giftguid=" + guid + "&applynum=" + val, function (data) {
                console.log(data);
                var data = JSON.parse(data);
                if (data.SUCCESS === 'false') {
                    alert(data.MESSAGE);
                    parent.location.replace(parent.location.href);
                }

            });
        }
    </script>
    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
        }

        header {
            width: 800px;
            background: #004186;
            height: 30px;
            margin: 0 auto;
        }

        .shop-container {
        }

            .shop-container .main {
                width: 800px;
                margin: 0 auto;
            }

                .shop-container .main h5 {
                    color: #004186;
                    font-size: 18px;
                    line-height: 50px;
                }

            .shop-container .item-pro {
                margin-top: 10px;
                display: flex;
                padding: 10px 30px;
                color: #004186;
            }

                .shop-container .item-pro .cir {
                    width: 12px;
                    height: 12px;
                    border-radius: 6px;
                    background: #004186;
                    margin-top: 60px;
                }

                .shop-container .item-pro .product {
                    border: 1px solid #ddd;
                    margin: 0 20px;
                }
                      .shop-container .item-pro .title {
                    width: 300px;
                    text-align: center;
                    line-height: 15px;
                }
                               .shop-container .item-pro .name-title {
                    width: 300px;
                    text-align: center;
                    line-height: 15px;
                }
                         .shop-container .item-pro .stock-title {
                    width: 300px;
                    text-align: center;
                    line-height: 15px;
                }
                           .shop-container .item-pro .input-number-title {
                    width: 100px;
                    text-align: center;
                     line-height: 15px;
                }
                             .shop-container .item-pro .del-title {
                    line-height: 15px;
                    width: 150px;
                    text-align: center;
                }
                .shop-container .item-pro .name {
                    width: 300px;
                    text-align: center;
                    line-height: 120px;
                }
                 .shop-container .item-pro .stock {
                    width: 300px;
                    text-align: center;
                    line-height: 120px;
                }

                .shop-container .item-pro .input-number {
                    margin-top: 50px;
                    width: 100px;
                    text-align: center;
                }

                .shop-container .item-pro .del {
                    line-height: 120px;
                    width: 150px;
                    text-align: center;
                }

                .shop-container .item-pro img {
                    width: 140px;
                    height: 140px;
                }

        .bom {
            margin-top: 20px;
            display: flex;
            color: #004186;
        }

            .bom .left {
                border: 1px solid #004186;
                width: 620px;
                line-height: 50px;
                display: flex;
                padding: 0 25px;
            }

            .bom .cir {
                width: 12px;
                height: 12px;
                border-radius: 6px;
                background: #004186;
                margin-top: 20px;
            }

            .bom .text {
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