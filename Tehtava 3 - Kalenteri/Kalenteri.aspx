<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kalenteri.aspx.cs" Inherits="Kalenteri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblThisDate" runat="server">Tänään on: </asp:Label>
        <br />
        <asp:Label ID="lblCurrentDate" runat="server">Valitse haluamasi päivä, valittu pvm: </asp:Label>
        <asp:Label ID="lblSelectedDate" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblDifference" runat="server">Valitun päivän ja tämän päivän erotus on: </asp:Label>
        <asp:Label ID="lblShow" runat="server"></asp:Label>
        <br />
        <asp:Button ID="decreaseYear" runat="server" Text="< Vuosi" OnClick="decreaseYear_Click" />
        <asp:Button ID="addYear" runat="server" Text="Vuosi >" OnClick="addYear_Click" />
        <asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server"></asp:Calendar>
    </div>
    </form>
</body>
</html>
