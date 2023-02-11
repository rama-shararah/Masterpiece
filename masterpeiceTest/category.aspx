<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="masterpeiceTest.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-text {
            text-align: right !important;
        }

        .card-body {
            border-top: 1px #E6E6E6 solid;
        }

        .card {
            border-color: #E6E6E6;
        }

        #con {
            width: 100%;
            display: flex;
        }

        #card-con {
            /*border: solid black 1px;*/
            display: inline-block;
            display: flex;
            flex-wrap: wrap !important;
            width: 80%;
            gap: 3rem 3rem;
        }

        #category {
            width: 20%;
            text-align: right;
            display: flex;
            flex-direction: column;
        }

            #category a {
                text-decoration: none;
            }

        .checked {
            color: orange;
        }

        h3 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h3 class="container">تمديدات كهربائية</h3>
    <br />
    <br />
    <div id="con" class="container">
        <div id="card-con">
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
            <a href="WebForm8.aspx" style="color: black; text-decoration: none">
                <div data-inviewport="scale" class="card col-lg-3 col-md-6" style="width: 19rem;">
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
        <div id="category">
            <h5>التصنيفات</h5>
            <br />
            <a href="category.aspx">تمديدات صحية</a>
            <br />

            <a href="category.aspx">تمديدات كهربائية</a>
            <br />
            <a href="category.aspx">البستنة والعناية بالحدائق</a>
        </div>

    </div>
    <br />
    <br />
    <%--    <nav aria-label="Page navigation example">
        <ul class="pagination">
            <li class="page-item">
                <a class="page-link" href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                </a>
            </li>
            <li class="page-item"><a class="page-link" href="category.aspx">1</a></li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
            <li class="page-item">
                <a class="page-link" href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                </a>
            </li>
        </ul>
    </nav>--%>
</asp:Content>
