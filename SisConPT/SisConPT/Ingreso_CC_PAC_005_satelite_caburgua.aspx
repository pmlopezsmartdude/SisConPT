<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso_CC_PAC_005_satelite_caburgua.aspx.cs" Inherits="SisConPT.SisConPT.Ingreso_CC_PAC_005_satelite_caburgua" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <script type="text/javascript">

    </script>
      <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
  
   <fieldset>
        <legend>CC-PAC-005</legend>
    <asp:Panel ID="Panel1" runat="server" >

        <asp:Table ID="Table_15" runat="server" Width="776px" Height="50px" 
            Font-Names="Century Gothic" Font-Size="X-Small" style="margin-bottom: 0px">
            
            <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
            <asp:Label ID="lbl_planta_nombre" runat="server" Font-Bold="true" Width="400" Height="20" Font-Names="Century Gothic" Font-Size="Medium"></asp:Label>
            </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
             <asp:Table ID="Table5" runat="server" Width="776px" Height="50px" 
            Font-Names="Century Gothic" Font-Size="X-Small" style="margin-bottom: 0px">
                    <asp:TableRow ID="TableRow19" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell Width="30">
    <asp:Label ID="Label_1" runat="server" Text="Código Caja" Font-Bold="true" Width="200" Height="20" Font-Names="Century Gothic" Font-Size="Small"></asp:Label>
       </asp:TableCell>
       <asp:TableCell Width="30">
    <asp:TextBox ID="CodCaja" MaxLength="14"  runat="server" Height="25" Font-Names="Century Gothic" Font-Size="Small" ValidationGroup="ChangeUserPasswordValidationGroup"></asp:TextBox>
    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" TargetControlID="CodCaja" FilterType="numbers"  runat="server" />
    </asp:TableCell><asp:TableCell>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CodCaja" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Código de caja"  ValidationGroup="ChangeUserPasswordValidationGroup"/>
        </asp:TableCell><asp:TableCell> 
      </asp:TableCell><asp:TableCell><asp:CheckBox ID="check_fecha" runat="server" Text="Ingresar Fecha Manual" AutoPostBack="true" oncheckedchanged="check_fecha_CheckedChanged"/> 
      </asp:TableCell><asp:TableCell> <asp:TextBox ID="Fecha_manual" runat="server" Width="70" >
       </asp:TextBox><asp:ImageButton ID="imgPopup" ImageUrl="~/Images/calendar.png" ImageAlign="Bottom"
    runat="server" />

   <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="Fecha_manual"
    Format="yyyy-MM-dd">
</cc1:CalendarExtender>
      </asp:TableCell><asp:TableCell> 
      </asp:TableCell></asp:TableRow></asp:Table></asp:Panel><asp:Table ID="UnitecDatos" runat="server" Width="800px" Height="90px" Font-Names="Century Gothic" Font-Size="X-Small">

        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell Width="60"><asp:Label ID="label_turno" runat="server" Text="Turno" Width="80" Height="20"></asp:Label></asp:TableCell><asp:TableCell Width="60"><asp:DropDownList ID="DDL_turno_d"  runat="server" Width="120" DataSourceID="DDL_turno" DataTextField="turno" DataValueField="turno" Height="25"  Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="turno_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell><asp:TableCell Width="60"></asp:TableCell><asp:TableCell Width="60"><asp:Label ID="label_especie" runat="server" Text="Especie" width="80" Height="20"></asp:Label></asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="especietext" runat="server"  Width="60" Height="20" ReadOnly="true" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120"><asp:DropDownList ID="DDL_cod_especie_d"  runat="server" Width="150" DataSourceID="DDL_cod_especie" DataTextField="DESCESPECIE"  DataValueField="CODESPECIE" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="especie_SelectedIndexChanged"> </asp:DropDownList>
                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell Width="60">
                <asp:Label ID="label_linea" runat="server" Text="Linea"  Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60">
                <asp:DropDownList ID="DDL_linea_d"  runat="server" Width="120" DataSourceID="DDL_linea" DataTextField="linea" DataValueField="linea" Height="25"  Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="linea_SelectedIndexChanged"> </asp:DropDownList>
                           </asp:TableCell><asp:TableCell Width="60">
       </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="label_variedad" runat="server" Text="Variedad" width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_variedad_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120">
                
                <asp:DropDownList ID="DDL_variedad_d"  runat="server" Width="150" DataSourceID="DDL_variedad" DataTextField="VARDESC" DataValueField="COD_VARIEDAD" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="variedad_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell Width="60">
                <asp:Label ID="Label1" runat="server" Text="Proceso" width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="120">
                <asp:Textbox MaxLength="5" ID="NroProceso" runat="server"   Width="110" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Textbox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" TargetControlID="NroProceso" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell Width="60">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NroProceso" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Proceso"  ValidationGroup="ChangeUserPasswordValidationGroup"/>
        </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="Label2" runat="server" Text="Marca" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_marca_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120">
                
                <asp:DropDownList ID="DDL_marca_d"  runat="server" Width="150" DataSourceID="DDL_marca" DataTextField="MARCA_NOMBRE" DataValueField="MARCA_COD" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="marca_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell Width="60">
                <asp:Label ID="Label3" runat="server" Text="Lote" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="120">
                <asp:TextBox MaxLength="5" ID="Lote" runat="server"   Width="110" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" TargetControlID="Lote" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell Width="60">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Lote" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Lote" ValidationGroup="ChangeUserPasswordValidationGroup"/>
        </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="Label4" runat="server" Text="Embalaje" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_embalaje_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120">
                
                <asp:DropDownList ID="DDL_embalaje_d"  runat="server" Width="150" DataSourceID="DDL_embalaje" DataTextField="DESCRIPCION" DataValueField="COD_EMBALAJE" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="embalaje_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             
            <asp:TableCell Width="60">
                <asp:Label ID="Label5" runat="server" Text="Peso" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="120">
                <asp:TextBox MaxLength="5" ID="Peso" runat="server"   Width="110" Height="20" Enabled="true" ReadOnly="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell><asp:TableCell Width="60">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Peso" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Peso"  ValidationGroup="ChangeUserPasswordValidationGroup"/>
        </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="Label_envase" runat="server" Text="Envase" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_envase_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120">
                <asp:DropDownList ID="DDL_envase_d"  runat="server" Width="150" DataSourceID="DDL_envase" DataTextField="nombre" DataValueField="alias" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="envase_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           <asp:TableCell Width="60">
                <asp:Label ID="Label7" runat="server" Text="Calibre" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60">
                <asp:DropDownList ID="DDL_calibre_d"  runat="server" Width="120" DataSourceID="DDL_calibre" DataTextField="calibre" DataValueField="calibre" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="calibre_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell><asp:TableCell Width="60">
        </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="Label8" runat="server" Text="Prod. Real" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_prodreal_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120">
                <asp:DropDownList ID="DDL_prodreal_d"  runat="server" Width="150" DataSourceID="DDL_prodreal" DataTextField="DESCRIPCION" DataValueField="ALIAS" Height="25"  Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="prodreal_SelectedIndexChanged" > </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           <asp:TableCell Width="60">
                <asp:Label ID="Label9" runat="server" Text="Salida" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="120">
                <asp:DropDownList ID="DDL_salida_d"  runat="server" Width="120" DataSourceID="DDL_salida" DataTextField="sal_descrip" DataValueField="sal_descrip" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="salida_SelectedIndexChanged"> </asp:DropDownList>
            </asp:TableCell><asp:TableCell Width="60">
     
        </asp:TableCell><asp:TableCell Width="60">
                <asp:Label ID="Label10" runat="server" Text="Prod. Etiquetado" Width="100" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell Width="60"><asp:TextBox ID="txt_prodetiq_cod" ReadOnly="True" runat="server"  Width="60" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox></asp:TableCell><asp:TableCell Width="120"> <asp:DropDownList ID="DDL_prodetiq_d"  runat="server" Width="150" DataSourceID="DDL_prodetiq" DataTextField="DESCRIPCION" DataValueField="ALIAS" Height="25"  Font-Names="Century Gothic" AutoPostBack="True" onselectedindexchanged="prodetiq_SelectedIndexChanged"> </asp:DropDownList></asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            </asp:TableRow></asp:Table><asp:Table ID="Table3" runat="server" Width="732px" Height="50px" 
            Font-Names="Century Gothic" Font-Size="X-Small">
   
         
          <asp:TableRow ID="TableRow15" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label21" runat="server" Text="Clasificación" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
               <asp:DropDownList ID="DDL_clasi_d"  runat="server" Width="120" DataSourceID="DDL_clasi" DataTextField="clasi_descrip" DataValueField="clasi_descrip" Height="25"  Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="clasi_SelectedIndexChanged"> </asp:DropDownList>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label22" runat="server" Text="Destino" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox   runat="server" ID="txt_destino"  Width="150" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label23" runat="server" Text="Cajas Vaciadas" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_cajasvaciadas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" TargetControlID="txt_cajasvaciadas" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
            <asp:Label ID="LabelPesoNeto" runat="server" Text="Peso Neto" Width="80" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
            <asp:TextBox MaxLength="7"  runat="server" ID="txt_peso_neto" Width="50" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" TargetControlID="txt_peso_neto" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell></asp:TableRow></asp:Table></fieldset> <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
<asp:TabPanel runat="server" HeaderText="DEFECTOS" ID="TabPanel1"  Enabled ="true" >
    <ContentTemplate>

     <asp:Table ID="ingresoDatos" runat="server" Width="900px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC">
          <asp:TableRow ID="TableRow12" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="label_calibre" runat="server" Height="30">Calibre</asp:Label>
            </asp:TableCell><asp:TableCell>
           
            </asp:TableCell><asp:TableCell>
                 <asp:Label ID="label_defectos" runat="server" Height="30">Defectos de Calidad</asp:Label>
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
               
            </asp:TableCell><asp:TableCell>
               
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="label_condicion" runat="server" Height="30">Defectos de Condición</asp:Label>
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
              
            </asp:TableCell><asp:TableCell>
               
            </asp:TableCell></asp:TableRow><asp:TableRow ID="fila1" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblbajo" runat="server" Height="10">Bajo (<10%)</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtbajo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtbajo" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblprecalibre" runat="server" Height="10">Pre Calibre</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtprecalibre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtprecalibre" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblrusset" runat="server" Height="10">Russet</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtrusset"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtrusset" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbladhesion" runat="server" Height="10">Adhesion</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtadhesion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtadhesion" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpudricion" runat="server" Height="10">Pudricion</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtpudricion" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="fila2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblcalibreok" runat="server" Height="10">Calibre OK</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcalibreok"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtcalibreok" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbldanotrip" runat="server" Height="10">Daño Trip</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanotrip"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtdanotrip" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblsutura" runat="server" Height="10">Sutura</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsutura"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtsutura" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbldeshid" runat="server" Height="10">Deshidratacion de Frutos</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshid"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtdeshid" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblmanchaspardas" runat="server" Height="10">Manchas Pardas</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchaspardas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtmanchaspardas" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="fila3" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblsobre" runat="server" Height="10">Sobre (<20 %)</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsobre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtsobre" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblescama" runat="server" Height="10">Escama</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtescama"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtescama" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblfaltocolor" runat="server" Height="10">Falto de Color</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfaltocolor"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtfaltocolor" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbldeshidpedi" runat="server" Height="10">Deshidratacion Pedicelar</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshidpedi"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txtdeshidpedi" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbldanopajaro" runat="server" Height="10">Daño de Pajaro</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanopajaro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txtdanopajaro" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblfrutosdeformes" runat="server" Height="10">Frutos Deformes</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdeformes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txtfrutosdeformes" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblramaleo" runat="server" Height="10">Ramaleo</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtramaleo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtramaleo" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblblandos" runat="server" Height="10">Blandos</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtblandos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtblandos" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lbldesgarro" runat="server" Height="10">Desgarro</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdesgarro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txtdesgarro" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblfrutosdobles" runat="server" Height="10">Frutos Dobles</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdobles"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txtfrutosdobles" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblsinpedicelo" runat="server" Height="10">Sin Pedicelo</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsinpedicelo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txtsinpedicelo" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblheridasabiertas" runat="server" Height="10">Heridas Abiertas</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtheridasabiertas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txtheridasabiertas" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblcortesierra" runat="server" Height="10">Corte de Sierra</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcortesierra"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" TargetControlID="txtcortesierra" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblguatablanca" runat="server" Height="10">Guata Blanca</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtguatablanca"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txtguatablanca" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblmachucon" runat="server" Height="10">Machucon</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmachucon"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txtmachucon" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label12" runat="server" Height="10">Sutura Expuesta</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_sut_exp"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" TargetControlID="txt_sut_exp" FilterType="numbers"  runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblherida" runat="server" Height="10">Herida</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtherida"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" TargetControlID="txtherida" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpartiduras" runat="server" Height="10">Partiduras</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduras"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" TargetControlID="txtpartiduras" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblmanchas" runat="server" Height="10">Manchas</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="txtmanchas" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpartidurasagua" runat="server" Height="10">Partiduras por Agua</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartidurasagua"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="txtpartidurasagua" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
            </asp:TableCell><asp:TableCell>
        
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblmedialuna" runat="server" Height="10">Media Luna</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmedialuna"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="txtmedialuna" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpartiduracicatrizada" runat="server" Height="10">Partidura Cicatrizada</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduracicatrizada"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" TargetControlID="txtpartiduracicatrizada" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
	    </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpiellagarto" runat="server" Height="10">Piel de Lagarto</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpiellagarto"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" TargetControlID="txtpiellagarto" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblpitting" runat="server" Height="10">Pitting</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpitting"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" TargetControlID="txtpitting" FilterType="numbers"  runat="server" />
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell><asp:TableCell>
                
            </asp:TableCell></asp:TableRow></asp:Table></ContentTemplate></asp:TabPanel><asp:TabPanel runat="server" HeaderText="SOLIDOS SOLUBLES" ID="TabPanel3"  Enabled ="true" >
    <ContentTemplate>

    <fieldset>
        <legend>SOLIDOS SOLUBLES    : <asp:Label ID="lbl_calibre" runat="server" Height="10"></asp:Label></legend><asp:Table ID="Table2" runat="server" Width="827px" Height="50px"  Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC" HorizontalAlign="Center">
   
   
   </asp:Table>
    <asp:Table ID="Table_solubles" runat="server" Width="827px" Height="50px"  Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC" HorizontalAlign="Center">
    <asp:TableRow ID="TableRow16" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label11" runat="server" Height="10">F 1</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_f1"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" TargetControlID="txt_f1" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label16" runat="server" Height="10">F 2</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_f2"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" TargetControlID="txt_f2" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label17" runat="server" Height="10">F 3</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_f3"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" TargetControlID="txt_f3" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label18" runat="server" Height="10">F 4</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_f4"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" TargetControlID="txt_f4" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="Label19" runat="server" Height="10">F 5</asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox  MaxLength="4"    runat="server" ID="txt_f5"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" TargetControlID="txt_f5" FilterType="numbers, Custom" Validchars="." runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow13" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">

 <asp:TableCell>
              

 </asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow14" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">

 <asp:TableCell>
              

 </asp:TableCell></asp:TableRow></asp:Table></fieldset></ContentTemplate></asp:TabPanel><asp:TabPanel runat="server" HeaderText="OBSERVACIONES" ID="TabPanel2"  Enabled ="true" >
    <ContentTemplate>

    <asp:Table ID="Table1" runat="server" Width="900px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC">
   
   <asp:TableRow Width="162px">
   <asp:TableCell>
       <asp:Label ID="Label6" runat="server" Text="Label">Observaciones</asp:Label><br />
       <center><asp:TextBox ID="TextBox1obs" runat="server" Height="120" Width="600" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine">0</asp:TextBox></center>
   </asp:TableCell></asp:TableRow><asp:TableRow Width="162px">
   <asp:TableCell>

   </asp:TableCell></asp:TableRow><asp:TableRow Width="162px">
   <asp:TableCell>

   </asp:TableCell></asp:TableRow></asp:Table></ContentTemplate></asp:TabPanel></asp:TabContainer><asp:Table ID="Table4" runat="server" Width="732px" Height="50px" Font-Names="Century Gothic" Font-Size="X-Small" HorizontalAlign="Center">
   
         
          <asp:TableRow ID="TableRow17" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="50">

            <asp:TableCell>
            <asp:Button ID="Grabar" runat="server" Text="Guardar y Salir" Enabled="True" onclick="Grabar_Click" Width="100" ValidationGroup="ChangeUserPasswordValidationGroup"/>
            </asp:TableCell><asp:TableCell>
            <asp:Button ID="Limpiar" runat="server" Text="Limpiar" onclick="btn_limpiar" Enabled="True" Width="100" />
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>