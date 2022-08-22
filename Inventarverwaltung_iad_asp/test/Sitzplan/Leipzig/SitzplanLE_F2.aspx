<%@ Page Title="Leipzig-Raum F2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SitzplanLE_F2.aspx.cs" Inherits="Inventarverwaltung_iad_asp.SitzplanLE_F2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Sitzplan Raum F2 Leipzig</h2>
    <div class="Bankreihe">
           <div id="Platz09">
               <div class="Benutzername">
                   <asp:Label ID="lbName09" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label id="lbPC09" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz08">
               <div class="Benutzername">
                   <asp:Label ID="lbName08" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label id="lbPC08" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz07">
               <div class="Benutzername">
                   <asp:Label ID="lbName07" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC07" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div class="Gang">&nbsp;</div>
        </div>
    <div class="Bankreihe">
           <div id="Platz06">
               <div class="Benutzername">
                   <asp:Label ID="lbName06" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC06" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz05">
               <div class="Benutzername">
                   <asp:Label ID="lbName05" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC05" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz04">
               <div class="Benutzername">
                   <asp:Label ID="lbName04" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC04" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>

       <div class="Gang">&nbsp;</div>
     </div>
    <div class="Bankreihe">
           <div id="Platz03">
               <div class="Benutzername">
                   <asp:Label ID="lbName03" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC03" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz02">
               <div class="Benutzername">
                   <asp:Label ID="lbName02" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC02" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz01" runat="server">
               <div class="Benutzername">
                   <asp:Label ID="lbName01" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC01" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div class="Gang">&nbsp;</div>
    </div>
    <div id="Platz00" style="width:100px;margin-left:0px;">
        <div class="Benutzername">
            <asp:Label ID="lbName00" runat="server" Text="&nbsp;"></asp:Label>
        </div>
        <div class="Computername">
            <asp:Label ID="lbPC00" runat="server" Text="&nbsp;"></asp:Label>
        </div>
    </div>
    <div id="Fehler" class="Fehlermeldung">
        <asp:Label ID="lbFehler" runat="server" Text="&nbsp;"></asp:Label>
    </div>
    <div id="TeilnehmerdatenUpdate">
        <br />
        <asp:TextBox ID="TbDatePicker" runat="server" TextMode="Date"></asp:TextBox>
    <%--    <asp:Button ID="BtnUpdate" runat="server" Text="Teilnehmerdaten aktualisieren" OnClick="BtnUpdate_Click" />
    --%>
    </div>
</asp:Content>
