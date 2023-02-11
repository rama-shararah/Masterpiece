<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="masterpeiceTest.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #parent {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            z-index: 0;
        }

        #child {
            width: 90%;
            height: 70vh;
            border: 1px solid #a9a9a9;
            border-radius: 120px;
            box-shadow: 25px 25px #E6E6E6;
            display: flex;
            flex-direction: column;
            align-items: flex-end;
            justify-content: space-evenly;
            padding: 5%;
            text-align: right;
        }

        #img {
            width: 30%;
            z-index: 3;
            position: absolute;
            left: 10%;
            top: 11.1rem;
        }

        #title {
            font-size: 40px;
            float: right;
        }

        #text {
            font-size: 20px;
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container" id="parent">
        <div id="child">
            <div id="title">حول موقع مصلحكُم</div>
            <div id="text">موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة موقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودةموقع خدمات يساعدك في ايجاد الخدمة التي تريدها باسرع وقت و افضل جودة </div>
        </div>
    </div>

    <img id="img" src="pic/about.png" />

</asp:Content>
