<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen_CC_PAC_005_III_PDF.aspx.cs" Inherits="SisConPT.SisConPT.Resumen_CC_PAC_005_III_PDF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
   <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  


<fieldset>
        <legend>Resumen CC-PAC-005 Producto Terminado</legend>
    

    <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
           
        
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_codpla" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
              <asp:TableCell Width="80">
              <asp:RadioButton text="Por Proceso" id="resumen_proc" groupname="RESUMEN" runat="server" Font-Size="x-Small" />
            </asp:TableCell>
     <asp:TableCell Width="80">
              <asp:RadioButton text="General" id="resumen_gral" groupname="RESUMEN" runat="server" Font-Size="x-Small"/>
            </asp:TableCell>
                     <asp:TableCell Width="60">
                <asp:Button ID="btn_resumen" runat="server" Text="Resumen Total" Enabled="true" Width="100" OnClick="Resumen_total" ValidationGroup="ChangeUserPasswordValidationGroup"/>

    </asp:TableCell>
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"></asp:TableCell></asp:TableRow>

   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
            <asp:Label ID="lbl_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno_d" DataTextField="turcodigo" DataValueField="turcodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>

             <asp:TableCell Width="30">
            <asp:Label ID="lbl_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lincodigo" DataValueField="lincodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
                             <asp:TableCell Width="60">
             <asp:Button ID="Exportar_005" runat="server" Text="Exportar" Enabled="true"  Width="100" OnClick="Exportar_click" ValidationGroup="ChangeUserPasswordValidationGroup"/>
                 
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
             <asp:Button ID="Filtrar_fecha" runat="server" Text="  Filtrar  " Enabled="true"  Width="100" OnClick="Filtrar" ValidationGroup="ChangeUserPasswordValidationGroup" />
                 
               </asp:TableCell>
   </asp:TableRow>
   <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
   <asp:TableCell Width="30">
           
            </asp:TableCell>
            <asp:TableCell Width="60">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fechafin" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Fecha"  ValidationGroup="ChangeUserPasswordValidationGroup"/>
                
               </asp:TableCell>

             <asp:TableCell Width="30">
           
            </asp:TableCell>
            <asp:TableCell Width="60">
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fechainicio" CssClass="failureNotification" Font-Size="x-Small"  ErrorMessage="Ingrese Fecha"  ValidationGroup="ChangeUserPasswordValidationGroup"/>
             </asp:TableCell>
                          
               
            
   </asp:TableRow>


  </asp:Table>
      
  </fieldset>



 <asp:Panel ID="Panel1" runat="server">
   
   <asp:GridView ID="gvProcesos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="cptproces,cptnulote,cptmardes, lincodigo" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Century Gothic" Font-Size="Small"
                            onpageindexchanging="Procesos_PageIndexChanging" 
                            onselectedindexchanging="Procesos_SelectedIndexChanging" HorizontalAlign="Center" style="width:700px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/lupa.png" 
                                            CommandName="Select"  BorderStyle="Solid" BorderWidth="0.5" 
                                            BorderColor="#999999" BackColor="White" Width="31px" 
                                            AlternateText="Seleccionar" Height="26px" ImageAlign="AbsMiddle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="cptproces" HeaderText="Proceso" />
                                <asp:BoundField DataField="cptnulote" HeaderText="Lote" />
                                <asp:BoundField DataField="cptmardes" HeaderText="Marca" />
                                      <asp:BoundField DataField="lincodigo" HeaderText="Linea" />
                                      <asp:BoundField DataField="turcodigo" HeaderText="Turno" />

                                      
                                 <asp:BoundField DataField="promedio_final" HeaderText="Promedio Calidad" />
                                 <asp:BoundField DataField="promedio_final_condicion" HeaderText="Promedio Condición" />
                                
                            </Columns>
                        
                       <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#005eb7" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#90c9ff" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#cbe6ff" />
                        </asp:GridView>

                        <asp:GridView ID="GridTodos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="lincodigo, turcodigo" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Century Gothic" Font-Size="Small"
                            onpageindexchanging="Todos_PageIndexChanging" 
                            onselectedindexchanging="Todos_SelectedIndexChanging" HorizontalAlign="Center" style="width:500px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit_todos" runat="server" ImageUrl="~/Images/lupa.png" 
                                            CommandName="Select"  BorderStyle="Solid" BorderWidth="0.5" 
                                            BorderColor="#999999" BackColor="White" Width="31px" 
                                            AlternateText="Seleccionar" Height="26px" ImageAlign="AbsMiddle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="lincodigo" HeaderText="Linea" />
                                <asp:BoundField DataField="turcodigo" HeaderText="Turno" />
                                <asp:BoundField DataField="promedio_final" HeaderText="Promedio Calidad" />
                                <asp:BoundField DataField="promedio_final_condicion" HeaderText="Promedio Condición" />
                                
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
    
    <asp:Panel ID="panelEditOrder" runat="server" BackColor="White" BorderStyle="Double" ScrollBars="Auto" width="60%" Height="95%">
    
         <asp:UpdatePanel ID="upEditOrder" runat="server" >
            <ContentTemplate>   
                 <div id="popupcontainer" style="width:660px">
                                                   <fieldset>
        <legend>RESUMEN</legend>
        <asp:Table ID="Table2" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center"  >


                     <asp:TableRow ID="TableRow11" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                 <asp:Label ID="Label1" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Proceso : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_proceso" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                 </asp:TableCell>
            
            <asp:TableCell>
                 <asp:Label ID="Label3" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Lote : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_lote" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="Label2" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Marca : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_marca" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>

            
 </asp:TableRow> 
   <asp:TableRow ID="TableRow14" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                 <asp:Label ID="Label5" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Linea : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_linea_popup" runat="server" Width="50" Height="20"  Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                 </asp:TableCell>
            
            <asp:TableCell>
                 <asp:Label ID="Label7" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Desde : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_desde" runat="server" Width="80" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="Label9" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Hasta : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_hasta" runat="server" Width="80" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>

            
 </asp:TableRow> 
  <asp:TableRow ID="TableRow16" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                 <asp:Label ID="Label6" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Cajas : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_casos" runat="server" Width="50" Height="20"  Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                 </asp:TableCell>
            
            <asp:TableCell>
                 <asp:Label ID="Label11" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Promedio Calidad : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_calidad" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="Label14" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Promedio Condición : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_condicion" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>

            
 </asp:TableRow> 
 </asp:Table>
         <fieldset>

        <legend>DEFECTOS</legend>
                   
                    
                    <asp:Table ID="Table1" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center"  >


                    
    
    
<asp:TableRow ID="TableRow12" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
            <asp:Label ID="Label4_1" runat="server" Text="DEFECTOS DE CALIDAD" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               <asp:Label ID="Label4" runat="server" Text="DEFECTOS DE CONDICIÓN" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
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
                <asp:Label ID="lblprecalibre" runat="server" Height="10">Pre Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtprecalibre"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblrusset" runat="server" Height="10">Russet</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtrusset"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbladhesion" runat="server" Height="10">Adhesion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtadhesion"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpudricion" runat="server" Height="10">Pudricion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpudricion"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lbldanotrip" runat="server" Height="10">Daño Trip</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanotrip"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsutura" runat="server" Height="10">Sutura</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsutura"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
             
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshid" runat="server" Height="10">Deshidratacion de Frutos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshid"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmanchaspardas" runat="server" Height="10">Manchas Pardas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchaspardas"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

            </asp:TableCell>
 </asp:TableRow>


          <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblescama" runat="server" Height="10">Escama</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtescama"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfaltocolor" runat="server" Height="10">Falto de Color</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfaltocolor"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshidpedi" runat="server" Height="10">Deshidratacion Pedicelar</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshidpedi"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanopajaro" runat="server" Height="10">Daño de Pajaro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanopajaro"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow4" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblfrutosdeformes" runat="server" Height="10">Frutos Deformes</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdeformes"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblramaleo" runat="server" Height="10">Ramaleo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtramaleo"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblblandos" runat="server" Height="10">Blandos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtblandos"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldesgarro" runat="server" Height="10">Desgarro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdesgarro"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
         
            <asp:TableCell>
                <asp:Label ID="lblfrutosdobles" runat="server" Height="10">Frutos Dobles</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdobles"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsinpedicelo" runat="server" Height="10">Sin Pedicelo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsinpedicelo"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblheridasabiertas" runat="server" Height="10">Heridas Abiertas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtheridasabiertas"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblcortesierra" runat="server" Height="10">Corte de Sierra</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcortesierra"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
               
            </asp:TableCell>
 </asp:TableRow>

          <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblguatablanca" runat="server" Height="10">Guata Blanca</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtguatablanca"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
         
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmachucon" runat="server" Height="10">Machucon</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmachucon"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label13" runat="server" Height="10">Sutura Expuesta</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_sut_exp"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
             
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblherida" runat="server" Height="10">Herida</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtherida"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduras" runat="server" Height="10">Partiduras</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduras"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
            
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow8" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblmanchas" runat="server" Height="10">Manchas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchas"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartidurasagua" runat="server" Height="10">Partiduras por Agua</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartidurasagua"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblmedialuna" runat="server" Height="10">Media Luna</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmedialuna"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduracicatrizada" runat="server" Height="10">Partidura Cicatrizada</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduracicatrizada"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>

            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow10" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblpiellagarto" runat="server" Height="10">Piel de Lagarto</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpiellagarto"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
        
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpitting" runat="server" Height="10">Pitting</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpitting"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
            
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>

                 </asp:Table>



                    </fieldset>
                    <fieldset>
        <legend>SOLIDOS SOLUBLES</legend>

          <asp:GridView ID="gv_solubles_datos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="codcaja" BackColor="White" Font-Names="Century Gothic" Font-Size="Small"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" Width="400px">
                            <Columns>
                               
                                <asp:BoundField DataField="codcaja" HeaderText="Caja"  />
                                <asp:BoundField DataField="calibresoluble" HeaderText="Calibre"  />
                                <asp:BoundField DataField="f1" HeaderText="F 1" />
                                <asp:BoundField DataField="f2" HeaderText="F 2" />
                                <asp:BoundField DataField="f3" HeaderText="F 3" />
                                <asp:BoundField DataField="f4" HeaderText="F 4" />
                                <asp:BoundField DataField="f5" HeaderText="F 5" />
                                <asp:BoundField DataField="promedio" HeaderText="Promedio" />
                      </Columns>
                        
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#005eb7" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#007cf2" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#90c9ff" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#cbe6ff" />
                        </asp:GridView>

        </fieldset>


        <center> <asp:Button ID="btnClose" runat="server" Text="Cerrar" 
                                                CssClass="button" onclick="btnClose_Click" CausesValidation="false" />
                                                <asp:Button ID="boton" runat="server" Text="pdf" Enabled="true" OnClick="boton_Click" />
                                                </center>
                </fieldset>
                 </div>
             </ContentTemplate> 
               <Triggers>  <asp:PostBackTrigger ControlID="boton" /> </Triggers> 
        </asp:UpdatePanel>

        
       

    </asp:Panel>

       <asp:HiddenField ID="HiddenField2" runat="server"  />
    
    <asp:ModalPopupExtender ID="mpeEditOrder_todos" runat="server" 
        PopupControlID="panelEditOrder_todos" TargetControlID="HiddenField2"
         BackgroundCssClass="backgroundColor"  >
    </asp:ModalPopupExtender>
    
    <asp:Panel ID="panelEditOrder_todos" runat="server" BackColor="White" BorderStyle="Double" ScrollBars="Auto" width="60%" Height="95%">
    
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>   
                 <div id="Div1" style="width:660px">
                                                   <fieldset>
        <legend>RESUMEN</legend>
        <asp:Table ID="Table3" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center"  >


   <asp:TableRow ID="TableRow15" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
           
            
            <asp:TableCell>
                 <asp:Label ID="Label22" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Desde : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_desde_t" runat="server" Width="80" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="Label24" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Hasta : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_hasta_t" runat="server" Width="80" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                      <asp:TableCell>
                 <asp:Label ID="Label26" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Cajas : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_cajas_t" runat="server" Width="50" Height="20"  Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                 </asp:TableCell>
            
 </asp:TableRow> 
  <asp:TableRow ID="TableRow17" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            
            <asp:TableCell>
                 <asp:Label ID="Label28" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Promedio Calidad : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_calidad_t" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="Label30" runat="server" Height="20" Font-Bold="true" Font-Size="Small">Promedio Condición : </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_condicion_t" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>

            
 </asp:TableRow> 
 <asp:TableRow ID="TableRow13" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            
            <asp:TableCell>
                 <asp:Label ID="lbl_tit_turno" runat="server" Height="20" Font-Bold="true" Font-Size="Small"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_turno_t" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>
                        <asp:TableCell>
                 <asp:Label ID="lbl_tit_linea" runat="server" Height="20" Font-Bold="true" Font-Size="Small"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
             <asp:Label ID="lbl_linea_t" runat="server" Width="50" Height="20" Font-Size="Small" Font-Names="Century Gothic"></asp:Label>
                    </asp:TableCell>

            
 </asp:TableRow> 
 </asp:Table>
         <fieldset>

        <legend>DEFECTOS</legend>
                   
                    
                    <asp:Table ID="Table4" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center"  >

<asp:TableRow ID="TableRow18" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
            <asp:Label ID="Label32" runat="server" Text="DEFECTOS DE CALIDAD" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               <asp:Label ID="Label33" runat="server" Text="DEFECTOS DE CONDICIÓN" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
              
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
 </asp:TableRow>
         
         
          <asp:TableRow ID="TableRow19" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="Label34" runat="server" Height="10">Pre Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3" runat="server" ID="txt_precalibre_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label35" runat="server" Height="10">Russet</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_russet_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label36" runat="server" Height="10">Adhesion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_adhesion_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label37" runat="server" Height="10">Pudricion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_pudricion_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow20" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="Label38" runat="server" Height="10">Daño Trip</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_trip_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label39" runat="server" Height="10">Sutura</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_sutura_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
             
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label40" runat="server" Height="10">Deshidratacion de Frutos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_deshidfru_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label41" runat="server" Height="10">Manchas Pardas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_manchaspardas_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>

            </asp:TableCell>
 </asp:TableRow>


          <asp:TableRow ID="TableRow21" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="Label42" runat="server" Height="10">Escama</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtescama_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfaltocolor_t" runat="server" Height="10">Falto de Color</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfaltocolor_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
          
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshidpedi_t" runat="server" Height="10">Deshidratacion Pedicelar</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshidpedi_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanopajaro_t" runat="server" Height="10">Daño de Pajaro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanopajaro_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic">0</asp:TextBox>
              
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow4_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblfrutosdeformes_t" runat="server" Height="10">Frutos Deformes</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdeformes_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>

            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblramaleo_t" runat="server" Height="10">Ramaleo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtramaleo_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblblandos_t" runat="server" Height="10">Blandos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtblandos_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldesgarro_t" runat="server" Height="10">Desgarro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdesgarro_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>

            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow5_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
         
            <asp:TableCell>
                <asp:Label ID="lblfrutosdobles_t" runat="server" Height="10">Frutos Dobles</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdobles_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
              
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsinpedicelo_t" runat="server" Height="10">Sin Pedicelo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsinpedicelo_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblheridasabiertas_t" runat="server" Height="10">Heridas Abiertas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtheridasabiertas_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblcortesierra_t" runat="server" Height="10">Corte de Sierra</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcortesierra_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
               
            </asp:TableCell>
 </asp:TableRow>

          <asp:TableRow ID="TableRow6_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblguatablanca_t" runat="server" Height="10">Guata Blanca</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtguatablanca_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
         
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmachucon_t" runat="server" Height="10">Machucon</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmachucon_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label13_t" runat="server" Height="10">Sutura Expuesta</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_sut_exp_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
             
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow7_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblherida_t" runat="server" Height="10">Herida</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtherida_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduras_t" runat="server" Height="10">Partiduras</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduras_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow8_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblmanchas_t" runat="server" Height="10">Manchas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchas_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartidurasagua_t" runat="server" Height="10">Partiduras por Agua</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartidurasagua_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
    
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow9_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
           
            <asp:TableCell>
                <asp:Label ID="lblmedialuna_t" runat="server" Height="10">Media Luna</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmedialuna_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
           
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpartiduracicatrizada_t" runat="server" Height="10">Partidura Cicatrizada</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduracicatrizada_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>

            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow10_t" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="lblpiellagarto_t" runat="server" Height="10">Piel de Lagarto</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpiellagarto_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
        
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpitting_t" runat="server" Height="10">Pitting</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpitting_t"  Width="30" Height="20" Enabled="False" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>

                 </asp:Table>



                    </fieldset>
            


        <center> <asp:Button ID="btnClose_todos" runat="server" Text="Cerrar" 
                                                CssClass="button" onclick="btnClose_Click" CausesValidation="false" />
                                                 <asp:Button ID="boton_2" runat="server" Text="pdf" Enabled="true" OnClick="boton_Click" />
                                                </center>
                </fieldset>
                 </div>
             </ContentTemplate> 
               <Triggers>  <asp:PostBackTrigger ControlID="boton" /> </Triggers> 
                <Triggers>  <asp:PostBackTrigger ControlID="boton_2" /> </Triggers> 
        </asp:UpdatePanel>

        
       

    </asp:Panel>



      </asp:Content>