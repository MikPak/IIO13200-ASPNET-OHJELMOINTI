<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tehtava_7___Puolijaksopalaute.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Anna palaute</h1>
        <asp:Label ID="Label2" runat="server" Text="Pvm: "></asp:Label>
        <asp:TextBox ID="Pvm" runat="server"></asp:TextBox>

        <asp:CompareValidator ID="cv" runat="server" ControlToValidate="Pvm" Type="Date"
        Operator="DataTypeCheck" ErrorMessage="Päivämäärä ei ole oikeassa muodossa!" />
         <asp:RequiredFieldValidator runat="server" ControlToValidate="Pvm" ErrorMessage="Täytä kenttä." />
        <br />

        <asp:Label ID="Label3" runat="server" Text="Nimi: "></asp:Label>
        <asp:TextBox ID="Nimi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Nimi" ErrorMessage="Syötä nimi!" />
        <br />

        <asp:Label ID="Label4" runat="server" Text="Olen oppinut:"></asp:Label>
        <asp:TextBox ID="Opittu" Height="40" Width="300" TextMode="MultiLine" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ControlToValidate="Opittu" ErrorMessage="Täytä kenttä." />
        <br />

        <asp:Label ID="Label5" runat="server" Text="Haluan oppia:"></asp:Label>
        <asp:TextBox ID="HaluanOppia" Height="40" Width="300" TextMode="MultiLine" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ControlToValidate="HaluanOppia" ErrorMessage="Täytä kenttä." />
        <br />

        <asp:Label ID="Label6" runat="server" Text="Hyvää:"></asp:Label>
        <asp:TextBox ID="Hyvaa" Height="40" Width="300" TextMode="MultiLine" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ControlToValidate="Hyvaa" ErrorMessage="Täytä kenttä." />
        <br />

        <asp:Label ID="Label7" runat="server" Text="Parannettavaa:"></asp:Label>
        <asp:TextBox ID="Parannettavaa" Height="40" Width="300" TextMode="MultiLine" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator runat="server" ControlToValidate="Parannettavaa" ErrorMessage="Täytä kenttä." />
        <br />

        <asp:Label ID="Label8" runat="server" Text="Muuta:"></asp:Label>
        <asp:TextBox ID="Muuta" Height="40" Width="300" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="SendFeedback" runat="server" Text="Lähetä palaute XML" OnClick="SendFeedback_Click" />
        <asp:Button ID="SendFeedBackMySQL" runat="server" Text="Lähetä palaute MySQL" OnClick="SendFeedBackMySQL_Click" />
         <asp:Label ID="userMessage" runat="server" Text=""></asp:Label>
        <br />
        <a href="ShowFeedback.aspx"> Katso palautteita </a>
    
    </div>
    </form>
</body>
</html>
