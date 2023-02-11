<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="masterpeiceTest.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #row {
            text-align: right;
            border: solid #E6E6E6 1px;
            border-radius: 4px;
            width: 100%;
        }

        .card-body {
            border-top: 1px #E6E6E6 solid;
        }

        #text {
            font-size: 20px;
        }

        .link-muted {
            color: #aaa;
        }

            .link-muted:hover {
                color: #1266f1;
            }

        .me-3 {
            margin-left: 1rem;
        }

        .checked {
            color: orange;
        }

        @media (min-width: 1200px) {
            .col-xl-7 {
                flex: 0 0 auto;
                width: 100%;
            }
        }

        .con {
            display: flex;
        }

        ::placeholder {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />

    <%--    <iframe class="position-relative w-100 h-100" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3384.9027362142688!2d35.90633641511676!3d31.963535281225205!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x151ca07174125973%3A0x6853dfe334a6f144!2sAbdali%20Mall!5e0!3m2!1sen!2sbd!4v1674673282044!5m2!1sen!2sbd"
        frameborder="0" style="min-height: 450px; border: 0;" allowfullscreen="" aria-hidden="false"
        tabindex="0"></iframe>--%>
    <div class="container">
        <div id="row" class="row">

            <div id="text" class="col-md-7">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-8">
                            <div style="text-align: right;">
                                <span class="fa fa-star"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            التقييم
                        </div>
                    </div>

                    <div class="row mt-3">
                        <div class="col-md-8">
                            الحي الجنوبي
                            
                        </div>
                        <div class="col-md-4">
                            مكان الاقامة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-8">
                            0776610148
                        </div>
                        <div class="col-md-4">
                            رقم الهاتف
                        </div>
                    </div>

                    <div class="row mt-3">
                        <div class="col-md-8">
                            دنانير7
                        </div>
                        <div class="col-md-4">
                            متوسط سعر الساعة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-8">
                            9-9
                        </div>
                        <div class="col-md-4">
                            ساعات العمل
                        </div>
                    </div>

                    <div class="row mt-3">
                        <div class="col-md-8">
                            2
                                              
                        </div>
                        <div class="col-md-4">
                            عدد العملاء
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-8">
                            <p>تركيب أو إصلاح أنظمة الأنابيب وتركيبات تركيب أو إصلاح أنظمة الأنابيب وتركيبات</p>

                        </div>
                        <div class="col-md-4">
                            وصف الخدمة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-8">
                            <button class="btn btn-success">طلب الخدمة</button>

                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                    <div class="mt-5 text-right">
                    </div>
                </div>
            </div>

            <div data-inviewport="scale" class="card col-md-5" style="width: 33.6rem; border-radius: 0px">
                <img src="pic/man1.png" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">محمد سعيد</p>
                    <p style="font-size: 14px;" class="card-text">كهربائي</p>

                </div>
            </div>
        </div>
    </div>
    <br />
    <br />

    <div class="container">
        <h2 class="container" style="text-align: right;">الآراء و التعليقات</h2>
    </div>
    <section>
        <div class="container my-5 py-5 text-dark">
            <div class="row d-flex justify-content-center">
                <div class="coment-bottom bg-white p-2 px-4">
                    <div class="d-flex flex-row add-comment-section mt-4 mb-4">

                        <button class="btn btn-success" style="width: 15%; margin-right: 1rem;" type="button">تعليق</button>
                        <input type="text" class="form-control mr-3" placeholder="اضف تعليق">
                        <img class="rounded-circle shadow-1-strong me-3"
                            src="pic/nn.jpg" alt="avatar" width="55"
                            height="55" />
                    </div>
                </div>
                <div class="col-md-11 col-lg-9 col-xl-7">

                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">
                                    <div class="col-md-3" style="text-align: right;">
                                        <span class="fa fa-star"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                    </div>
                                    <div class="col-md-9">
                                        <h5>أحمد شرارة</h5>
                                        <p class="small">قبل 3 ساعات</p>
                                        <p>
                                            خدمة ممتازة وجودة في الخدمة شكرا جزيلا على المجهود
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <img class="rounded-circle shadow-1-strong me-3"
                            src="pic/nn.jpg" alt="avatar" width="65"
                            height="65" />
                    </div>
                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">
                                    <div class="col-md-3" style="text-align: right;">
                                        <span class="fa fa-star"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                    </div>
                                    <div class="col-md-9">
                                        <h5>أحمد شرارة</h5>
                                        <p class="small">قبل 3 ساعات</p>
                                        <p>
                                            خدمة ممتازة وجودة في الخدمة شكرا جزيلا على المجهود
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <img class="rounded-circle shadow-1-strong me-3"
                            src="pic/nn.jpg" alt="avatar" width="65"
                            height="65" />
                    </div>
                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">
                                    <div class="col-md-3" style="text-align: right;">
                                        <span class="fa fa-star"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                        <span class="fa fa-star checked"></span>
                                    </div>
                                    <div class="col-md-9">
                                        <h5>أحمد شرارة</h5>
                                        <p class="small">قبل 3 ساعات</p>
                                        <p>
                                            خدمة ممتازة وجودة في الخدمة شكرا جزيلا على المجهود 
                                            خدمة ممتازة وجودة في الخدمة شكرا جزيلا على المجهود
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <img class="rounded-circle shadow-1-strong me-3"
                            src="pic/nn.jpg" alt="avatar" width="65"
                            height="65" />
                    </div>
                </div>
            </div>

        </div>

    </section>

</asp:Content>
