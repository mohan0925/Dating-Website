<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Dating.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Dating Website </title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>

<body style="height: 658px" style="background-color:wheat">
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
        <div style="height: 615px">
            <br />
      
            <asp:Label ID="lblRegister" runat="server"
                Style="z-index: 1; left: 385px; top: 76px; position: absolute"
                Text="Registration Form" Font-Bold="True" Font-Size="Larger"
                Font-Underline="True"></asp:Label>

            <asp:Label ID="lblUsername" runat="server"
                Style="z-index: 1; left: 353px; top: 126px; position: absolute; height: 19px; bottom: 321px; right: 1064px;"
                Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Style="z-index: 1;position: absolute; top: 129px; left: 492px;" AutoPostBack="True" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
             <asp:Label ID="UserName_exists" runat="server" Style="z-index: 1;  position: absolute; top: 127px; left: 680px; width: 169px;"></asp:Label>

              <asp:Label ID="lblfullname" runat="server"
                Style="z-index: 1; left: 353px; top: 161px; position: absolute; height: 19px; bottom: 286px;"
                Text="Full Name:"></asp:Label>
            <asp:TextBox ID="txtFullname" runat="server" Style="z-index: 1;position: absolute; top: 166px; left: 492px;"></asp:TextBox>

            <asp:Label ID="lblage" runat="server"
                Style="z-index: 1; left: 353px; top: 193px; position: absolute"
                Text="Age:"></asp:Label>
            <asp:TextBox ID="txtage" runat="server" Style="z-index: 1;position: absolute; top: 195px; left: 492px;"></asp:TextBox>


            <asp:Label ID="lblemail" runat="server"
                Style="z-index: 1; left: 350px; top: 224px; position: absolute; right: 1163px;"
                Text="Email:"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server" Style="z-index: 1;position: absolute; top: 224px; left: 491px;" AutoPostBack="True" OnTextChanged="txtemail_TextChanged"></asp:TextBox>
            <asp:Label ID="EmailExist" runat="server" Style="z-index: 1;  position: absolute; top: 226px; left: 676px; width: 170px;"></asp:Label>

            <asp:Label ID="lblPassword" runat="server"
                Style="z-index: 1; left: 353px; top: 263px; position: absolute"
                Text="Password:"></asp:Label>
            <asp:TextBox ID="txtpwd" runat="server" Style="z-index: 1;position: absolute; top: 263px; left: 489px;" TextMode="Password"></asp:TextBox>

             <asp:Label ID="lblcnfmpwd" runat="server"
                Style="z-index: 1; left: 353px; top: 302px; position: absolute"
                Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtcnfmpwd" runat="server" Style="z-index: 1;position: absolute; top: 302px; left: 486px;" TextMode="Password"></asp:TextBox>

            <asp:Label ID="lblLocation" runat="server"
                Style="z-index: 1; left: 353px; top: 342px; position: absolute"
                Text="Location:"></asp:Label>

            <asp:TextBox ID="txtlocation" runat="server" Style="z-index: 1;position: absolute; top: 342px; left: 485px;" ></asp:TextBox>

            <asp:Label ID="lblBio" runat="server"
                Style="z-index: 1; left: 352px; top: 383px; position: absolute; height: 20px; width: 41px;"
                Text="Bio:"></asp:Label>
            <asp:TextBox ID="txtBio" runat="server" Style="z-index: 1;position: absolute; top: 385px; left: 481px;" ></asp:TextBox>

            <asp:Label ID="lblError" runat="server" ForeColor="Red"
                Style="z-index: 1; left: 566px; top: 476px; position: absolute"></asp:Label>
            <asp:Label ID="lblPicture" runat="server" Text="Upload Picture:" Style="z-index: 1; position: absolute; height: 20px; width: 107px; top: 424px; left: 354px;"></asp:Label>

            <asp:FileUpload ID="FileUpload1" runat="server" Text="" Style="z-index: 1; position: absolute; top: 421px; left: 478px; width: 92px; right: 940px;" />

             <asp:Label ID="lblFilename" runat="server" Style="z-index: 1; position: absolute; top: 422px; left: 589px; width: 189px;" ></asp:Label>
        </div>
                        <asp:Button ID="btnRegister" runat="server"
                Style="z-index: 1; left: 436px; top: 470px; position: absolute"
                Text="Register" OnClick="btnRegister_Click" />
    </form>
</body>
</html>
