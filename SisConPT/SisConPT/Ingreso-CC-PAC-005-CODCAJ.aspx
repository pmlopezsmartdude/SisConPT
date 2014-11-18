<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/SisConPT/Ingreso-CC-PAC-005-CODCAJ.aspx.cs" Inherits="SisConPT.SisConPT.Ingreso_CC_PAC_005_CODCAJ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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

    </script>
      <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
  
    <h3>CC-PAC-005</h3>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonBuscar">
    <asp:Label ID="Label1" runat="server" Text="Código Caja" Height="20px" Font-Names="Century Gothic" Font-Size="Small"></asp:Label>
       
    <asp:TextBox ID="CodCaja" runat="server" Height="25" Font-Names="Century Gothic" 
            Font-Size="Small" BorderColor="Red"></asp:TextBox>
     
    <asp:Button ID="btnLoadData"  runat="server"  style="display: none" />
    <asp:Label ID="Label3" runat="server" Text="Código Planta" Height="20px" Font-Names="Century Gothic" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="CodPta" runat="server" Height="25px" Font-Names="Cenruty Gothic" 
            Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>
        &nbsp;<asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" onclick="btnLoadData_click"/>
    <br />

    </asp:Panel>
    <asp:Table ID="UnitecDatos" runat="server" Width="653px" Height="90px" Font-Names="Century Gothic" Font-Size="X-Small">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell Width="30">
                <asp:Label ID="Label2" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                <asp:TextBox ID="Turno" runat="server" ReadOnly="True" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label7" runat="server" Text="Especie" width="30" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="10">
                <asp:TextBox ID="especieid" runat="server" ReadOnly="True" Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="especietext" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">

            <asp:TableCell>
                <asp:Label ID="Label4" runat="server" Text="Linea" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                <asp:TextBox ID="Linea" runat="server" ReadOnly="True" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label5" runat="server" Text="Variedad" width="30" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell >
                <asp:TextBox ID="Variedad" runat="server" ReadOnly="True" width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="VariedadText" runat="server" ReadOnly="True" Width="70" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell>
                <asp:Label runat="server">Proceso</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Textbox ID="NroProceso" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Textbox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Marca</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Marca" runat="server" ReadOnly="true" Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MarcaTxt" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Lote</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Lote" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Embalaje</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Embalaje" runat="server" ReadOnly="true" Width="60" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Embalajetx" runat="server" ReadOnly="true" Width="150" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Peso</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Peso" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Envase</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Envase" runat="server" ReadOnly="true" Width="60" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Envasetxt" runat="server" ReadOnly="true" Width="190" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="Calibre" ReadOnly="true" Width="70" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Prod. Real</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdReal" ReadOnly="true" Width="40" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdRealtxt" ReadOnly="true" Width="100" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Salida</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="Salida" ReadOnly="true" Width="50" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Prod. Etiquetado</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdEtiq" ReadOnly="true" Width="40" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdEtiqtxt" ReadOnly="true" Width="100" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>



        <asp:TableRow ID="TableRow11" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell>
               
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
     <asp:Table ID="Table3" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="X-Small">
   
         
          <asp:TableRow ID="TableRow15" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label21" runat="server" Height="10">Clasificación</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  runat="server" ID="txt_calisificacion"  Width="150" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label22" runat="server" Height="10">Destino</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox   runat="server" ID="txt_destino"  Width="150" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label23" runat="server" Height="10">Cajas Vaciadas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_cajasvaciadas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" TargetControlID="txt_cajasvaciadas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
   
              
 </asp:TableRow>
        

         </asp:Table>

     <asp:TabContainer ID="TabContainer1" runat="server">
<asp:TabPanel runat="server" HeaderText="DEFECTOS" ID="TabPanel1"  Enabled ="true" >
    <ContentTemplate>

     <asp:Table ID="ingresoDatos" runat="server" Width="900px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC">
          <asp:TableRow ID="TableRow12" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label8" runat="server" Height="30">Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
           
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="Label9" runat="server" Height="30">Defectos de Calidad</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label11" runat="server" Height="30">Defectos de Condición</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
              
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
 </asp:TableRow>
         
         
          <asp:TableRow ID="TableRow1" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblbajo" runat="server" Height="10">Bajo (<10%)</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtbajo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtbajo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblprecalibre" runat="server" Height="10">Pre Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtprecalibre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtprecalibre" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblrusset" runat="server" Height="10">Russet</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtrusset"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtrusset" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbladhesion" runat="server" Height="10">Adhesion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtadhesion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtadhesion" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpudricion" runat="server" Height="10">Pudricion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtpudricion" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblcalibreok" runat="server" Height="10">Calibre OK</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcalibreok"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtcalibreok" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanotrip" runat="server" Height="10">Daño Trip</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanotrip"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtdanotrip" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsutura" runat="server" Height="10">Sutura</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsutura"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtsutura" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshid" runat="server" Height="10">Deshidratacion de Frutos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshid"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtdeshid" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmanchaspardas" runat="server" Height="10">Manchas Pardas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchaspardas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtmanchaspardas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>


          <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblsobre" runat="server" Height="10">Sobre (<20 %)</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsobre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtsobre" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblescama" runat="server" Height="10">Escama</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtescama"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtescama" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfaltocolor" runat="server" Height="10">Falto de Color</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfaltocolor"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtfaltocolor" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshidpedi" runat="server" Height="10">Deshidratacion Pedicelar</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshidpedi"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txtdeshidpedi" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanopajaro" runat="server" Height="10">Daño de Pajaro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanopajaro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txtdanopajaro" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfrutosdeformes" runat="server" Height="10">Frutos Deformes</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdeformes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txtfrutosdeformes" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblramaleo" runat="server" Height="10">Ramaleo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtramaleo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtramaleo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblblandos" runat="server" Height="10">Blandos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtblandos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtblandos" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldesgarro" runat="server" Height="10">Desgarro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdesgarro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txtdesgarro" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfrutosdobles" runat="server" Height="10">Frutos Dobles</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdobles"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txtfrutosdobles" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsinpedicelo" runat="server" Height="10">Sin Pedicelo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsinpedicelo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txtsinpedicelo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblheridasabiertas" runat="server" Height="10">Heridas Abiertas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtheridasabiertas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txtheridasabiertas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblcortesierra" runat="server" Height="10">Corte de Sierra</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcortesierra"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" TargetControlID="txtcortesierra" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>

          <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblguatablanca" runat="server" Height="10">Guata Blanca</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtguatablanca"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txtguatablanca" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmachucon" runat="server" Height="10">Machucon</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmachucon"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txtmachucon" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblherida" runat="server" Height="10">Herida</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtherida"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" TargetControlID="txtherida" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduras" runat="server" Height="10">Partiduras</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduras"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" TargetControlID="txtpartiduras" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmanchas" runat="server" Height="10">Manchas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="txtmanchas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartidurasagua" runat="server" Height="10">Partiduras por Agua</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartidurasagua"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="txtpartidurasagua" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label13" runat="server" Height="10">Solidos Solubles</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="CheckSoluble" runat="server" />

	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmedialuna" runat="server" Height="10">Media Luna</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmedialuna"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="txtmedialuna" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduracicatrizada" runat="server" Height="10">Partidura Cicatrizada</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduracicatrizada"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" TargetControlID="txtpartiduracicatrizada" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpiellagarto" runat="server" Height="10">Piel de Lagarto</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpiellagarto"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" TargetControlID="txtpiellagarto" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpitting" runat="server" Height="10">Pitting</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpitting"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" TargetControlID="txtpitting" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>

         </asp:Table>







    </ContentTemplate>
</asp:TabPanel>


<asp:TabPanel runat="server" HeaderText="SOLIDOS SOLUBLES" ID="TabPanel3"  Enabled ="true" >
    <ContentTemplate>


    <asp:Table ID="Table2" runat="server" Width="827px" Height="50px"  Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC" HorizontalAlign="Center">
   
    <asp:TableRow ID="TableRow13" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label12" runat="server" Height="10">SOLIDOS SOLUBLES</asp:Label>
      
 </asp:TableCell>
           
            <asp:TableCell>
                
        <asp:DropDownList ID="SOLUBLE_D"  runat="server" DataSourceID="SOLUBLE" DataTextField="SOL_DESCRIP" DataValueField="SOL_ID" Height="30" Width="50" Font-Names="Century Gothic"  AutoPostBack="False" onselectedindexchanged="SOL_SelectedIndexChanged">
        </asp:DropDownList>
 </asp:TableCell>
 
 <asp:TableCell>
              <asp:Button ID="Button1" runat="server" Text="Guardar"  Enabled="True" onclick="Grabar_soluble" />   
 
 </asp:TableCell>
       
   </asp:TableRow>
   </asp:Table>
    <asp:Table ID="Table_solubles" runat="server" Width="827px" Height="50px"  Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC" HorizontalAlign="Center">
    <asp:TableRow ID="TableRow16" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label10" runat="server" Height="10">F 1</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_f1"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" TargetControlID="txt_f1" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label16" runat="server" Height="10">F 2</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_f2"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" TargetControlID="txt_f2" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label17" runat="server" Height="10">F 3</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_f3"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" TargetControlID="txt_f3" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label18" runat="server" Height="10">F 4</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_f4"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" TargetControlID="txt_f4" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label19" runat="server" Height="10">F 5</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_f5"  Width="40" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" TargetControlID="txt_f5" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
  
</asp:Table>


    </ContentTemplate>
</asp:TabPanel>


<asp:TabPanel runat="server" HeaderText="OBSERVACIONES" ID="TabPanel2"  Enabled ="true" >
    <ContentTemplate>

    <asp:Table ID="Table1" runat="server" Width="900px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" BackColor="#CCCCCC">
   
   <asp:TableRow Width="162px">
   <asp:TableCell>
       <asp:Label ID="Label6" runat="server" Text="Label">Observaciones</asp:Label><br />
       <center><asp:TextBox ID="TextBox1obs" runat="server" Height="120" Width="600" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine">0</asp:TextBox></center>
   </asp:TableCell>
   </asp:TableRow>
   </asp:Table>


    </ContentTemplate>
</asp:TabPanel>

    </asp:TabContainer>







    <center><asp:Button ID="Siguiente1" runat="server" Text="Siguiente" Enabled="false" OnClick="Siguiente1_cick" />
    <asp:Button ID="Grabar" runat="server" Text="Grabar" Enabled="False" 
            onclick="Grabar_Click" />
        <asp:Button ID="Limpiar" runat="server"
        Text="Limpiar" onclick="Limpiar_Click" Enabled="False" /></center>
        <br />

 
</asp:Content>
