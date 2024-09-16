<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novelsc.aspx.cs" Inherits="Novelscrap.novelsc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Novel Scraper</title>
    <link href="css/novelStyle.css" rel="stylesheet" />
</head>
<body>
    <h1 style="text-align:center; height: 49px;">Novel Scraper</h1>
    <form id="form1" runat="server">
        <div class="Center_Content" runat="server">
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="20pt" CssClass="dropcs">
                <asp:ListItem Value="fanmtl.com">www.fanmtl.com</asp:ListItem>
                <asp:ListItem Value="scribblehub.com">www.scribblehub.com</asp:ListItem>
                <asp:ListItem Value="readfree.com">www.readfree.com</asp:ListItem>
                <asp:ListItem Value="novelbin.com">www.novelbin.com</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="20pt" Width="578px" CssClass="tex"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="SinglePage" CssClass="butt" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Home" CssClass="butt" OnClick="Button2_Click" />
        </div>
    </form>
    <h1 id="tro"> <%=opt %></h1>
</body>
</html>
