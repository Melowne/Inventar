<%@ Page Title="Über diese Webapp" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sitzplaene.aspx.cs" Inherits="Inventarverwaltung_iad_asp.Sitzplaene" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Sitzpläne IAD Standorte</h2>
    <p>

        <asp:HyperLink ID="Leipzig" runat="server" NavigateUrl="~/Sitzplan/Leipzig/SitzplanLE_Liste.aspx">Leipzig</asp:HyperLink>
        <br />
        <asp:HyperLink ID="Nordhausen" runat="server" NavigateUrl="~/Sitzplan/Sitzplaene.aspx">Nordhausen</asp:HyperLink>
        <br />
        <asp:HyperLink ID="Berlin" runat="server" NavigateUrl="~/Sitzplan/Sitzplaene.aspx">Berlin</asp:HyperLink>
        <br />             
        <asp:HyperLink ID="Marburg" runat="server" NavigateUrl="~/Sitzplan/Sitzplaene.aspx">Marburg</asp:HyperLink>
        <br />             
        <asp:HyperLink ID="Erfurt" runat="server" NavigateUrl="~/Sitzplan/Sitzplaene.aspx">Erfurt</asp:HyperLink>
        <br />             
        </p>
</asp:Content>
