<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="masterpeiceTest.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/a8b56cb52b.js" crossorigin="anonymous"></script>
    <style>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="vh-100 gradient-custom">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card bg-light text-black" style="border-radius: 7rem;">
                            <div class="card-body p-5 text-center">

                                <div class="mb-md-5 mt-md-4 pb-5">

                                    <h2 class="fw-bold mb-2 text-uppercase">مستخدم جديد</h2>
                                    <p class="text-black-50 mb-5"></p>

                                    <div class="form-outline form-white mb-4">
                                        <input runat="server" type="email" id="typeEmailX" placeholder="البريد الالكتروني" class="form-control form-control-lg" />
                                    </div>
                                    <div class="form-outline form-white mb-4">
                                        <input runat="server" type="tel" id="typeTelX" placeholder="رقم الهاتف" class="form-control form-control-lg" />
                                    </div>
                                    <div class="form-outline form-white mb-4">
                                        <select class="form-select form-control">
                                            <option>اربد-الحي الجنوبي</option>
                                            <option>اربد-الحي الشرقي</option>
                                            <option>اربد-الحي الشمالي</option>
                                            <option>اربد-الحي الغربي</option>
                                        </select>
                                    </div>
                                    <div class="form-outline form-white mb-4">
                                        <input runat="server" type="password" id="typePasswordX" placeholder="كلمة السر" class="form-control form-control-lg" />
                                    </div>
                                    <div class="form-outline form-white mb-4">
                                        <input runat="server" type="password" id="Password1" placeholder="تأكيد كلمة السر" class="form-control form-control-lg" />
                                    </div>
                                    <br />


                                    <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary btn-lg px-5" Text="تسجيل" ValidationGroup="G1" />

                                    <div class="d-flex justify-content-center text-center mt-4 pt-1">
                                        <a href="#!" class="text-primary"><i class="fab fa-facebook-f fa-lg"></i></a>
                                        <a href="#!" class="text-primary"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a>
                                        <a href="#!" class="text-primary"><i class="fab fa-google fa-lg"></i></a>
                                    </div>

                                </div>

                                <div>
                                    <p class="mb-0">
                                        لديك حساب؟<br />
                                        <a href="#!" class="text-dark-50 fw-bold">دخول</a>

                                    </p>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <br />

    </form>
</body>
</html>
