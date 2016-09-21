<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">Rivien lukumäärä</asp:Label>
        <asp:DropDownList id="rivit" runat="server" />
        <br />
        <asp:Label runat="server">Pelityyppi</asp:Label>
        <asp:DropDownList ID="tyyppi" runat="server">
            <asp:ListItem Text="Lotto" Value="Lotto"></asp:ListItem>
            <asp:ListItem Text="ViikingLotto" Value="ViikingLotto"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" ID="showResults"></asp:Label>
        <br />
        <asp:Button ID="haeRivit" Text="Tee Rivit" runat="server" OnClick="haeRivit_Click" />
    </div>
    </form>
</body>
</html>
