﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="masterpeiceTest.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #background {
            background-color: #E6E6E6;
        }

        #mainPic {
            width: 40%;
        }

        #search {
            z-index: 3;
            position: absolute;
            top: 55%;
            left: 15%;
            width: 35%;
        }

        #question {
            z-index: 3;
            position: absolute;
            top: 40%;
            left: 12%;
            width: 40%;
            font-size: 45px;
        }

        #categoryCon {
            display: flex;
            /*justify-content: space-between;*/
            flex-wrap: wrap;
            width: 100%;
            height: 55vh;
            /*border: solid black;*/
            gap: 30px;
        }

        h2 {
            text-align: right;
        }

        .con {
            position: relative;
        }

            .con:hover > img {
                transform: scale(105%);
            }



        #con2 {
            display: flex;
            justify-content: space-between;
            border: solid tomato;
        }


        .center {
            position: absolute;
            top: 45%;
            left: 20%;
            font-size: 30px;
            color: white;
        }

        .card-text {
            text-align: right !important;
        }

        .card-body {
            background-color: white;
            border-top: 1px #E6E6E6 solid;
        }

        .card {
            /* border-color: #606060;*/
        }

        #con3 {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 90vh;
        }

        #gray {
            width: 80%;
            height: 70%;
            background-color: #E6E6E6;
            border-radius: 100px;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            gap: 20%;
        }

        #join {
            font-size: 70px;
        }

        .checked {
            color: orange;
        }

        [data-inviewport="scale-in"] {
            transition: 1s;
            transform: translateY(-60px);
        }

            [data-inviewport="scale-in"].is-inViewport {
                transform: translateY(20px);
            }

        [data-inviewport="scale"] {
            transition: 1s;
            transform: translateX(60px);
        }

            [data-inviewport="scale"].is-inViewport {
                transform: translateX(10px);
            }


        .portfolio-inner::before, .portfolio-inner::after {
            background: rgb(6 6 6 / 60%) !important;
        }

        @media only screen and (min-device-width: 0px) and (max-device-width: 480px) {
            #question {
                top: 10%;
                font-size: 35px;
                text-align: center;
            }

            #search {
                top: 18%;
            }

            #join {
                font-size: 45px;
            }

            #gray {
                width: 80%;
                height: 50%;
            }

            #con3 {
                height: 35vh;
            }
        }

        @media only screen and (min-device-width: 481px) and (max-device-width: 768px) {
            #question {
                top: 30%;
                font-size: 29px;
                text-align: center;
            }

            #search {
                top: 40%;
            }

            #join {
                font-size: 40px;
            }

            #gray {
                width: 80%;
                height: 50%;
            }

            #con3 {
                height: 80vh;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleFade" class="carousel slide carousel-fade" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="pic/My project-5 (1).png" class="d-block w-100" alt="..." />
            </div>

            <div class="carousel-item">
                <img src="pic/My project-7.png" class="d-block w-100" alt="..." />
            </div>
            <div class="carousel-item">
                <img src="pic/My project-8.png" class="d-block w-100" alt="..." />
            </div>
            <%--            <div class="carousel-item">
                <img src="pic/My project-10.png" class="d-block w-100" alt="..." />
            </div>--%>
        </div>

    </div>

    <div id="search">
        <div class="d-flex" role="search">
            <button class="btn btn-success" style="background-color: #45962C; font-size: 20px;" type="submit">بحث</button>
            <input class="form-control me-2" style="height: 60px;" type="search" placeholder="" aria-label="Search" />
        </div>
    </div>
    <div id="question">ما الخدمة التي تبحث عنها اليوم ؟</div>
    <br />
    <br />
    <br />
    <h2 class="container">الخدمات المتاحة</h2>


    <%--    <div id="categoryCon" class="container">
        <a href="home.aspx">
            <div data-inviewport="scale-in" class="con">
                <img style="width: 300px; height: 350px;" src="pic/elec.png" />
                <div class="center">تمديدات كهربائية</div>
            </div>
        </a>
        <a href="home.aspx">
            <div data-inviewport="scale-in" class="con">
                <img style="width: 300px; height: 350px;" src="pic/garden1.png" />
                <div class="center">العناية بالحدائق</div>
            </div>
        </a>
        <a href="home.aspx">
            <div data-inviewport="scale-in" class="con">
                <img style="width: 300px; height: 350px;" src="pic/bbb.png" />
                <div class="center">تمديدات صحية</div>
            </div>
        </a>
        <a href="home.aspx">
            <div data-inviewport="scale-in" class="con">
                <img style="width: 300px; height: 350px;" src="pic/clean1.png" />
                <div class="center">خدمات تنظيف</div>
            </div>
        </a>
    </div>--%>
    <br />

    <div class="container-xxl py-5">
        <div class="container">
            <div class="row g-4 portfolio-container">
                <div class="col-lg-4 col-md-6 portfolio-item first wow fadeInUp" data-wow-delay="0.1s">
                    <a href="category.aspx" style="text-decoration: none">
                        <div class="portfolio-inner rounded">
                            <img src="pic/electro.jpg" alt="" width="420" height="420">
                            <div class="portfolio-text">
                                <h4 class="text-white mb-4">تمديدات كهربائية</h4>
                            </div>
                        </div>
                    </a>

                </div>
                <div class="col-lg-4 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.3s">
                    <a href="category.aspx" style="text-decoration: none">
                        <div class="portfolio-inner rounded">
                            <img src="pic/masora.jpg" alt="" width="420" height="420">
                            <div class="portfolio-text">
                                <h4 class="text-white mb-4">تمديدات صحية</h4>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4 col-md-6 portfolio-item first wow fadeInUp" data-wow-delay="0.5s">
                    <a href="category.aspx" style="text-decoration: none">
                        <div class="portfolio-inner rounded">
                            <img src="pic/garden.jpg" alt="" width="420" height="420">
                            <div class="portfolio-text">
                                <h4 class="text-white mb-4">العناية بالحدائق</h4>
                            </div>
                        </div>
                    </a>
                </div>
                <%--                <div class="col-lg-3 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.1s">
                    <a href="#">
                        <div class="portfolio-inner rounded">
                            <img src="pic/clea.jpg" alt="" width="300" height="320">
                            <div class="portfolio-text">
                                <h4 class="text-white mb-4">خدمات تنظيف</h4>
                            </div>
                        </div>
                    </a>
                </div>--%>
            </div>
        </div>
    </div>

    <br />
    <h2 class="container">الاكثر طلبا</h2>
    <br />
    <br />
    <div class="container-xxl py-5">
        <div class="container">
            <div class="row g-4 portfolio-container">
                <div class="col-lg-3 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.1s">
                    <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                        <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                            <img src="pic/man1.png" class="card-img-top" alt="...">
                            <div class="card-body">
                                <p class="card-text">محمد سعيد</p>
                                <p style="font-size: 14px;" class="card-text">كهربائي</p>
                                <div style="text-align: right;">
                                    <span class="fa fa-star"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.1s">
                    <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                        <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                            <img src="pic/man1.png" class="card-img-top" alt="...">
                            <div class="card-body">
                                <p class="card-text">محمد سعيد</p>
                                <p style="font-size: 14px;" class="card-text">كهربائي</p>
                                <div style="text-align: right;">
                                    <span class="fa fa-star"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-3 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.1s">
                    <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                        <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                            <img src="pic/man1.png" class="card-img-top" alt="...">
                            <div class="card-body">
                                <p class="card-text">محمد سعيد</p>
                                <p style="font-size: 14px;" class="card-text">كهربائي</p>
                                <div style="text-align: right;">
                                    <span class="fa fa-star"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-lg-3 col-md-6 portfolio-item second wow fadeInUp" data-wow-delay="0.1s">
                    <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                        <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                            <img src="pic/man1.png" class="card-img-top" alt="...">
                            <div class="card-body">
                                <p class="card-text">محمد سعيد</p>
                                <p style="font-size: 14px;" class="card-text">كهربائي</p>
                                <div style="text-align: right;">
                                    <span class="fa fa-star"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                    <span class="fa fa-star checked"></span>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>


            </div>
        </div>
    </div>
    <%--<div class="container-xxl py-5">
        <div class="container">
            <div class="row g-4 portfolio-container">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                    <img src="pic/man1.png" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">محمد سعيد</p>
                        <p style="font-size: 14px;" class="card-text">كهربائي</p>
                        <div style="text-align: right;">
                            <span class="fa fa-star"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>
                    </div>
                </div>
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                    <img src="pic/man1.png" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">محمد سعيد</p>
                        <p style="font-size: 14px;" class="card-text">كهربائي</p>
                        <div style="text-align: right;">
                            <span class="fa fa-star"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>
                    </div>
                </div>

                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                    <img src="pic/man1.png" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">محمد سعيد</p>
                        <p style="font-size: 14px;" class="card-text">كهربائي</p>
                        <div style="text-align: right;">
                            <span class="fa fa-star"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>
                    </div>
                </div>
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 18rem;">
                    <img src="pic/man1.png" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">محمد سعيد</p>
                        <p style="font-size: 14px;" class="card-text">كهربائي</p>
                        <div style="text-align: right;">
                            <span class="fa fa-star"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                            <span class="fa fa-star checked"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <br />
    <br />

    <div id="con3">
        <div id="gray" class="container">
            <div id="join">!انضم الى خدمات و قدم خدمتك الان</div>
            <a href="WebForm5.aspx" class="btn btn-success" style="background-color: #45962C; font-size: 35px;">اشترك الان</a>
        </div>
    </div>

    <script>
        const inViewport = (entries, observer) => {
            entries.forEach(entry => {
                entry.target.classList.toggle("is-inViewport", entry.isIntersecting);
            });
        };

        const Obs = new IntersectionObserver(inViewport);
        const obsOptions = {};

        // Attach observer to every [data-inviewport] element:
        const ELs_inViewport = document.querySelectorAll('[data-inviewport]');
        ELs_inViewport.forEach(EL => {
            Obs.observe(EL, obsOptions);
        });
    </script>
</asp:Content>
