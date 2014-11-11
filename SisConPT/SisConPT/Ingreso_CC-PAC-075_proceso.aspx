<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso_CC-PAC-075_proceso.aspx.cs" Inherits="SisConPT.SisConPT.Ingreso_CC_PAC_075_proceso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
    <script type="text/javascript">

        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13 || window.event.keyCode == 10) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }
   
     <!--
        function ValidaDecimal(dato) {
            var valor = dato.indexOf(",");
            if ((window.event.keyCode > 47 && window.event.keyCode < 58) || window.event.keyCode == 44) {
                if (window.event.keyCode == 44) {
                    if (valor >= 0) {
                        window.event.returnValue = false;
                    }
                }
            } else {
                window.event.returnValue = false;
            }
        }

       

//        function isNumberKey(evt) {
//            var charCode = (evt.which) ? evt.which : event.keyCode
//            if (charCode > 31 && (charCode < 48 || charCode > 57))
//                return true;

//            return false;
//        }
     //-->
  </script>
   
   <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
     <fieldset>
        <legend>CC-PAC-075</legend>
<%-- <h3>CC-PAC-075</h3>--%>
 <asp:Panel ID="Panel1" runat="server">
   <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
            <asp:TableCell Width="30">
                <asp:Label ID="lbl_cod_proc" runat="server" Text="Código Proceso" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
              <asp:DropDownList ID="drop_proc_d"  runat="server" DataSourceID="drop_porc" DataTextField="PROC_NumeroProcesso" DataValueField="PROC_NumeroProcesso" Height="30px" Width="80" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="proc_SelectedIndexChanged">
        </asp:DropDownList> </asp:TableCell>
        
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_cod_plan" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
           <%--  <asp:Button ID="btn_buscar" runat="server" Text="Buscar" onclick="btnLoadData_click"/>--%>
        
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"></asp:TableCell></asp:TableRow>
<%--   </asp:Table>
        
    <asp:Button ID="btnLoadData"  runat="server"  style="display: none" />
          
        &nbsp;<br />
   <asp:Table ID="Table1" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="Small">--%>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
            <asp:Label ID="lbl_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lin_codice" DataValueField="lin_codice" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
              <asp:TableCell Width="30">
            <asp:Label ID="lbl_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno" DataTextField="TUR_Descrizione" DataValueField="TUR_Descrizione" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell><asp:TableCell Width="30">
            <asp:Label ID="lblLote" runat="server" Text="Lote" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_lote_d"  runat="server" DataSourceID="drop_lote" DataTextField="LOT_NumeroLotto" DataValueField="LOT_NumeroLotto" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="lote_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
   </asp:TableRow>
  </asp:Table>
   </asp:Panel></fieldset>
   <br />
    <fieldset>
        <legend>Seguimiento de Descarte Comercial por Lote</legend>
   <asp:Table ID="Table1" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small"  HorizontalAlign="Center" >
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
       <asp:TableCell Width="30">
             <asp:Label ID="lbldescarte" runat="server" Text="% Exportable Descarte Manual" Width="50" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txtDescarte"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtDescarte" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>
                   </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="lblCATII" runat="server" Text="% Exportable Comercial CAT II" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txtCATII"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell><asp:TableCell Width="30">
           <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtCATII" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>
             <asp:Label ID="lblCATIII" runat="server" Text="% Exportable Comercial CAT III" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txtCATIII"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
 
               <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtCatIII" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell></asp:TableRow></asp:Table><br />
           
       <fieldset>
           
        <legend>Rangos de trabajo y porcentajes</legend><asp:Table ID="Table2" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center" >
  
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
             <asp:TableCell Width="30">
             <asp:Label ID="lblRango" runat="server" Text="Rango" Width="40" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label4" runat="server" Text="3" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label5" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label1" runat="server" Text="8" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label2" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label3" runat="server" Text="21" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label6" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label7" runat="server" Text="18" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label8" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label9" runat="server" Text="25" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label10" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label11" runat="server" Text="19" Width="30" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label12" runat="server" Text="%" Width="30" Height="20"></asp:Label>
             </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20" >
            
            <asp:TableCell>
               <asp:Label ID="lblrango1" runat="server" Text="1" Width="30" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt3_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
           <%--     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt3_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt3_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt3_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt8_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
     <%--           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt8_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)"  runat="server" ID="txt8_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            <%--    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt8_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt21_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt21_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt21_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt21_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt18_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt18_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt18_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt18_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt25_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txt25_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt25_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txt25_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt19_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txt19_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt19_porc_1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txt19_porc_1" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
               <asp:TableCell>
               <asp:Label ID="Label16" runat="server" Text="2" Width="30" Height="20"></asp:Label>
            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt3_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txt3_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt3_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txt3_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt8_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txt8_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt8_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txt8_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt21_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txt21_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt21_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txt21_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt18_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txt18_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt18_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" TargetControlID="txt18_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt25_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txt25_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt25_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txt25_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt19_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" TargetControlID="txt19_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="txt19_porc_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" TargetControlID="txt19_porc_2" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell></asp:TableRow></asp:Table></fieldset> 
            
            <asp:Table ID="Table3" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
      <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30">
             <asp:Label ID="Label13" runat="server" Text="KILOS LOTE" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="KilosLote"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="KilosLote" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label14" runat="server" Text="N° TOTES" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="NTotes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="NTotes" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell><asp:TableCell Width="30">
             <asp:Label ID="Label15" runat="server" Text="% EXP" Width="50" Height="20"></asp:Label>
             </asp:TableCell><asp:TableCell>
                <asp:TextBox onkeypress ="return ValidaDecimal(this.value)" runat="server" ID="porc_exp"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="porc_exp" FilterType="Custom, numbers" ValidChars="." runat="server" />--%>

            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30">
             </asp:TableCell></asp:TableRow></asp:Table><asp:Table ID="Table4" runat="server" Width="653px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
      <asp:TableCell Width="30" HorizontalAlign="Center">
             <asp:Button ID="btnGrabar" runat="server" Text="Guardar" onclick="Grabar_Click"/>
             </asp:TableCell><asp:TableCell Width="30" HorizontalAlign="Center">
             <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="Limpiar_Click"/>
            
             </asp:TableCell></asp:TableRow></asp:Table></fieldset> 
             
             
             
             
             
   
             
             
             
             
             
             
             
             
             
             
             </asp:Content>