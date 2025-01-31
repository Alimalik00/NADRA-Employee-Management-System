<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="testweb.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EMS - Login</title>
    <link rel="stylesheet" href="style/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="logo">
                <img src="nadralog.jpg" alt="Logo" />
            </div>
             <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            <br /><br />
            <div class="input-group">
                <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="390px"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="382px"></asp:TextBox>
            </div>
            <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-login" />
            <div class="btn-group">
            </div>
        </div>
    </form>
</body>
</html>
