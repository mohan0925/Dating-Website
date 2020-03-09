

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Dating.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Dating Website </title>
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body style="background-color:wheat">
        <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">                   
                        <li><a href="/UserLogin.aspx">Login</a></li>
                        <li><a href="/Register.aspx">Register</a></li>              
            </ul></div>
        </div>
    </div>
    <br />
    <form id="form1" runat="server">
        <div style="height: 393px">
            <br />

             <asp:Label ID="lblRegister" runat="server"
                Style="z-index: 1; left: 500px; top: 76px; position: absolute"
                Text="Login" Font-Bold="True" Font-Size="Larger"
                Font-Underline="True"></asp:Label>

            <asp:Label ID="lblusername" runat="server"
                Style="z-index: 1; left: 404px; top: 130px; position: absolute; height: 19px; bottom: 206px;"
                Text="UserName:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Style="z-index: 1;position: absolute; top: 129px; left: 492px;"></asp:TextBox>

            <asp:Label ID="lblpwd" runat="server"
                Style="z-index: 1; left: 403px; top: 165px; position: absolute; height: 26px; bottom: 164px; right: 1017px;"
                Text="Password:"></asp:Label>
            <asp:TextBox ID="txtpwd" runat="server" Style="z-index: 1;position: absolute; top: 166px; left: 492px;"></asp:TextBox>

             <asp:Button ID="btnlogin" runat="server"
                Style="z-index: 1; left: 517px; top: 215px; position: absolute"
                Text="login" OnClick="btnlogin_Click"/>

                        <asp:Label ID="lblError" runat="server" ForeColor="Red"
                Style="z-index: 1; left: 606px; top: 219px; position: absolute"></asp:Label>

        </div>
    </form>
    <a href="/Register.aspx"><p Style="z-index: 1;position: absolute; top: 216px; left: 156px;">Not a member? Create an account free.</p></a>
        <br>
    <script src="/Script/jquery-1.10.2.js"></script>
    <script src="/Script/bootstrap.js"></script>
    <script src="/Script/respond.js"></script>
</body>
</html>

