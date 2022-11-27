<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="view.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="StyleSheet1.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="center-y">
        <div class="center-x">
            <form id="form1" runat="server">
                <div class="form-controls">
                <asp:Label ID="Label" runat="server" Text="CategoryName: "></asp:Label>
                <asp:TextBox ID="TxtInput" runat="server"></asp:TextBox>
                <asp:Button CssClass="button" AutoPostBack="true" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </div>
                <asp:GridView  ID="GridView1" runat="server" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
                </asp:GridView>
                <asp:Label ID="LblNotFound" runat="server" Text=""></asp:Label>
            </form>
        </div>
    </div>
</body>
</html>
