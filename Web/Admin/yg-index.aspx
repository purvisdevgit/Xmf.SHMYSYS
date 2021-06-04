<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yg-index.aspx.cs" Inherits="Xmf.SHMYSYS.Web.Admin.yg_index" %>

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
        <div class="layui-header header header-demo" style="background: #014188; border-bottom: 1px solid #FFF">
            <div class="layui-main">
                <a class="logo" href="./index.aspx">克诺尔礼品系统控制台v1.0
                </a>
                <ul class="layui-nav" lay-filter="">
                    <li class="layui-nav-item">
                        <img src="./images/logo.png" class="layui-circle" style="border: 2px solid #A9B7B7;" width="35px" alt=""></li>
                    <li class="layui-nav-item">
                        <a href="javascript:;"><%=TbUser.EMAIL %></a>
                        <dl class="layui-nav-child">
                            <!-- 二级菜单 -->
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
        <div class="container">
            <div class="banner-img"></div>
            <h4 class="type-title">产品分类
            </h4>

            <div class="product-list">
                <div class="left-arrow arrow">
                    <img src="./images/left-arrow.jpg" /></div>
                <div class="content">
                    <div id="con-list" class="con-list">
                        <%foreach (var gift in tbGifts)
                            {%>
                        <%-- <a href="./gift-detail.aspx?giftguid=<%=gift.GUID %>">--%>
                        <div class="item-pro">
                            <p style="height:25px"></p>
                            <img src="<%=gift.IMAGE %>" class="img" />
                            <p style="height:10px"></p>
                                <p><%=gift.GIFTNAME %></p>
                            <p style="height:10px"></p>
                            <a href="./gift-shop.aspx?giftguid=<%=gift.GUID %>" class="xgclass">选购</a>
                        </div>

                        <%}
                        %>
                    </div>
                </div>
                <div class="right-arrow arrow">
                    <img src="./images/right-arrow.jpg" /></div>
            </div>
            <div class="imgPreview">
                <img src="#" alt="" id="imgPreview">
            </div>
            <div class="bom">
                <div class="left">
                </div>
                <div class="right" onclick="allData()">
                    <span>全部</span>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            let scroll = 0;
            $('.right-arrow').click(function () {
                let width = $('.con-list').width();
                if (scroll > width - 100) {
                    return;
                }
                scroll += 100;
                $(".product-list .content").animate({
                    scrollLeft: scroll
                }, 400);
            })
            $('.left-arrow').click(function () {
                if (scroll === 0) {
                    return;
                }
                scroll -= 100;
                if (scroll <= 0) {
                    scroll === 0
                }
                $(".product-list .content").animate({
                    scrollLeft: scroll
                }, 400);
            })
            $('.img').on('click', function () {
                var src = $(this).attr('src');
                $('.imgPreview img').attr('src', src);
                $('.imgPreview').show()
            });
            $('.imgPreview').on('click', function () {
                $('.imgPreview').hide()
            });
        })

        function allData() {
            $('#con-list').removeAttr("class");
        }
    </script>

    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
        }

        header {
            background: #004186;
            color: #fff;
            height: 50px;
        }

            header .main {
                width: 1280px;
                margin: 0 auto;
                display: flex;
            }

            header .left {
                width: 50%;
                font-size: 20px;
                line-height: 50px;
            }

            header .right {
                width: 50%;
                text-align: right;
                line-height: 50px;
            }

                header .right .mail {
                    margin: 0 10px;
                }

            header .logo {
                height: 40px;
            }

        .container {
            width: 1200px;
            margin: 20px auto;
        }

            .container .banner-img {
                height: 400px;
                width: 100%;
                background: url('./images/banner.jpg') no-repeat;
                background-size: cover;
            }

            .container .type-title {
                padding: 5px 10px;
                line-height: 30px;
                background: #004186;
                color: #fff;
            }

        .product-list {
            margin-top: 20px auto;
            display: flex;
        }

            .product-list .item-pro {
                float: left;
                margin-left: 40px;
                height:250px;
                text-align:center;
            }

                .product-list .item-pro img {
                    width: 160px;
                }

                .product-list .item-pro p {
                    width: 160px;
                    text-align: center;
                }

            .product-list .arrow {
                width: 60px;
                margin-top: 50px;
                cursor: pointer;
            }

                .product-list .arrow img {
                    width: 60px;
                }

            .product-list .content {
                width: calc(100% - 120px);
                /*height: 200px;*/
                overflow-x: auto;
            }

                .product-list .content .con-list {
                    white-space: nowrap;
                    display: flex;
                }

        .bom {
            margin-top: 20px;
            display: flex;
            color: #004186;
        }

            .bom .left {
                /*border: 1px solid #004186;*/
                width: 100%;
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

        .imgPreview {
            display: none;
            top: 0;
            left: 0;
            width: 100%; /*容器占满整个屏幕*/
            height: 100%;
            position: fixed;
            background: rgba(0, 0, 0, 0.5);
        }

            .imgPreview img {
                z-index: 100;
                width: 40%;
                position: fixed;
                top: 50%;
                left: 50%;
                transform: translate(-50%,-50%);
            }
        /*添加鼠标移入图片效果*/
        .img {
            cursor: url("ico/放大镜.png"), auto;
        }
        .xgclass {
          height: 18px;
            line-height: 18px;
            padding: 0 11px;
            background: #004186;
          /*  border: 1px #26bbdb solid;
            border-radius: 3px;*/
            /*color: #fff;*/
            display: inline-block;
            text-decoration: none;
            font-size: 12px;
            outline: none;
            color:white;
            width:50px;
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
