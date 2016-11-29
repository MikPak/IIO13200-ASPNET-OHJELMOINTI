<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tehtava_5___Asiakastiedot_EntityFrameworkilla.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="srcAsiakas" runat="server" ConnectionString="<%$ ConnectionStrings:DemoxOyConnectionString %>" SelectCommand="SELECT * FROM [asiakas]"></asp:SqlDataSource>
        <asp:Button ID="btnHaeKaikki" runat="server" Text="HaeKaikkiAsiakkaat" OnClick="btnHaeKaikki_Click" />
        <asp:DropDownList ID="ddlCountries" runat="server"></asp:DropDownList>
        <asp:Button ID="btnHaeMaasta" runat="server" Text="Hae asiakkaat valitusta maasta" OnClick="btnHaeMaasta_Click" />
        <asp:Button ID="btnHaeMaittain" runat="server" Text="Hae asiakkaat maittain" OnClick="btnHaeMaittain_Click" />
        <asp:Button ID="btnLuo" runat="server" Text="Luo uusi asiakas" OnClick="btnLuo_Click" />
        <br />
        <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Asiakastunnus: "></asp:Label>
        <asp:TextBox ID="txtAsTunnus" Text="TEST69" runat="server"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Nimi: "></asp:Label>
        <asp:TextBox ID="txtAsNimi" Text="Jeesbox Oy" runat="server"></asp:TextBox>
             
        <asp:Label ID="Label3" runat="server" Text="Yhteyshenkilö: "></asp:Label>
        <asp:TextBox ID="txtAsYhtHlo" Text="Kehveli Koistinen" runat="server"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Maa: "></asp:Label>
        <asp:TextBox ID="txtMaa" Text="FIN" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label5" runat="server" Text="Posti Numero: "></asp:Label>
        <asp:TextBox ID="txtPostiNro" Text="40950" runat="server"></asp:TextBox>

        <asp:Label ID="Label6" runat="server" Text="Posti Toimipaikka: "></asp:Label>
        <asp:TextBox ID="txtPostiTmp" Text="Kuhmo" runat="server"></asp:TextBox>

        <asp:Label ID="Label7" runat="server" Text="Ostot: "></asp:Label>
        <asp:TextBox ID="txtOstot" Text="999" runat="server"></asp:TextBox>

        <asp:Label ID="Label8" runat="server" Text="AsiointiVuosi"></asp:Label>
        <asp:TextBox ID="txtAsVuosi" Text="2012" runat="server"></asp:TextBox>

        <br />

        <asp:Button ID="btnSend" runat="server" Text="Tallenna asiakas" OnClick="btnSend_Click" />
        </asp:Panel>

        <asp:GridView ID="gvAsiakkaat" runat="server"></asp:GridView>
        <asp:Label ID="lblMessages" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
