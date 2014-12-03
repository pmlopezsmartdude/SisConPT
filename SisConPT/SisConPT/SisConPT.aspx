<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SisConPT.aspx.cs" Inherits="SisConPT.SisConPT.SysConPT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
                    <legend>Seleccione planta</legend>
   <ol>
        <li>
        <asp:Label runat="server" >Planta</asp:Label>
        <asp:DropDownList ID="DropPlanta_d"  runat="server" DataSourceID="DropPlanta" DataTextField="pladescri" DataValueField="pladescri" Height="30px" Width="310px" Font-Names="Century Gothic">
        </asp:DropDownList>
            
        </li>
    </ol>
        </fieldset>
    <fieldset>
        <legend>Menu aplicaciones</legend>
        <asp:Table ID="Aplicaciones" runat="server" BorderColor="Black" 
            BorderStyle="Solid" Font-Names="Century Gothic" Font-Size="Small" Height="74px" 
            Width="650px" HorizontalAlign="Center">
            <asp:TableRow runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">DESCARTE COMERCIAL</asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">PRODUCTO TERMINADO</asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">MESA DE SELECCION</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC075PP" runat="server" onclick="Btn_proc_Click" Text=" Ingreso CC-PAC-075" Font-Size="X-Small" Font-Names="Century Gothic" width="200"/>
                </asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC05PCC" runat="server" onclick="Button2_Click" Text="Ingreso CC-PAC-005"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="CCPAC003PP" runat="server" onclick="Btn_003" Text="Ingreso CC-PAC-003"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
                 </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell ID="TableCell1" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_075_resumen" runat="server" onclick="Btn_resumen_075" Text="Detalle CC-PAC-075"  Font-Size="X-Small" Font-Names="Century Gothic" width="200"/>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_005_resumen" runat="server" onclick="Btn_resumen_005" Text="Resumen CC-PAC-005"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
                     <asp:TableCell ID="TableCell4" runat="server" BorderColor="Black" BorderStyle="Solid">
                    <asp:Button ID="btn_003_resumen" runat="server" onclick="Btn_resumen_003" Text="Resumen CC-PAC-003"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
     
        
            </asp:TableRow>
               <asp:TableRow ID="TableRow2" runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell ID="TableCell5" runat="server" BorderColor="Black" BorderStyle="Solid">
               
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server" BorderColor="Black" BorderStyle="Solid">
              <asp:Button ID="BTN_DETALLE" runat="server" onclick="detalle" Text="Detalle CC-PAC-005"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server" BorderColor="Black" BorderStyle="Solid">
                
                </asp:TableCell>
                 </asp:TableRow>
                  <asp:TableRow ID="TableRow3" runat="server" BorderColor="Black" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell ID="TableCell6" runat="server" BorderColor="Black" BorderStyle="Solid">
               
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="server" BorderColor="Black" BorderStyle="Solid">
              <asp:Button ID="btn_editar" runat="server" onclick="Editar" Text="Editar CC-PAC-005"  Font-Names="Century Gothic" Font-Size="X-Small" width="200"/>
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" runat="server" BorderColor="Black" BorderStyle="Solid">
                
                </asp:TableCell>
                 </asp:TableRow>
        </asp:Table>

    </fieldset>
</asp:Content>
