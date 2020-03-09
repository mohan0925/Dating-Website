<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="Dating.UserAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:wheat">
<head runat="server">
    <title>Dating Website </title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body >

    <div >
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
                    <li><a href="/UserAccount.aspx">Profile</a></li>
                    <li><a href="/Home.aspx">Home</a></li>
                    <li><a href="/Likes.aspx">Likes</a></li>
                    <li><a href="/Matches.aspx">Matches</a></li>
                    <li><a href="/Messages.aspx">Messages</a></li>
                    <li><a href="/Logout.aspx">logout</a></li>
                </ul>
            </div>
        </div>
    </div>
    <br />

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblWelcome" runat="server" Text="" Style="z-index: 1; position: absolute; top: 91px; left: 313px;"></asp:Label>

            <asp:Image ID="Image1" runat="server" Style="z-index: 1; position: absolute; top: 133px; left: 326px; height: 130px; width: 147px; right: 1012px;" />

            <asp:Label ID="lblName" runat="server" Text="Name:" Style="z-index: 1; position: absolute; top: 278px; left: 328px;"></asp:Label>
            <asp:Label ID="lblAge" runat="server" Text="Age:" Style="z-index: 1; position: absolute; top: 308px; left: 329px;"></asp:Label>
            <asp:Label ID="lbllocation" runat="server" Text="Location:" Style="z-index: 1; position: absolute; top: 339px; left: 327px; right: 1100px;"></asp:Label>
            <asp:Label ID="lblBio" runat="server" Text="Bio:" Style="z-index: 1; position: absolute; top: 361px; left: 327px; right: 1100px;"></asp:Label>

            <asp:Label ID="lblNamedata" runat="server" Style="z-index: 1; position: absolute; top: 279px; left: 388px;"></asp:Label>
            <asp:Label ID="lblAgedata" runat="server" Style="z-index: 1; position: absolute; top: 309px; left: 385px;"></asp:Label>
            <asp:Label ID="lbllocationdata" runat="server" Style="z-index: 1; position: absolute; top: 339px; left: 391px; right: 1093px;"></asp:Label>
            <asp:Label ID="lblBiodata" runat="server" Style="z-index: 1; position: absolute; top: 362px; left: 389px; right: 1095px;"></asp:Label>
        </div>
    </form>

    </div>


</body>
</html>
