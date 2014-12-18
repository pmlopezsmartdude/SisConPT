<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumen_CC_PAC_005_II.aspx.cs" Inherits="SisConPT.SisConPT.Resumen_CC_PAC_005_II" %>

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
    <asp:Button ID="Filtrar_fecha" runat="server" Text="  Filtrar  " Enabled="true" OnClick="Filtrar" />

    </asp:TableCell>
   </asp:TableRow>
  </asp:Table>
        <asp:RoundedCornersExtender ID="Datos_RoundedCornersExtender" runat="server" 
            Enabled="True" TargetControlID="Datos">
        </asp:RoundedCornersExtender>
  </fieldset>



 <asp:Panel ID="Panel1" runat="server">
   
   <asp:GridView ID="gvProcesos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="cptproces,cptnulote,cptdestino" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Century Gothic" Font-Size="Small"
                            onpageindexchanging="Procesos_PageIndexChanging" 
                            onselectedindexchanging="Procesos_SelectedIndexChanging" HorizontalAlign="Center" style="width:500px">
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
                                <asp:BoundField DataField="cptdestino" HeaderText="Destino" />
                                <asp:BoundField DataField="cptvardes" HeaderText="Variedad" />

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
    
    <asp:Panel ID="panelEditOrder" runat="server" BackColor="White" BorderStyle=Double ScrollBars=Auto width=60% Height=95%>
    
         <asp:UpdatePanel ID="upEditOrder" runat="server" >
            <ContentTemplate>   
                 <div id="popupcontainer" style="width:800px">
                                                   <fieldset>
        <legend>RESUMEN</legend>
         <fieldset>
        <legend>DEFECTOS</legend>
                   
                    
                    <asp:Table ID="Table2" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center"  >


                    
    
    
<asp:TableRow ID="TableRow12" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
            <asp:Label ID="Label4" runat="server" Text="DEFECTOS DE CALIDAD" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
            <asp:TableCell>
               <asp:Label ID="Label9" runat="server" Text="DEFECTOS DE CONDICIÓN" Height="30" Font-Size="X-Small" Font-Names="Century Gothic"></asp:Label>
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
                            HorizontalAlign="Center" style="width:500px">
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
                                                CssClass="button" onclick="btnClose_Click" CausesValidation="false" /></center>
                </fieldset>
                 </div>
             </ContentTemplate>
        </asp:UpdatePanel>

        
       

    </asp:Panel>





      </asp:Content>