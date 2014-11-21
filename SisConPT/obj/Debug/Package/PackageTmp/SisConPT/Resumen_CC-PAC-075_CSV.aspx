<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen_CC-PAC-075_CSV.aspx.cs" Inherits="SisConPT.SisConPT.Resumen_CC_PAC_075_CSV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
<fieldset>
        <legend>DECARGA ARCHIVO EXCEL<asp:Label ID="lbl_planta" runat="server" Width="150" Height="30"></asp:Label><asp:Label ID="lbl_codpla" runat="server" Width="150" Height="30"></asp:Label></legend>
         <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
             <asp:TableCell Width="150">
              <asp:Label ID="DESCARGAR" runat="server" Text="DESCARGAR ARCHIVO .xls" Width="150" Height="30"></asp:Label>
        
               </asp:TableCell>
           
        
              <asp:TableCell Width="20">
               <asp:Button ID="Exportar_075" runat="server" Text="DESCARGAR" Enabled="true" OnClick="Exportar_click" />
              </asp:TableCell>
              </asp:TableRow>
              </asp:Table>
        </fieldset>
</asp:Content>