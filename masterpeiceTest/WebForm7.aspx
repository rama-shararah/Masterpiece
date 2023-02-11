<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="masterpeiceTest.WebForm7" %>

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

        #img {
            border: 1px solid #E6E6E6;
        }


        /*body {
            background: #E6E6E6;
        }

        .form-control:focus {
            box-shadow: none;
            border-color: #BA68C8;
        }

        .profile-button {
            background: #45962C;
            box-shadow: none;
            border: none;
        }

            .profile-button:hover {
                background: #327829;
            }

            .profile-button:focus {
                background: #45962C;
                box-shadow: none;
            }

            .profile-button:active {
                background: #45962C;
                box-shadow: none;
            }

        .back:hover {
            color: #45962C;
            cursor: pointer;
        }

        ::placeholder {
            text-align: right;
        }

        .font-weight-bold {
            font-size: 20px;
        }

        #img {
            border: 1px solid #E6E6E6;
        }

        .checked {
            color: orange;
        }

        #row {
            text-align: right;
            border: solid #E6E6E6 1px;*/
        /*            border-radius: 10px;
            box-shadow: 10px 10px #E6E6E6;*/
        /*width: 50%;
        }

        #con {
            display: flex;
            flex-direction: row;
            align-items: center;
        }

        .right {
            text-align: right;
        }*/

        /*        .mt-3 mt-2 {
            margin-right: 10px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container">
        <div id="row" class="row">

            <div id="text" class="col-md-7">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <div class="d-flex flex-row align-items-center back">
                            <a href="edit.aspx" style="color: black;"><i class="fa-solid fa-pen-to-square"></i></a>
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
                            تمديدات صحية
                        </div>
                        <div class="col-md-4">
                            الخدمة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-8">
                            تركيب أو إصلاح أنظمة الأنابيب وتركيبات تركيب أو إصلاح أنظمة الأنابيب وتركيبات
                            
                        </div>
                        <div class="col-md-4">
                            وصف الخدمة
                        </div>
                    </div>
                    <div class="mt-5 text-right">
                    </div>
                </div>
            </div>
            <div class="col-md-5 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5">


                    <img id="img" class="rounded-circle mt-5" src="pic/man1.png" width="310" height="300"><span class="font-weight-bold">محمد سعيد</span><span class="text-black-50">mohammad147@gmail.com</span>
                    <div style="text-align: right;">
                        <span class="fa fa-star"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                    </div>
                    <br />
                    <select style="width: 20%;" class="form-select">
                        <option>متاح</option>
                        <option>غير متاح</option>
                    </select>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />



    <%--    <div id="con" class="container rounded bg-white mt-5">
        <div id="row" class="row col-md-6">

            <div class="col-md-12">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <div class="d-flex flex-row align-items-center back">
                            <a href="edit.aspx" style="color: black;"><i class="fa-solid fa-pen-to-square"></i></a>
                        </div>

                    </div>
                    <div class="row mt-2">
                        <div class="col-md-6">
                            محمد
                        </div>
                        <div class="col-md-6">
                            الاسم الاول
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            سعيد
                        </div>
                        <div class="col-md-6">
                            الاسم الثاني
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            الحي الجنوبي
                            
                        </div>
                        <div class="col-md-6">
                            مكان الاقامة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            0776610148
                        </div>
                        <div class="col-md-6">
                            رقم الهاتف
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            تمديدات صحية
                                              
                        </div>
                        <div class="col-md-6">
                            الخدمة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            دنانير7
                        </div>
                        <div class="col-md-6">
                            متوسط سعر الساعة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            9-9
                        </div>
                        <div class="col-md-6">
                            ساعات العمل
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            <p>تركيب أو إصلاح أنظمة الأنابيب وتركيبات تركيب أو إصلاح أنظمة الأنابيب وتركيبات</p>

                        </div>
                        <div class="col-md-6">
                            وصف الخدمة
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            2
                                              
                        </div>
                        <div class="col-md-6">
                            عدد العملاء
                        </div>
                    </div>
                    <div class="mt-5 text-right">
                    </div>
                </div>
            </div>


        </div>

        <div class="col-md-6 border-right">
            <div class="d-flex flex-column align-items-center text-center p-3 py-5">


                <img id="img" class="rounded-circle mt-5" src="pic/man1.png" width="300" height="300"><span class="font-weight-bold">محمد سعيد</span><span class="text-black-50">mohammad147@gmail.com</span>
                <div style="text-align: right;">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <select style="width: 20%;" class="form-select">
                    <option>متاح</option>
                    <option>غير متاح</option>
                </select>
            </div>
        </div>
        <br />
        <br />
        <br />
    </div>
    <br />
    <br />
    <br />--%>
</asp:Content>
