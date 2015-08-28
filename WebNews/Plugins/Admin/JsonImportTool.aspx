<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JsonImportTool.aspx.cs" Inherits="WebNews.Plugins.Admin.JsonImportTool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Json Import Tool</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Json Import Tool</p>
        Enter Root Page ID <asp:TextBox ID="IdBox" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Invoke Import" OnClick="ImportJsonObjects"></asp:Button>
    </div>
    </form>
</body>
</html>
