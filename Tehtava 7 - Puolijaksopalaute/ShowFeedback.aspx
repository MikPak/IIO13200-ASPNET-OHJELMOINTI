<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowFeedback.aspx.cs" Inherits="Tehtava_7___Puolijaksopalaute.ShowFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Näytä Puolijaksopalautteet</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 class="w3-container w3-indigo">Palautteet XML:stä</h2>
        <asp:GridView ID="gvPalautteet" runat="server"></asp:GridView>
        <br />

        <h2 class="w3-container w3-indigo">Palautteet MySQL:stä</h2>
        <asp:SqlDataSource ID="Mysql" runat="server" ProviderName="MySql.Data.MySqlClient" ConnectionString="<%$ ConnectionStrings:Mysql %>" SelectCommand="SELECT * FROM palaute"></asp:SqlDataSource>
        <asp:GridView ID="gvMySQLPalautteet" runat="server" DataSourceID="Mysql"></asp:GridView>
        <br />
        <a href="index.aspx"> Takaisin antamaan palautetta </a>
    </div>
    </form>
</body>
</html>
