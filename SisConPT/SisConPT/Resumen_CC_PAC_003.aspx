<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Resumen_CC_PAC_003.aspx.cs" Inherits="SisConPT.SisConPT.Resumen_CC_PAC_003" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
   <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
<fieldset>
        <legend>Resumen CC-PAC-003</legend>
    

    <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
           
        
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_codpla" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
                  
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"></asp:TableCell></asp:TableRow>

   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
            <asp:Label ID="lbl_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="ctrl_lin" DataValueField="ctrl_lin" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
              <asp:TableCell Width="30">
            <asp:Label ID="lbl_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno_d" DataTextField="Ctrl_Turno" DataValueField="Ctrl_Turno" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
               <asp:TableCell Width="60">
             <asp:Button ID="Exportar_005" runat="server" Text="Exportar" Enabled="true" OnClick="Exportar_click" />
                 
               </asp:TableCell>
            
   </asp:TableRow>
  </asp:Table>
  </fieldset>



 <asp:Panel ID="Panel1" runat="server">
   
   <asp:GridView ID="gvProcesos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="Ctrl_CodProc" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Century Gothic" Font-Size="x-Small"
                            onpageindexchanging="Procesos_PageIndexChanging" 
                            onselectedindexchanging="Procesos_SelectedIndexChanging" HorizontalAlign="Center"  >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/lupa.png" 
                                            CommandName="Select"  BorderStyle="Solid" BorderWidth="0.5" 
                                            BorderColor="#999999" BackColor="White" Width="31px" 
                                            AlternateText="Seleccionar" Height="26px" ImageAlign="AbsMiddle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="Ctrl_CodProc" HeaderText="Proceso"  />
                                <asp:BoundField DataField="Inicio" HeaderText="Fecha" />
                            </Columns>
                            

                          <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#005eb7" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#90c9ff" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#cbe6ff" />
                        </asp:GridView>


   </asp:Panel>

   <asp:HiddenField ID="HiddenField1" runat="server"  />
    
    <asp:ModalPopupExtender ID="mpeEditOrder" runat="server" 
        PopupControlID="panelEditOrder" TargetControlID="HiddenField1"
         BackgroundCssClass="backgroundColor"  >
    </asp:ModalPopupExtender>
    
    <asp:Panel ID="panelEditOrder" runat="server" BackColor="White" BorderStyle="Double" ScrollBars="Auto" width="70%" Height="95%">
    
         <asp:UpdatePanel ID="upEditOrder" runat="server">
            <ContentTemplate>   
                 <div id="popupcontainer" style="width:900">
                        <fieldset>
        <legend>RESUMEN</legend>
                   
                    <asp:Table ID="Table8" runat="server" Width="700px" Height="30px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
     <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             
             <asp:TableCell Width="30">
             <asp:Label ID="Label49" runat="server" Text="PRODUCTOR : " Width="200" Height="20"></asp:Label>
             </asp:TableCell>
       
             <asp:TableCell Width="30">
             <asp:Label ID="lbl_productor" runat="server"  Width="200" Height="20"></asp:Label>
             </asp:TableCell>
       
        <asp:TableCell Width="30">
             <asp:Label ID="Label50" runat="server" Text="VARIEDAD : " Width="200" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
             <asp:Label ID="lbl_variedad" runat="server"  Width="200" Height="20"></asp:Label>
             </asp:TableCell>
             
            
            
       </asp:TableRow>
       </asp:Table>
                    
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
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_precalibre"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label1" runat="server" Text="Daños de Trips" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_trips"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label17" runat="server" Text="Adhesión" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_adhesion"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label18" runat="server" Text="Deshid. de Frutos" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_deshid_frutos"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label2" runat="server" Text="Escama" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_escama"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label3" runat="server" Text="Frutos Deformes" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_frudeformes"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>



             <asp:TableCell Width="30">
             <asp:Label ID="Label19" runat="server" Text="Deshid. Pedicelar" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_deshid_ped"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label35" runat="server" Text="Blandos" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_blandos"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
        <asp:TableCell Width="30">
             <asp:Label ID="Label20" runat="server" Text="Frutos Dobles" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_dobles"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label4" runat="server" Text="Guata Blanca" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_guatablanca"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label5" runat="server" Text="Heridas Abiertas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_heri_abiertas"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label21" runat="server" Text="Machucón" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_machucon"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
       <asp:TableCell Width="30">
             <asp:Label ID="Label22" runat="server" Text="Heridas cicatrizadas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_heri_cica"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label6" runat="server" Text="Manchas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_manchas"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label7" runat="server" Text="Partiduras cicatrizadas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_part_cica"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label23" runat="server" Text="Pitting" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pitting"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
       <asp:TableCell Width="30">
             <asp:Label ID="Label24" runat="server" Text="Media Luna" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_medluna"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label8" runat="server" Text="Piel de Lagarto" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_lagarto"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label25" runat="server" Text="Pudrición" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pudricion"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label26" runat="server" Text="Partiduras de Agua" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_part_agua"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label10" runat="server" Text="Russet" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_russet"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label11" runat="server" Text="Sutura" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sutura"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label27" runat="server" Text="Manchas Pardas" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pardas"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label28" runat="server" Text="Daño de Pajaro" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pajaro"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label12" runat="server" Text="Falto Color" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_faltocolor"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label14" runat="server" Text="Ramaleo" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_ramaleo"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label29" runat="server" Text="Desgarros" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_desgarros"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label30" runat="server" Text="Cortes de sierras" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sierras"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label15" runat="server" Text="Sin pedicelo" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_pedicelo"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

             <asp:TableCell Width="30">
            
             </asp:TableCell>
             <asp:TableCell>
                   </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label36" runat="server" Text="Sutura Expuesta" Width="70" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_sut_exp"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
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
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_defcalidad"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:Label ID="Label16" runat="server" Text="TOTAL DEFECTOS DE CONDICIÓN" Width="250" Height="20"></asp:Label>
             </asp:TableCell>
             
              <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_defcondicion"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
            
       </asp:TableRow>
       </asp:Table>


       <table width="900" border="0">
  <tr>    <td><fieldset>
        <legend>EXPORTABLE</legend>
       <asp:Table ID="Table4" runat="server" Width="266" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
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
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_pudricion"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

             </asp:TableCell>

           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_pudricion"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

             </asp:TableCell>
    </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
             <asp:TableCell Width="30">
            <center> <asp:Label ID="Label43" runat="server" Text="% Desecho < a 2%" Width="150" Height="20"></asp:Label></center>
             </asp:TableCell>
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_deshechos"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

             </asp:TableCell>
 
          <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_deshechos"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

             </asp:TableCell>
      </asp:TableRow>
              
   </asp:Table>
   </fieldset> </td>
          <td><fieldset>
        <legend>COMERCIAL</legend>
   <asp:Table ID="Table6" runat="server" Width="266" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
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
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_exportable"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
 
             </asp:TableCell>

   
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_exportable"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
 
             </asp:TableCell>

    </asp:TableRow>
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
             <asp:TableCell Width="30">
            <center> <asp:Label ID="Label48" runat="server" Text="% Desecho < a 2%" Width="150" Height="20"></asp:Label></center>
             </asp:TableCell>
           <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_qc_deshecho_com"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>

     
          <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comp_deshecho_com"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               </asp:TableCell>



             
            
       </asp:TableRow>
   



             
   </asp:Table>
   
    </fieldset> </td>
          <td><fieldset>
        <legend>DESECHO</legend>
    <asp:Table ID="Table7" runat="server" Width="266" Height="30px" Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Left">
         <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label31" runat="server" Text="N° Frutos" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_num_frutos"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
            
            
       </asp:TableRow>
       <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label52" runat="server" Text="% Exportable < 2%" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_exportable_2"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
            
            
       </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
             <asp:TableCell Width="30">
             <asp:Label ID="Label32" runat="server" Text="% Comercial < 5%" Width="150" Height="20"></asp:Label>
             </asp:TableCell>
             <asp:TableCell Width="30">
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_comercial_5"  Width="30" Height="20" Enabled="false" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              </asp:TableCell>
            
            
       </asp:TableRow>
   



             
   </asp:Table>
   </fieldset> </td>
     </tr>
</table>



   </fieldset>
                        
   <center> <asp:Button ID="btnClose" runat="server" Text="Cerrar" 
                                                CssClass="button" onclick="btnClose_Click" CausesValidation="false" /></center>
   </div>
             </ContentTemplate>
        </asp:UpdatePanel>

        
       

    </asp:Panel>





      </asp:Content>