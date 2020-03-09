<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Likes.aspx.cs" Inherits="Dating.Likes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dating Website </title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <style>
        #myDIV {
            width: 100%;
            padding: 50px 0;
            text-align: center;
            background-color: lightblue;
            margin-top: 20px;
        }
    </style>

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
        <div style="margin-left:auto;margin-right:auto;">
            <asp:DataList ID="dtlist" runat="server" style="margin-left:auto;margin-right:auto;">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte [])Eval("image")) %>' Height="200" Width="200" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%#Eval("FullName") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%#Eval("Age") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%#Eval("location") %><br />
                            </td>
                        </tr>
                    </table>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div id="myDIV" runat="server">
            There are no liked Users
        </div>
    </form>
</body>
</html>
