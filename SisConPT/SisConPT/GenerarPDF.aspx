<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarPDF.aspx.cs" Inherits="SisConPT.SisConPT.GenerarPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:TextBox ID="txt" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Width="27px"></asp:TextBox>
<asp:Button ID="boton" runat="server" Text="pdf" Enabled="true" OnClick="boton_Click" />
</asp:Content>
