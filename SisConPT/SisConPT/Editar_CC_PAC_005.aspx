<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar_CC_PAC_005.aspx.cs" Inherits="SisConPT.SisConPT.Editar_CC_PAC_005" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  


<fieldset>
        <legend>Modificar CC-PAC-005</legend>
    

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
            <asp:Label ID="label_linea" runat="server" Text="Línea" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                 <asp:DropDownList ID="drop_linea_d"  runat="server" DataSourceID="drop_linea" DataTextField="lincodigo" DataValueField="lincodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="linea_SelectedIndexChanged">
        </asp:DropDownList>
             </asp:TableCell>
              <asp:TableCell Width="30">
            <asp:Label ID="label_turno" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
             
                 <asp:DropDownList ID="drop_turno_d"  runat="server" DataSourceID="drop_turno_d" DataTextField="turcodigo" DataValueField="turcodigo" Height="30px" Width="80" Font-Names="Century Gothic" AutoPostBack="True"  onselectedindexchanged="turno_SelectedIndexChanged" >
        </asp:DropDownList>  
               </asp:TableCell>
               <asp:TableCell Width="60">


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

           <asp:GridView ID="gvProcesos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="cptnumero" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Font-Names="Century Gothic" Font-Size="Small"
                            onpageindexchanging="Procesos_PageIndexChanging" 
                            onselectedindexchanging="Procesos_SelectedIndexChanging" HorizontalAlign="Center" style="width:800px">



                            <Columns>
                            <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/lupa.png" 
                                            CommandName="Select"  BorderStyle="Solid" BorderWidth="0.5" 
                                            BorderColor="#999999" BackColor="White" Width="31px" 
                                            AlternateText="Seleccionar" Height="26px" ImageAlign="AbsMiddle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
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


     <asp:HiddenField ID="HiddenField1" runat="server"  />
    
    <asp:ModalPopupExtender ID="mpeEditOrder" runat="server" 
        PopupControlID="panelEditOrder" TargetControlID="HiddenField1"
         BackgroundCssClass="backgroundColor"  >
    </asp:ModalPopupExtender>
    
    <asp:Panel ID="panelEditOrder" runat="server" BackColor="White" BorderStyle="Double" ScrollBars=Auto width=60% Height=95%>
    
         <asp:UpdatePanel ID="upEditOrder" runat="server">
            <ContentTemplate>   
                 <div id="popupcontainer" style="width:930px">

                 <fieldset>
        <legend>EDITAR</legend>
                   <asp:Table ID="Table3" runat="server" Width="800px" Height="50px" 
                Font-Names="Century Gothic" Font-Size="X-Small" >
                          <asp:TableRow ID="TableRow11" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Height="20">Caja</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
           <asp:Label ID="Label2" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="lbl_caja" runat="server" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
           <asp:TableCell>
                <asp:Label ID="Label3" runat="server" Height="20">Proceso</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
           <asp:Label ID="Label4" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="lbl_proceso" runat="server" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbl_cptnumero" runat="server" Height="20" Visible="false"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
              
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow13" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="Label5" runat="server" Height="20">Línea</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
           <asp:Label ID="Label6" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="lbl_linea" runat="server" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
           <asp:TableCell>
                <asp:Label ID="Label13" runat="server" Height="20">Turno</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
           <asp:Label ID="Label14" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                 <asp:Label ID="lbl_turno" runat="server" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
              
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
 </asp:TableRow>
   <asp:TableRow ID="TableRow19" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="25">
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
           <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
              
            </asp:TableCell>
            <asp:TableCell>
               
            </asp:TableCell>
 </asp:TableRow>
                
                
                </asp:Table>

                <asp:Table ID="Table4" runat="server" Width="800px" Height="50px" 
                Font-Names="Century Gothic" Font-Size="X-Small" HorizontalAlign="Center" >
                          <asp:TableRow ID="TableRow17" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell Width="50">
                <asp:Label ID="Label19" runat="server" Height="20" >Destino</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label24" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="150">
           <asp:TextBox   runat="server" ID="txt_destino"  Width="150" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Width="100">
                <asp:Label ID="Label20" runat="server" Height="20">Cajas Vaciadas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label23" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="100">
                 <asp:TextBox  MaxLength="3"    runat="server" ID="txt_cajasvaciadas"  Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender39" TargetControlID="txt_cajasvaciadas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
           <asp:TableCell Width="100">
                <asp:Label ID="Label21" runat="server" Height="20">Peso Neto</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label22" runat="server" Height="20">:</asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="100">
       <asp:TextBox runat="server" ID="txt_peso_neto"  Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender40" TargetControlID="txt_peso_neto" FilterType="numbers"  runat="server" />
            </asp:TableCell>
        
 </asp:TableRow>

                
                
                </asp:Table>
                      <fieldset>
        <legend>DEFECTOS</legend>
               <asp:Table ID="ingresoDatos" runat="server" Width="800px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" >

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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtbajo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtbajo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblprecalibre" runat="server" Height="10">Pre Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtprecalibre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtprecalibre" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblrusset" runat="server" Height="10">Russet</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtrusset"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtrusset" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbladhesion" runat="server" Height="10">Adhesion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtadhesion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtadhesion" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblpudricion" runat="server" Height="10">Pudricion</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpudricion"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtpudricion" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow2" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblcalibreok" runat="server" Height="10">Calibre OK</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcalibreok"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtcalibreok" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanotrip" runat="server" Height="10">Daño Trip</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanotrip"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" TargetControlID="txtdanotrip" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsutura" runat="server" Height="10">Sutura</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsutura"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" TargetControlID="txtsutura" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshid" runat="server" Height="10">Deshidratacion de Frutos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshid"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtdeshid" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmanchaspardas" runat="server" Height="10">Manchas Pardas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchaspardas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" TargetControlID="txtmanchaspardas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow3" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label ID="lblsobre" runat="server" Height="10">Sobre (<20 %)</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsobre"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtsobre" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblescama" runat="server" Height="10">Escama</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtescama"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" TargetControlID="txtescama" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblfaltocolor" runat="server" Height="10">Falto de Color</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfaltocolor"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" TargetControlID="txtfaltocolor" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldeshidpedi" runat="server" Height="10">Deshidratacion Pedicelar</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdeshidpedi"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" TargetControlID="txtdeshidpedi" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldanopajaro" runat="server" Height="10">Daño de Pajaro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdanopajaro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdeformes"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" TargetControlID="txtfrutosdeformes" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblramaleo" runat="server" Height="10">Ramaleo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtramaleo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" TargetControlID="txtramaleo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblblandos" runat="server" Height="10">Blandos</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtblandos"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" TargetControlID="txtblandos" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbldesgarro" runat="server" Height="10">Desgarro</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtdesgarro"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtfrutosdobles"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" TargetControlID="txtfrutosdobles" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblsinpedicelo" runat="server" Height="10">Sin Pedicelo</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtsinpedicelo"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" TargetControlID="txtsinpedicelo" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblheridasabiertas" runat="server" Height="10">Heridas Abiertas</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtheridasabiertas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" TargetControlID="txtheridasabiertas" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblcortesierra" runat="server" Height="10">Corte de Sierra</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtcortesierra"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtguatablanca"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmachucon"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" TargetControlID="txtmachucon" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label25" runat="server" Height="10">Sutura Expuesta</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txt_sut_exp"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" TargetControlID="txt_sut_exp" FilterType="numbers"  runat="server" />
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtherida"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduras"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmanchas"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartidurasagua"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" TargetControlID="txtpartidurasagua" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>
          <asp:TableRow ID="TableRow9" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
        
	    </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblmedialuna" runat="server" Height="10">Media Luna</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtmedialuna"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpartiduracicatrizada"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpiellagarto"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
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
                <asp:TextBox  MaxLength="3"    runat="server" ID="txtpitting"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" TargetControlID="txtpitting" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
 </asp:TableRow>

             </asp:Table>
             </fieldset>
             


                    <table width="880" border="0">
  <tr>
    <td><fieldset>
        <legend>CALIBRE : <asp:Label ID="lbl_calibre" runat="server"  Font-Names="Century Gothic" Font-Bold="true"></asp:Label></legend>
                            <asp:Table ID="Table1" runat="server" Width="400px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" >

                          <asp:TableRow ID="TableRow14" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <asp:Label ID="Label7" runat="server" Font-Size="Small" Font-Names="Century Gothic" Font-Bold="true">F 1</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label15" runat="server" Font-Size="Small" Font-Names="Century Gothic" Font-Bold="true">F 2</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label16" runat="server" Font-Size="Small" Font-Names="Century Gothic" Font-Bold="true">F 3</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label17" runat="server" Font-Size="Small" Font-Names="Century Gothic" Font-Bold="true">F 4</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label18" runat="server" Font-Size="Small" Font-Names="Century Gothic" Font-Bold="true">F 5</asp:Label>
            </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow ID="TableRow15" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                 <asp:TextBox  MaxLength="3" runat="server" ID="txt_f1"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender34" TargetControlID="txt_f1" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox  MaxLength="3" runat="server" ID="txt_f2"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender35" TargetControlID="txt_f2" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox  MaxLength="3" runat="server" ID="txt_f3"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender36" TargetControlID="txt_f3" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox  MaxLength="3" runat="server" ID="txt_f4"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender37" TargetControlID="txt_f4" FilterType="numbers"  runat="server" />
            </asp:TableCell>
            <asp:TableCell>
                 <asp:TextBox  MaxLength="3" runat="server" ID="txt_f5"  Width="30" Height="20" Enabled="true" Font-Size="X-Small" Font-Names="Century Gothic"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender38" TargetControlID="txt_f5" FilterType="numbers"  runat="server" />
            </asp:TableCell>
 </asp:TableRow>

                    </asp:Table>
                    </fieldset></td>
    <td><fieldset>
        <legend>OBSERVACIONES</legend>
                            <asp:Table ID="Table2" runat="server" Width="400px" Height="90px" 
                Font-Names="Century Gothic" Font-Size="X-Small" >

                          <asp:TableRow ID="TableRow16" runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            
            <asp:TableCell>
                <center><asp:TextBox ID="TextBox1obs" runat="server" Height="75" Width="380" Font-Size="X-Small" Font-Names="Century Gothic" TextMode="MultiLine">0</asp:TextBox></center>
            </asp:TableCell>
           
 </asp:TableRow>
  

                    </asp:Table>
                    </fieldset></td>
  </tr>
</table> <center> 
<table width="240" border="0">
  <tr>
    <td width="120"><asp:Button ID="btn_guardar" runat="server" Text="Guardar Cambios"  CssClass="button" onclick="btnGuarda_Click" width="120" /></td>
    <td width="12">&nbsp;</td>
    <td width="120"><asp:Button ID="btnClose" runat="server" Text="Cerrar" CssClass="button" onclick="btnClose_Click" CausesValidation="false" width="120" /></td>
  </tr>
</table>



                                        
                                        </center>

                    </fieldset>

                 </div>
             </ContentTemplate>
        </asp:UpdatePanel>

        
       

    </asp:Panel>



</asp:Content>
