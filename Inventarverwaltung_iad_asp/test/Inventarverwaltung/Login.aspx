<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inventarverwaltung_iad_asp.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
            <br />
            <asp:Label Width="100" runat="server" Text="Administrator:"></asp:Label>
        </div>
        <div class="col-md-4">
            <br />

            <asp:TextBox Width="100" runat="server" ID="admin" />
            <br />
        </div>
        <br />
    </div>
    <div class="row">
        <div class="col-md-2">
            <br />
            <asp:Label Width="100" runat="server" Text="Passwort:"></asp:Label>
        </div>
        <div class="col-md-4">
            <br />

            <asp:TextBox TextMode="Password" Width="100" runat="server" ID="pass" />
            <br />
        </div>
        <br />

    </div>
    <div class="row">
        <div class="col-md-4">
            <br />
            <asp:Button ID="login" Width="100" Text="Login" runat="server" Style="background-color: #fe0000;color: whitesmoke;" />
        </div>
        <br />
    </div>
</asp:Content>
