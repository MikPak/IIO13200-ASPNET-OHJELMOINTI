<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tehtava1.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tehtava1</title>
    <link href="CSS/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="mainContent">
           <asp:Label CssClass="textlabel" ID="Label1" runat="server" Text="Ikkunan Leveys(L):"></asp:Label>
           <asp:TextBox ID="txtLeveys" runat="server" Text="1200"></asp:TextBox>
           <asp:Label ID="Label10" runat="server" Text=" mm"></asp:Label>
           <br />
           <asp:Label CssClass="textlabel" ID="Label2" runat="server" Text="Ikkunan Korkeus(H):"></asp:Label>
           <asp:TextBox ID="txtKorkeus" runat="server" Text="900"></asp:TextBox>
           <asp:Label ID="Label11" runat="server" Text=" mm"></asp:Label>
           <br />
           <asp:Label CssClass="textlabel" ID="Label3" runat="server" Text="Karmipuun Leveys(W):"></asp:Label>
           <asp:TextBox ID="txtKarminLeveys" runat="server" Text="45"></asp:TextBox>
           <asp:Label ID="Label12" runat="server" Text=" mm"></asp:Label>
           <br />
           <asp:Button ID="btnLaske" runat="server" Text="Laske tarjoushinta" OnClick="btnLaske_Click" />
           <!-- Under button -->
           <br />
           <asp:Label CssClass="textlabel" ID="Label4" runat="server" Text="Ikkunan Pinta-ala:"></asp:Label>
           <asp:Label CssClass="resultlabel" ID="lblNaytaPintaAla" runat="server" Text="---"></asp:Label>
           <asp:Label ID="Label7" runat="server" Text=" m2"></asp:Label>
           <br />
           <asp:Label CssClass="textlabel" ID="Label5" runat="server" Text="Karmin Piiri:"></asp:Label>
           <asp:Label CssClass="resultlabel" ID="lblNaytaKarminPiiri" runat="server" Text="---"></asp:Label>
           <asp:Label ID="Label8" runat="server" Text=" m"></asp:Label>
           <br />
           <asp:Label CssClass="textlabel" ID="Label6" runat="server" Text="Tarjoushinta(Ilman ALV):"></asp:Label>
          <asp:Label CssClass="resultlabel" ID="lblNaytaTarjousHinta" runat="server" Text="---"></asp:Label>
           <asp:Label ID="Label9" runat="server" Text=" €"></asp:Label>
           <br />
           <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
       </div>
    </form>
</body>
</html>
