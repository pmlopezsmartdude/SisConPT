<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle_CC_PAC_005.aspx.cs" Inherits="SisConPT.SisConPT.Detalle_CC_PAC_005" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  


<fieldset>
   <legend>Detalle CC-PAC-005 Producto Terminado</legend>
   <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
           
        
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_codpla" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
                  
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  
    <asp:TableCell Width="60">
    </asp:TableCell>
    </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
            <asp:Label ID="lbl_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lincodigo" DataValueField="lincodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
              <asp:TableCell Width="30">
            <asp:Label ID="lbl_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno_d" DataTextField="turcodigo" DataValueField="turcodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
               <asp:TableCell Width="60">
             <asp:Button ID="Exportar_005" runat="server" Text="Exportar" Enabled="true" OnClick="Exportar_click" />
                 
               </asp:TableCell>
            
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
         

  
   </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
            <asp:Label ID="Label10" runat="server" Text="Fecha Inicio" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
   <asp:TableCell Width="30">
       <asp:TextBox ID="txt_fechainicio" runat="server" Width="70"  >
       </asp:TextBox><asp:ImageButton ID="imgPopup" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" />

   <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txt_fechainicio"
    Format="yyyy-MM-dd">
</cc1:CalendarExtender>
   </asp:TableCell>
     <asp:TableCell Width="30">
            <asp:Label ID="Label12" runat="server" Text="Fecha Fin" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
   <asp:TableCell Width="30">
       <asp:TextBox ID="txt_fechafin" runat="server" Width="70"   ></asp:TextBox><asp:ImageButton ID="imgPopup_fin" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" />

   <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup_fin" runat="server" TargetControlID="txt_fechafin"
    Format="yyyy-MM-dd">
</cc1:CalendarExtender>
   </asp:TableCell>
   <asp:TableCell Width="60">
    <asp:Button ID="Filtrar_fecha" runat="server" Text="  Buscar  " Enabled="true" OnClick="Filtrar" />

    </asp:TableCell>
   </asp:TableRow>
  </asp:Table>
  </fieldset>
 <asp:Panel ID="Panel1" runat="server">
    <fieldset>
        <legend>DETALLE</legend>

          <asp:GridView ID="gvProcesos" runat="server" CellPadding="2" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="cptnumero" BackColor="White" Font-Names="Century Gothic" Font-Size="Small"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            onpageindexchanging="Procesos_PageIndexChanging"  
                            HorizontalAlign="Center" style="width:800px">
                            <Columns>
                               
                                <asp:BoundField DataField="cptcodcja" HeaderText="CAJA"  />
                                <asp:BoundField DataField="cptproces" HeaderText="PROCESO" />
                                <asp:BoundField DataField="cptnulote" HeaderText="LOTE" />
                                <asp:BoundField DataField="cptfechor" HeaderText="FECHA" />
                                <asp:BoundField DataField="cptvardes" HeaderText="VARIEDAD" />
                                <asp:BoundField DataField="calibresoluble" HeaderText="CALIBRE" />
                                <asp:BoundField DataField="cptdestino" HeaderText="DESTINO" />
                                
                      </Columns>
                        
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#005eb7" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#007cf2" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#90c9ff" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#cbe6ff" />
                        </asp:GridView>

        <br />
        <br />

        </fieldset>
   </asp:Panel>
  </asp:Content>