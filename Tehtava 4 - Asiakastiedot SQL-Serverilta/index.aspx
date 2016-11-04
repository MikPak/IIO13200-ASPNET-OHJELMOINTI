<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:sqldatasource ID="srcAsiakkaat" runat="server" ConnectionString="<%$ ConnectionStrings:DemoxOyConnectionString %>"
        SelectCommand="SELECT [astunnus], [asnimi], [yhteyshlo], [postitmp] FROM [asiakas]">
    </asp:sqldatasource>

    <h2>Tapa 1: SQLDataSource</h2>
    <asp:gridview ID="gvMovies" DataSourceID="srcAsiakkaat" runat="server"></asp:gridview>

    <h2>Tapa 2: DBDemoxOy-luokka</h2>
    <asp:gridview ID="gvMovies2" runat="server"></asp:gridview>

</asp:Content>