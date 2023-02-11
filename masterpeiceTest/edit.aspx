<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="masterpeiceTest.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
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

        option {
            text-align: right;
        }

        .form-control:disabled, .form-control:read-only {
            background-color: #fff;
            opacity: 1
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container rounded bg-white mt-5">
        <div class="row">

            <div class="col-md-8">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <div class="d-flex flex-row align-items-center back">
                            <i class="fa fa-long-arrow-left mr-1 mb-1"></i>
                            <a href="WebForm7.aspx" style="color: black">
                                <h6>رجوع</h6>
                            </a>
                        </div>
                        <h6 class="text-right">تعديل الحساب</h6>
                    </div>
                    <br />
                    <div class="row mt-2">
                        <div class="col-md-6">
                            <input type="text" class="form-control" placeholder="الاسم الاول">
                        </div>
                        <div class="col-md-6">
                            <input type="text" class="form-control" placeholder="الاسم الثاني">
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            <input type="text" class="form-control" placeholder="رقم الهاتف">
                        </div>
                        <div class="col-md-6">
                            <input type="text" class="form-control" placeholder="متوسط سعر الساعة">
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            <select class="form-select form-control">
                                <option>اربد-الحي الجنوبي</option>
                                <option>اربد-الحي الشرقي</option>
                                <option>اربد-الحي الشمالي</option>
                                <option>اربد-الحي الغربي</option>
                            </select>
                        </div>
                        <div class="col-md-6">
                            <select class="form-select form-control">
                                <option>تمديدات كهربائية</option>
                                <option>تمديدات صحية</option>
                                <option>البستنة و العناية بالحدائق</option>
                                <option>خدمات تنظيف</option>
                            </select>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-6">
                            <textarea style="height: 19px;" class="form-control" placeholder="وصف الخدمة"></textarea>

                        </div>
                        <div class="col-md-6">
                            <input type="text" class="form-control" placeholder="ساعات العمل">
                        </div>
                    </div>
                    <div class="mt-5 text-right">
                        <a class="btn btn-primary profile-button" href="WebForm7.aspx">حفظ التعديل</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5">
                    <img class="rounded-circle mt-5" src="pic/man1.png" width="120"><br />
                    <input style="width: 40%;" type="file" class="form-control" id="customFile" /><br />
                    <select style="width: 40%;" class="form-select">
                        <option>متاح</option>
                        <option>غير متاح</option>
                    </select>

                </div>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
