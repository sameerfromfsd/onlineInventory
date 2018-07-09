<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HafizG.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>Hafiz Jee Food Concern</title>
    <meta name="description" content="Hafiz jee food Product ready to eat and meat"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="apple-touch-icon" href="apple-icon.png"/>
    <link rel="shortcut icon" href="favicon.ico"/>

    <link rel="stylesheet" href="assets/css/normalize.css"/>
    <link rel="stylesheet" href="assets/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="assets/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="assets/css/themify-icons.css"/>
    <link rel="stylesheet" href="assets/css/flag-icon.min.css"/>
    <link rel="stylesheet" href="assets/css/cs-skin-elastic.css"/>
    <!-- <link rel="stylesheet" href="assets/css/bootstrap-select.less"> -->
    <link rel="stylesheet" href="assets/scss/style.css"/>

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css' />
    
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
          <div>
          <div class="sufee-login d-flex align-content-center flex-wrap">
          <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <a href="Login.aspx">
                        <h1>Hafiz Jee Food Concern</h1>

                    </a>
                </div>
                <div class="login-form">
                   
                        <div class="form-group">
                            <label>Email address</label>
                            <asp:TextBox ID="emTxt" TextMode="Email" CssClass="form-control" required="true"  runat="server" />
                           
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="pasTxt" TextMode="Password" CssClass="form-control" required="true"  runat="server" />
                           
                        </div>
                         <asp:Button ID="Button1" CssClass="btn btn-success btn-flat m-b-30 m-t-30" runat="server" Text="Sign in" OnClick="Button1_Click" />
                       
                       <br /><br />
                        <div class="alert alert-danger" role="alert" runat="server" id="validDiv">
                         Invalid Email or Password!
                        </div>
                      
                   
                </div>
            </div>
        </div>
    </div>


    <script src="assets/js/vendor/jquery-2.1.4.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/main.js"></script>


    </div>
    </form>
</body>
</html>
