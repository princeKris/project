<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manga.aspx.cs" Inherits="Novelscrap.manga" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manga Scraper</title>
    <link href="css/novelStyle.css" rel="stylesheet" />
</head>
<body>
    <h1 style="text-align:center; height: 49px;">Manga Scraper</h1>
    <form id="form1" runat="server">
        <div class="Center_Content" runat="server">
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="20pt" CssClass="dropcs">
                <asp:ListItem Value="Novela">Novel1</asp:ListItem>
                <asp:ListItem Value="novelb">novel2</asp:ListItem>
                <asp:ListItem Value="novelc">novel3</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="20pt" Width="578px" CssClass="tex"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="SinglePage" CssClass="butt"/>
            <asp:Button ID="Button2" runat="server" Text="FullNovel" CssClass="butt"/>
        </div>
    </form>
</body>
</html>
