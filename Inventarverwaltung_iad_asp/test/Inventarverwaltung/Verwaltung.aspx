<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Verwaltung.aspx.cs" Inherits="Inventarverwaltung_iad_asp.WebForm1"    %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server">
        <div class="jumbotron" style="background-color: #fe0000; color: whitesmoke;">
            <h3>Inventardaten anzeigen oder ändern</h3>
        </div>
        <br />
        <div id="verwaltung" runat="server" class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="LbComputerSelect" runat="server" Text="Kategorie auswählen:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList Style="background-color: white;" ID="objekt" Width="150" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="LbNewIADLocation" runat="server" Text="IAD Standort wählen:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList Style="background-color: white" ID="orte" Width="150" runat="server"></asp:DropDownList>
                    <br />
                </div>
                <br />
            </div>
            <div class="row">
                <div class="col-md-2">
                    <br />
                    <asp:Button Style="background-color: #fe0000; color: whitesmoke;" Width="150" ID="auswahl" OnClick="auswahl_Click" runat="server" Text="Auswahl" />
                </div>
            </div>
           
            <%--Suchfilter--%>
            <div class="row">
                <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="raumtxt" runat="server" Text="Raum:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlraum" runat="server"></asp:DropDownList>
                    <br />
                </div>

                    <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="cputxt" runat="server" Text="CPU:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList  Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlcpu" runat="server"></asp:DropDownList>
                    <br />
                </div>

                    <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="hddtxt" runat="server" Text="HDD:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlhdd" runat="server"></asp:DropDownList>
                    <br />
                </div>

                    <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="ssdtxt" runat="server" Text="SSD:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlssd" runat="server"></asp:DropDownList>
                    <br />
                </div>



                     <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="ramtxt" runat="server" Text="RAM:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlram" runat="server"></asp:DropDownList>
                    <br />
                </div>


                      <div class="col-md-2">
                    <br />
                    <asp:Label Visible="false" ID="grafiktxt" runat="server" Text="Grafik:"></asp:Label>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:DropDownList Style="background-color: white" Visible="false" Width="150" class="col-md-4" ID="auswahlgrafik" runat="server"></asp:DropDownList>
                    <br />
                </div>




                <br />
            </div>

            <div class="row">
                <div class="col-md-2">
                    <br />
                    <asp:Button Style="background-color: #fe0000; color: whitesmoke;" Width="150" Visible="false" ID="erfassen" OnClick="erfassen_Click" runat="server" Text="Erfassen" />
                </div>
            </div>
            <br />

            <div class="row">
                <asp:Table Visible="false" runat="server" ID="grid" />
                <asp:Panel runat="server" ID="obj" Visible="false" />
            </div>
            <asp:Panel runat="server" ID="controls" Visible="false">
                <div class="row">
                    <div class="col-lg-2">
                        <br />
                        <asp:TextBox ID="poschtxt" Width="150" runat="server"></asp:TextBox>
                        <asp:Button Style="background-color: #fe0000; color: whitesmoke;" OnClick="poschange_Click" Width="150" ID="poschange" runat="server" Text="Position ändern" />
                        <br />
                    </div>
                    <div class="col-lg-2">
                        <br />
                        <asp:TextBox ID="raumchtxt" Width="150" runat="server"></asp:TextBox>
                        <asp:Button Style="background-color: #fe0000; color: whitesmoke;" OnClick="raumchange_Click" Width="150" ID="raumchange" runat="server" Text="Raum ändern" />
                        <br />
                    </div>
                    <div class="col-lg-2">
                        <br />
                        <asp:TextBox BorderStyle="None" ReadOnly="true" Width="150" runat="server"></asp:TextBox>
                        <asp:Button Style="background-color: #fe0000; color: whitesmoke;" Width="150" OnClick="delete_Click" ID="delete" runat="server" Text="Löschen" />
                        <br />
                    </div>

                    <br />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="QR" Visible="true">
          <br /><br />
             <asp:Button Visible="false" Style="background-color: #fe0000; color: whitesmoke;" Width="150"   runat="server" Text="Generiere QR" ID="qrbut" OnClick="qrbut_Click" OnClientClick="target ='_blank';" />
            </asp:Panel>
           

        </div>
    </div>



</asp:Content>
