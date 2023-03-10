<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="masterpeiceTest.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h2 {
            text-align: right;
        }

        #con {
            display: flex;
            gap: 50px;
            height: 60vh;
        }

        .child {
            text-align: right;
            width: 48%;
            font-size: 20px;
        }

        #form {
            border: solid 1px #cdcdcd;
            padding: 5%;
            box-shadow: 15px 15px #E6E6E6;
        }

            #form input {
                width: 100%;
            }

        ::placeholder {
            text-align: right;
        }

        .child a {
            font-size: 50px;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h2 class="container">مركز المساعدة</h2>
    <br />
    <br />
    <br />

    <div id="con" class="container">
        <div class="child">
            <div id="form">

                <div id="contactForm" data-sb-form-api-token="API_TOKEN">

                    <!-- Name input -->
                    <div class="mb-3">

                        <input class="form-control" id="name" type="text" placeholder="الاسم" data-sb-validations="required" required />
                        <div class="invalid-feedback" data-sb-feedback="name:required">Name is required.</div>
                    </div>

                    <!-- Email address input -->
                    <div class="mb-3">

                        <input class="form-control" id="emailAddress" type="email" placeholder="البريد الالكتروني" data-sb-validations="required, email" required />
                        <div class="invalid-feedback" data-sb-feedback="emailAddress:required">Email Address is required.</div>
                        <div class="invalid-feedback" data-sb-feedback="emailAddress:email">Email Address Email is not valid.</div>
                    </div>

                    <!-- Message input -->
                    <div class="mb-3">

                        <textarea class="form-control" id="message" type="text" placeholder="اكتب رسالتك هنا" style="height: 10rem;" data-sb-validations="required" required></textarea>
                        <div class="invalid-feedback" data-sb-feedback="message:required">Message is required.</div>
                    </div>

                    <!-- Form submissions success message -->
                    <div class="d-none" id="submitSuccessMessage">
                        <div class="text-center mb-3">Form submission successful!</div>
                    </div>

                    <!-- Form submissions error message -->
                    <div class="d-none" id="submitErrorMessage">
                        <div class="text-center text-danger mb-3">Error sending message!</div>
                    </div>

                    <!-- Form submit button -->
                    <div class="d-grid">
                        <button class="btn btn-success btn-lg" id="submitButton" type="submit">ارسال</button>
                    </div>

                </div>
            </div>
        </div>
        <div class="child">
            لديك اي استفسار او سؤال ، او واجهتك مشكلة ، تواصل معنا على مواقع التواصل الاجتماعي او من خلال الرسائل هنا
            <div style="margin-right: 25%; margin-top: 5%;">
                <a href="https://www.facebook.com/"><i class="fa-brands fa-facebook"></i></a>&nbsp;&nbsp;
                <a href="https://www.facebook.com/"><i class="fa-brands fa-telegram"></i></a>&nbsp;&nbsp;
                <a href="https://www.facebook.com/"><i class="fa-brands fa-whatsapp"></i></a>

            </div>
        </div>
    </div>
</asp:Content>
