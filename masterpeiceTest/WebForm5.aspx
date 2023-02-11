<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="masterpeiceTest.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
        }

        #con {
            height: 100vh;
            justify-content: center;
            align-items: center;
            display: flex;
            background-color: #eee
        }

        .launch {
            height: 50px
        }

        .close {
            font-size: 21px;
            cursor: pointer
        }

        .modal-body {
            height: 450px
        }

        .nav-tabs {
            border: none !important
        }

            .nav-tabs .nav-link.active {
                color: #495057;
                background-color: #fff;
                border-color: #ffffff #ffffff #fff;
                border-top: 3px solid blue !important
            }

            .nav-tabs .nav-link {
                margin-bottom: -1px;
                border: 1px solid transparent;
                border-top-left-radius: 0rem;
                border-top-right-radius: 0rem;
                border-top: 3px solid #eee;
                font-size: 20px
            }

                .nav-tabs .nav-link:hover {
                    border-color: #e9ecef #ffffff #ffffff
                }

        .nav-tabs {
            display: table !important;
            width: 100%
        }

        .nav-item {
            display: table-cell
        }

        .form-control {
            border-bottom: 1px solid #eee !important;
            border: none;
            font-weight: 600
        }

            .form-control:focus {
                color: #495057;
                background-color: #fff;
                border-color: #8bbafe;
                outline: 0;
                box-shadow: none
            }

        .inputbox {
            position: relative;
            margin-bottom: 20px;
            width: 100%
        }

            .inputbox span {
                position: absolute;
                top: 7px;
                left: 11px;
                transition: 0.5s
            }

            .inputbox i {
                position: absolute;
                top: 13px;
                right: 8px;
                transition: 0.5s;
                color: #3F51B5
            }

        input::-webkit-outer-spin-button, input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0
        }

        .inputbox input:focus ~ span {
            transform: translateX(-0px) translateY(-15px);
            font-size: 12px
        }

        .inputbox input:valid ~ span {
            transform: translateX(-0px) translateY(-15px);
            font-size: 12px
        }

        .pay a {
            height: 47px;
            border-radius: 37px;
            width: 100%;
        }

        #row {
            text-align: right;
            border: solid #a0a0a0 1px;
            border-radius: 10px;
            box-shadow: 10px 10px #E6E6E6;
            width: 40%;
            font-size: 30px;
        }

        #row2 {
            text-align: right;
            border: solid #a0a0a0 1px;
            border-radius: 10px;
            box-shadow: 10px 10px #E6E6E6;
            width: 40%;
            font-size: 30px;
        }

        #boxesCon {
            width: 100%;
            display: flex;
            justify-content: space-evenly;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="con">
        <div id="boxesCon">
            <div id="row" class="row">

                <div class="col-md-12">
                    <div class="p-3 py-5">
                        <div class="row mt-3">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                                اشترك شهر واحد
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-md-4">
                                <button type="button" class="btn btn-success launch" data-toggle="modal" data-target="#staticBackdrop">
                                    اشترك الان
                                </button>
                            </div>
                            <div class="col-md-8">
                                دنانير\شهر
                            </div>
                        </div>




                        <div class="mt-5 text-right">
                        </div>
                    </div>
                </div>


            </div>
            <div id="row2" class="row">

                <div class="col-md-12">
                    <div class="p-3 py-5">
                        <div class="row mt-3">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                                اشترك شهر واحد
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-md-4">
                                <button type="button" class="btn btn-success launch" data-toggle="modal" data-target="#staticBackdrop">
                                    اشترك الان
                                </button>
                            </div>
                            <div class="col-md-8">
                                دنانير\شهر
                            </div>
                        </div>




                        <div class="mt-5 text-right">
                        </div>
                    </div>
                </div>


            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="text-right"><i class="fa fa-close close" data-dismiss="modal"></i></div>
                        <div class="tabs mt-3">
                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item" role="presentation"><a class="nav-link active" id="visa-tab" data-toggle="tab" href="#visa" role="tab" aria-controls="visa" aria-selected="true">
                                    <img src="https://i.imgur.com/sB4jftM.png" width="80">
                                </a></li>
                                <li class="nav-item" role="presentation"><a class="nav-link" id="paypal-tab" data-toggle="tab" href="#paypal" role="tab" aria-controls="paypal" aria-selected="false">
                                    <img src="https://i.imgur.com/yK7EDD1.png" width="80">
                                </a></li>
                            </ul>
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="visa" role="tabpanel" aria-labelledby="visa-tab">
                                    <div class="mt-4 mx-4">
                                        <div class="text-center">
                                            <h5>Credit card</h5>
                                        </div>
                                        <div class="form mt-3">
                                            <div class="inputbox">
                                                <input type="text" name="name" class="form-control" required="required">
                                                <span>Cardholder Name</span>
                                            </div>
                                            <div class="inputbox">
                                                <input type="text" name="name" min="1" max="999" class="form-control" required="required">
                                                <span>Card Number</span> <i class="fa fa-eye"></i>
                                            </div>
                                            <div class="d-flex flex-row">
                                                <div class="inputbox">
                                                    <input type="text" name="name" min="1" max="999" class="form-control" required="required">
                                                    <span>Expiration Date</span>
                                                </div>
                                                <div class="inputbox">
                                                    <input type="text" name="name" min="1" max="999" class="form-control" required="required">
                                                    <span>CVV</span>
                                                </div>
                                            </div>
                                            <div class="px-5 pay">
                                                <a href="WebForm3.aspx" class="btn btn-success btn-block">اشتراك</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="paypal" role="tabpanel" aria-labelledby="paypal-tab">
                                    <div class="px-5 mt-5">
                                        <div class="inputbox">
                                            <input type="text" name="name" class="form-control" required="required">
                                            <span>Paypal Email Address</span>
                                        </div>
                                        <div class="pay px-5">
                                            <a href="WebForm3.aspx" class="btn btn-primary btn-block">اشتراك</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
