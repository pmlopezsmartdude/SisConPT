<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso_CC-PAC-003.aspx.cs" Inherits="SisConPT.SisConPT.Ingreso_CC_PAC_003" %>

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


  </script>
   
   <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  
   </asp:ToolkitScriptManager>  
     <fieldset>
        <legend>CC-PAC-003</legend>
 <asp:Panel ID="Panel1" runat="server">
   <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
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
               </asp:TableCell>
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_cod_plan" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
                  
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"></asp:TableCell></asp:TableRow>

   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
                <asp:Label ID="lbl_cod_proc" runat="server" Text="Código Proceso" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
              <asp:DropDownList ID="drop_proc_d"  runat="server" DataSourceID="drop_porc" DataTextField="PROC_NumeroProcesso" DataValueField="PROC_NumeroProcesso" Height="30px" Width="80" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="proc_SelectedIndexChanged">
        </asp:DropDownList> </asp:TableCell>
           
              <asp:TableCell Width="30">
            <asp:Label ID="lblLote" runat="server" Text="Lote" Width="50" Height="30"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_lote_d"  runat="server" DataSourceID="drop_lote" DataTextField="LOT_NumeroLotto" DataValueField="LOT_NumeroLotto" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="lote_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
   </asp:TableRow>
      <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
   <asp:TableCell Width="30">
                <asp:Label ID="Label37" runat="server" Text="Productor" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
              <asp:Label ID="lbl_productor" runat="server" Width="70" Height="30"></asp:Label>
             </asp:TableCell>
          
              <asp:TableCell Width="30">
            <asp:Label ID="Label40" runat="server" Text="Variedad" Width="50" Height="30"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
           <asp:DropDownList ID="drop_variedad_d"  runat="server" DataSourceID="drop_variedad" DataTextField="LOT_DescrizioneVarieta" DataValueField="LOT_DescrizioneVarieta" Height="30px" Width="100" Font-Names="Century Gothic" AutoPostBack="True" >
        </asp:DropDownList>     </asp:TableCell>
   </asp:TableRow>
  </asp:Table>
   </asp:Panel>

   <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="Panel1" Radius="8"> </cc1:RoundedCornersExtender> 
   
   </fieldset>
   <fieldset>
        <legend>DESCARTE COMERCIAL</legend>
        <asp:Table ID="Table1" runat="server" Width="700px" Height="30px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label33" runat="server" Text="DEFECTOS DE CALIDAD" Width="200" Height="20"></asp:Label>
             </asp:TableCell>
       

             <asp:TableCell Width="30">
             <asp:Label ID="Label34" runat="server" Text="DEFECTOS DE CONDICIÓN" Width="200" Height="20"></asp:Label>
             </asp:TableCell>
             
            
            
       </asp:TableRow>
       </asp:Table>
   <asp:Table ID="Table3" runat="server" Width="700px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label13" runat="server" Text="Precalibre" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_precalibre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" TargetControlID="txt_precalibre"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label1" runat="server" Text="Daños de Trips" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_trips"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txt_trips"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label17" runat="server" Text="Adhesión" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_adhesion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txt_adhesion"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label18" runat="server" Text="Deshid. de Frutos" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_deshid_frutos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txt_deshid_frutos"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label2" runat="server" Text="Escama" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_escama"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txt_escama"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label3" runat="server" Text="Frutos Deformes" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_frudeformes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txt_frudeformes"  FilterType="numbers"   runat="server" />
             </asp:TableCell>



             <asp:TableCell Width="30">
             <asp:Label ID="Label19" runat="server" Text="Deshid. Pedicelar" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_deshid_ped"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txt_deshid_ped"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label35" runat="server" Text="Blandos" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_blandos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" TargetControlID="txt_blandos"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell Width="30">
             <asp:Label ID="Label20" runat="server" Text="Frutos Dobles" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_dobles"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" TargetControlID="txt_dobles"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label4" runat="server" Text="Guata Blanca" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_guatablanca"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txt_guatablanca"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label5" runat="server" Text="Heridas Abiertas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_heri_abiertas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txt_heri_abiertas"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label21" runat="server" Text="Machucón" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_machucon"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txt_machucon"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
       <asp:TableCell Width="30">
             <asp:Label ID="Label22" runat="server" Text="Heridas cicatrizadas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_heri_cica"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txt_heri_cica"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label6" runat="server" Text="Manchas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_manchas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txt_manchas"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label7" runat="server" Text="Partiduras cicatrizadas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_part_cica"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txt_part_cica"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label23" runat="server" Text="Pitting" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pitting"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txt_pitting"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
       <asp:TableCell Width="30">
             <asp:Label ID="Label24" runat="server" Text="Media Luna" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_medluna"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" TargetControlID="txt_medluna"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label8" runat="server" Text="Piel de Lagarto" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_lagarto"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txt_lagarto"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label25" runat="server" Text="Pudrición" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" TargetControlID="txt_pudricion"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label26" runat="server" Text="Partiduras de Agua" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_part_agua"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txt_part_agua"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label10" runat="server" Text="Russet" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_russet"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txt_russet"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label11" runat="server" Text="Sutura" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sutura"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txt_sutura"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label27" runat="server" Text="Manchas Pardas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pardas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" TargetControlID="txt_pardas"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label28" runat="server" Text="Daño de Pajaro" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pajaro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" TargetControlID="txt_pajaro"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label12" runat="server" Text="Falto Color" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_faltocolor"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txt_faltocolor"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label14" runat="server" Text="Ramaleo" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_ramaleo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txt_ramaleo"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label29" runat="server" Text="Desgarros" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_desgarros"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="txt_desgarros"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label30" runat="server" Text="Cortes de sierras" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sierras"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" TargetControlID="txt_sierras"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label15" runat="server" Text="Sin pedicelo" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pedicelo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txt_pedicelo"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
            
             </asp:TableCell>
             <asp:TableCell>
                   </asp:TableCell>

         <asp:TableCell Width="30">
             <asp:Label ID="Label49" runat="server" Text="Sutura Expuesta" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sut_exp"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" TargetControlID="txt_sut_exp"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
              </asp:TableCell>
             <asp:TableCell>
               </asp:TableCell>
       </asp:TableRow>


             
   </asp:Table>
       <asp:Table ID="Table2" runat="server" Width="700px" Height="30px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label9" runat="server" Text="TOTAL DEFECTOS DE CALIDAD" Width="250" Height="20"></asp:Label>
             </asp:TableCell>
          <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_defcalidad"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" TargetControlID="txt_defcalidad"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label16" runat="server" Text="TOTAL DEFECTOS DE CONDICIÓN" Width="250" Height="20"></asp:Label>
             </asp:TableCell>
             
              <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_defcondicion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" TargetControlID="txt_defcondicion"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
            
       </asp:TableRow>
       </asp:Table>
             </fieldset>





                  <asp:TabContainer ID="TabContainer1" runat="server">

<asp:TabPanel runat="server" HeaderText="EXPORTABLE" ID="PANEL_EXPORTABLE"  Enabled ="true" >
    <ContentTemplate>

     <asp:Table ID="Table4" runat="server" Width="400px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label38" runat="server" Text="" Width="30" Height="20"></asp:Label> 
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:Label ID="Label39" runat="server" Text="QC" Width="30" Height="20"></asp:Label> </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label41" runat="server" Text="COMP" Width="30" Height="20"></asp:Label>
             </asp:TableCell>
            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label42" runat="server" Text="% Fruta Comercial <10% Sin Pudrición" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_pudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" TargetControlID="txt_qc_pudricion"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

   
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_pudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" TargetControlID="txt_comp_pudricion"  FilterType="numbers"   runat="server" />
             </asp:TableCell>



             
            
       </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
             <asp:TableCell Width="30">
            <center> <asp:Label ID="Label43" runat="server" Text="% Desecho < a 2%" Width="150" Height="20"></asp:Label></center>
             </asp:TableCell>
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_deshechos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" TargetControlID="txt_qc_deshechos"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

     
          <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_deshechos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" TargetControlID="txt_comp_deshechos"  FilterType="numbers"   runat="server" />
             </asp:TableCell>



             
            
       </asp:TableRow>
   



             
   </asp:Table>






    </ContentTemplate>
</asp:TabPanel>


<asp:TabPanel runat="server" HeaderText="COMERCIAL" ID="PANEL_COMERCIAL"  Enabled ="true" >
    <ContentTemplate>

     <asp:Table ID="Table6" runat="server" Width="400px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label44" runat="server" Text="" Width="30" Height="20"></asp:Label> 
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:Label ID="Label45" runat="server" Text="QC" Width="30" Height="20"></asp:Label> </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label46" runat="server" Text="COMP" Width="30" Height="20"></asp:Label>
             </asp:TableCell>
            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label47" runat="server" Text="% Exportable" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_exportable"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" TargetControlID="txt_qc_exportable"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

   
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_exportable"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" TargetControlID="txt_comp_exportable"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

    </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
             <asp:TableCell Width="30">
            <center> <asp:Label ID="Label48" runat="server" Text="% Desecho < a 2%" Width="150" Height="20"></asp:Label></center>
             </asp:TableCell>
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_deshecho_com"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" TargetControlID="txt_qc_deshecho_com"  FilterType="numbers"   runat="server" />
             </asp:TableCell>

     
          <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_deshecho_com"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" TargetControlID="txt_comp_deshecho_com"  FilterType="numbers"   runat="server" />
             </asp:TableCell>



             
            
       </asp:TableRow>
   



             
   </asp:Table>






    </ContentTemplate>
</asp:TabPanel>

<asp:TabPanel runat="server" HeaderText="DESECHO" ID="PANEL_DESHECHO"  Enabled ="true" >
    <ContentTemplate>

     <asp:Table ID="Table7" runat="server" Width="400px" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
         <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label31" runat="server" Text="N° Frutos" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_num_frutos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txt_num_frutos"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
            
            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label52" runat="server" Text="% Exportable < 2%" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_exportable_2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" TargetControlID="txt_exportable_2"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
            
            
       </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label32" runat="server" Text="% Comercial < 5%" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comercial_5"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" TargetControlID="txt_comercial_5"  FilterType="numbers"   runat="server" />
             </asp:TableCell>
            
            
       </asp:TableRow>
   



             
   </asp:Table>






    </ContentTemplate>
</asp:TabPanel>

<asp:TabPanel runat="server" HeaderText="OBSERVACIONES" ID="PANEL_OBSERVACIONES"  Enabled ="true" >
    <ContentTemplate>

 

  <asp:Table ID="Table5" runat="server" Width="900px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" >
   
   <asp:TableRow Width="162px">
   <asp:TableCell>
       <asp:Label ID="Label36" runat="server" Text="Label">Observaciones</asp:Label><br />
       <center><asp:TextBox ID="txt_obser" runat="server" Height="120" Width="600" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine">0</asp:TextBox></center>
   </asp:TableCell>   </asp:TableRow>
      <asp:TableRow Width="162px">
   <asp:TableCell>

   </asp:TableCell>   </asp:TableRow>
   <asp:TableRow Width="162px">
   <asp:TableCell>
     </asp:TableCell>   </asp:TableRow>
   </asp:Table>
   

    </ContentTemplate>
</asp:TabPanel>

    </asp:TabContainer>


    <center><asp:Button ID="guardar" runat="server" Text="Guardar" Enabled="true" OnClick="Click_guardar" />
    <asp:Button ID="limpiar" runat="server" Text="Limpiar" Enabled="true" OnClick="Click_limpiar" />

        
          
        
        </center>








    </asp:Content>