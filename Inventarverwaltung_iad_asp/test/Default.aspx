<%@ Page Title="Inventarverwaltung" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Inventarverwaltung_iad_asp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="background-color: #fe0000; color: whitesmoke;">
        <h1>Inventarverwaltung IAD</h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Inventardaten ändern</h2>
            <p>
                Inventardaten erfassen oder ändern 
            </p><br>
            <p>
                <a class="btn btn-default" href="Inventarverwaltung/Login.aspx">BackEnd starten... &raquo;</a>
            </p>
        </div>
          <div class="col-md-4">
            <h2>Sitzplan auswählen</h2>
            <p>Für jeden Raum wird dynamisch ein Sitzplan aus den Inventur und Anmeldedaten erzeugt.            </p>
            <p>
                <a class="btn btn-default" href="Sitzplan/Sitzplaene.aspx">Liste der Sitzpläne anzeigen &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
