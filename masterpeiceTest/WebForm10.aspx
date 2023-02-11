<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="masterpeiceTest.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 1200px) {
            .col-xl-7 {
                flex: 0 0 auto;
                width: 90%;
            }
        }

        .con {
            display: flex;
        }

        .me-3 {
            margin-left: 1rem;
        }

        .p-4 {
            padding: 1rem !important;
        }

        h3 {
            text-align: right;
        }

        body {
            background-color: #F4F4F4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h3 class="container">الطلبات الواردة</h3>
    <section>
        <div class="container my-5 py-5 text-dark">
            <div class="row d-flex justify-content-center">

                <div class="col-md-11 col-lg-9 col-xl-7">
                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">

                                    <div class="col-md-2" style="text-align: right;">
                                        <a href="https://goo.gl/maps/KwcSKUcnbTpfeXQL6">
                                            <h5>الموقع</h5>
                                        </a>

                                    </div>
                                    <div class="col-md-4" style="text-align: right;">
                                        <h5>رقم الهاتف:0776610148</h5>

                                    </div>
                                    <div class="col-md-3">
                                        <h5>الحي الجنوبي</h5>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>أحمد شرارة<i style="font-size: 10px; color: red; margin-left: 5%;" class="fa-solid fa-circle"></i></h5>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <br />
                    <br />
                    <br />

                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">

                                    <div class="col-md-2" style="text-align: right;">
                                        <a href="https://goo.gl/maps/KwcSKUcnbTpfeXQL6">
                                            <h5>الموقع</h5>
                                        </a>

                                    </div>
                                    <div class="col-md-4" style="text-align: right;">
                                        <h5>رقم الهاتف:0776610148</h5>

                                    </div>
                                    <div class="col-md-3">
                                        <h5>الحي الجنوبي</h5>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>أحمد شرارة</h5>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="d-flex flex-start mb-4">
                        <div class="card w-100">
                            <div class="card-body p-4">
                                <div class="con">

                                    <div class="col-md-2" style="text-align: right;">
                                        <a href="https://goo.gl/maps/KwcSKUcnbTpfeXQL6">
                                            <h5>الموقع</h5>
                                        </a>

                                    </div>
                                    <div class="col-md-4" style="text-align: right;">
                                        <h5>رقم الهاتف:0776610148</h5>

                                    </div>
                                    <div class="col-md-3">
                                        <h5>الحي الجنوبي</h5>
                                    </div>
                                    <div class="col-md-3">
                                        <h5>أحمد شرارة</h5>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </section>
</asp:Content>
