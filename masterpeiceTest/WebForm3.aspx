<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="masterpeiceTest.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        body {
            background-color: #F4F4F4;
        }

        ::placeholder {
            text-align: right;
        }

        input {
        }

        .form-control {
            width: 85% !important;
            margin-left: 8%;
        }

        .card-body {
            background-color: white !important;
            border-radius: 7rem;
        }

        #Button1 {
            width: 85%;
        }

        .fw-bold {
            text-decoration: none;
        }

        option {
            text-align: right;
        }

        .card {
            width: 100%;
            box-shadow: 15px 15px #E6E6E6;
        }

        .col-md-8 {
            width: 70%;
        }

        .btn-file {
            position: relative;
            overflow: hidden;
            background-color: #45962C;
            width: 20%;
            height: 45px
        }

            .btn-file input[type=file] {
                position: absolute;
                top: 0;
                right: 0;
                min-width: 100%;
                min-height: 100%;
                font-size: 100px;
                text-align: right;
                filter: alpha(opacity=0);
                opacity: 0;
                outline: none;
                background: white;
                cursor: inherit;
                display: block;
            }

        @media only screen and (min-device-width: 0px) and (max-device-width: 480px) {
            .col-md-8 {
                width: 100%;
            }
        }

        @media only screen and (min-device-width: 481px) and (max-device-width: 768px) {

            .col-md-8 {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />


    <section class="vh-200 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-light text-black" style="border-radius: 7rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2 text-uppercase">مقدم خدمات جديد</h2>
                                <p class="text-black-50 mb-5"></p>

                                <div style="display: inline-block; width: 46%" class="form-outline form-white mb-4">
                                    <input runat="server" type="text" id="name1" placeholder="الاسم الثاني" class="form-control form-control-lg" required />
                                </div>
                                <div style="display: inline-block; width: 46%" class="form-outline form-white mb-4">
                                    <input runat="server" type="text" id="name2" placeholder="الاسم الاول" class="form-control form-control-lg" required />
                                </div>
                                <div class="form-outline form-white mb-4">
                                    <input runat="server" type="email" id="typeEmailX" placeholder="البريد الالكتروني" class="form-control form-control-lg" required />
                                </div>
                                <div class="form-outline form-white mb-4">
                                    <input runat="server" type="tel" id="typeTelX" placeholder="رقم الهاتف" class="form-control form-control-lg" required />
                                </div>


                                <div class="form-outline form-white mb-4">
                                    <select style="height: 45px; font-size: 18px" class="form-select form-control" required>
                                        <option>اربد-الحي الجنوبي</option>
                                        <option>اربد-الحي الشرقي</option>
                                        <option>اربد-الحي الشمالي</option>
                                        <option>اربد-الحي الغربي</option>
                                    </select>
                                </div>
                                <div class="form-outline form-white mb-4">
                                    <select style="height: 45px;" class="form-select form-control" required>
                                        <option>تمديدات كهربائية</option>
                                        <option>تمديدات صحية</option>
                                        <option>البستنة و العناية بالحدائق</option>
                                        <option>خدمات تنظيف</option>
                                    </select>
                                </div>
                                <div class="form-outline form-white mb-4">
                                    <textarea placeholder="وصف الخدمة" class="form-control form-control-lg" required></textarea>
                                </div>

                                <div class="form-outline form-white mb-4">
                                    <input runat="server" type="text" id="Text1" placeholder="اوقات العمل" class="form-control form-control-lg" required />
                                </div>
                                <br />
                                <div class="form-outline form-white mb-6">
                                    <span class="btn btn-success btn-file">تحميل صورة <i class="fa-solid fa-image"></i>
                                        <input type="file" required>
                                    </span>
                                </div>

                            </div>
                            <a href="WebForm7.aspx" class="btn btn-success" style="background-color: #45962C; font-size: 18px; width: 20%;">اشتراك</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <br />

</asp:Content>
