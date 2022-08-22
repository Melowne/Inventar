<%@ Page Title="Leipzig-Raum R2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SitzplanLE_R2.aspx.cs" Inherits="Inventarverwaltung_iad_asp.SitzplanLE_R2" %>
<asp:Content ID="LE_R2" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2> Sitzplan Raum R2 Leipzig</h2>
    <div class="Bankreihe">
       <div class="Gang">&nbsp;</div>
           <div id="Platz12">
               <div class="Benutzername">
                   <asp:Label ID="lbName12" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC12" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz11">
               <div class="Benutzername">
                   <asp:Label ID="lbName11" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC11" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
           <div id="Platz10">
               <div class="Benutzername">
                   <asp:Label ID="lbName10" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC10" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
             <div id="Platz09">
               <div class="Benutzername">
                   <asp:Label ID="lbName09" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC09" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
     </div>
 
    <div class="Bankreihe">
           <div class="Gang">&nbsp;</div>
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
        </div>
       <div class="Bankreihe">
           <div class="Gang">&nbsp;</div>
           <div id="Platz04">
               <div class="Benutzername">
                   <asp:Label ID="lbName04" runat="server" Text="&nbsp;"></asp:Label>
               </div>
               <div class="Computername">
                   <asp:Label ID="lbPC04" runat="server" Text="&nbsp;"></asp:Label>
               </div>
           </div>
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
    </div>
    <div id="Platz00" style="width:100px;margin-left:320px;">
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
  <%--      <asp:Button ID="BtnUpdate" runat="server" Text="Teilnehmerdaten aktualisieren" OnClick="BtnUpdate_Click" />
  --%>
        </div>

</asp:Content>
