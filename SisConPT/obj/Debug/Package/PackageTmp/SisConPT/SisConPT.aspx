﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SisConPT.aspx.cs" Inherits="SisConPT.SisConPT.SysConPT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
                    <legend>Seleccione planta</legend>
   <ol>
        <li>
        <asp:Label runat="server" AssociatedControlID="Plantas">Planta</asp:Label>
        <asp:DropDownList ID="DropDownList1"  runat="server" DataSourceID="Plantas" DataTextField="pladescri" DataValueField="pladescri" Height="30px" Width="310px" Font-Names="Century Gothic">
        </asp:DropDownList>
            <asp:SqlDataSource ID="Plantas" runat="server" ConnectionString="<%$ ConnectionStrings:CONTROLPTConnectionString %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [pladescri] FROM [planta]"></asp:SqlDataSource>
        </li>
    </ol>
        </fieldset>
    <fieldset>
        <legend>Menu aplicaciones</legend>
        <asp:Table ID="Aplicaciones" runat="server" BorderColor="Black" 
            BorderStyle="Solid" Font-Names="Century Gothic" Font-Size="Small" Height="74px" 
            Width="650px" HorizontalAlign="Center">
            <asp:TableRow runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">Carga de Planillas Por proceso</asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">Carga de Planillas por Código de caja</asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">Carga Descarte Manual 003</asp:TableCell>
<%--                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">Consulta de planillas por proceso</asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">Consulta de planillas por Códgo de caja</asp:TableCell>--%>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC075PP" runat="server" onclick="Btn_proc_Click" Text="CC-PAC-075 DESCARTE" Font-Size="X-Small" Font-Names="Century Gothic" />
                </asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC05PCC" runat="server" onclick="Button2_Click" Text="CC-PAC-005 Producto terminado"  Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC003PP" runat="server" onclick="Btn_003" Text="CC-PAC-003"  Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>
              <%--  <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="Consporproceso" runat="server" onclick="Btn_cons_proc" Text="CC-PAC-075 por Proceso" Enabled="True" Font-Names="Century Gothic" Font-Size="X-Small" /></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="Consporcodcaja" runat="server" Text="CC-PAC-05 por Código de caja" Enabled="False" Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>--%>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell ID="TableCell1" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_075_resumen" runat="server" onclick="Btn_resumen_075" Text="Exportar xls CC-PAC-075 DESCARTE" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic" />
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_005_resumen" runat="server" onclick="Btn_resumen_005" Text="Resumen CC-PAC-005 Producto terminado"  Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>
                     <asp:TableCell ID="TableCell4" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_003_resumen" runat="server" onclick="Btn_resumen_003" Text="Resumen CC-PAC-003"  Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>
               <%-- <asp:TableCell ID="TableCell3" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="Button3" runat="server" onclick="Btn_cons_proc" Text="CC-PAC-075 por Proceso" Enabled="False" Visible="false" Font-Names="Century Gothic" Font-Size="X-Small" /></asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="Button4" runat="server" Text="CC-PAC-05 por Código de caja" Enabled="False" Visible="false" Font-Names="Century Gothic" Font-Size="X-Small" />
                </asp:TableCell>--%>
            </asp:TableRow>
        </asp:Table>

    </fieldset>
</asp:Content>
