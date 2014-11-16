<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta_CC-PAC-075_proceso.aspx.cs" Inherits="SisConPT.SisConPT.Consulta_CC_PAC_075_proceso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
   <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">  </asp:ToolkitScriptManager>  
<fieldset>
        <legend>CC-PAC-075</legend>
 <asp:Panel ID="Panel1" runat="server">
   <asp:Table ID="Datos" runat="server" Width="653px" Height="50px" Font-Names="Century Gothic" Font-Size="Small" HorizontalAlign="Center">
          <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="30">
            <asp:TableCell Width="30">
                <asp:Label ID="lbl_cod_proc" runat="server" Text="Código Proceso" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
              <asp:DropDownList ID="drop_proc_d"  runat="server" DataSourceID="drop_porc" DataTextField="Ctrl_CodProc" DataValueField="Ctrl_CodProc" Height="30px" Width="80" Font-Names="Century Gothic"  AutoPostBack="True" onselectedindexchanged="proc_SelectedIndexChanged">
        </asp:DropDownList> </asp:TableCell>
        
              <asp:TableCell Width="20">
                <asp:Label ID="lbl_cod_plan" runat="server" Text="Código Planta" Width="70" Height="30"></asp:Label>
            </asp:TableCell>
     <asp:TableCell Width="60">
                <asp:TextBox ID="txt_cod_plan" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="27px"></asp:TextBox>    
            </asp:TableCell>
             
                  
   </asp:TableRow>
    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">  <asp:TableCell Width="60"><asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="button"
                    onclick="btnFiltrar_Click" Enabled="false" /></asp:TableCell>
    
    
    
    </asp:TableRow>

  
  </asp:Table>
   </asp:Panel></fieldset>
    <asp:Table ID="Table1" runat="server" Width="653px" Height="30px" 
        Font-Names="Century Gothic" Font-Size="X-Small" HorizontalAlign="Center" > <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
                    
                    <asp:TableCell Width="30">
   <asp:UpdatePanel ID="upProducts" runat="server">
                    
<Triggers>
                        
<asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
                    
</Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="gvProcesos" runat="server" CellPadding="3" ForeColor="Black" 
                            GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
                            DataKeyNames="Ctrl_id" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                            onpageindexchanging="Procesos_PageIndexChanging" 
                            onselectedindexchanging="Procesos_SelectedIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="" 
                                            CommandName="Select"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="Ctrl_CodProc" HeaderText="Proceso" DataFormatString="{0:d}"  />
                              <asp:BoundField DataField="Ctrl_CodPlan" HeaderText="Planta" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="Ctrl_Lin" HeaderText="Linea" />
                                <asp:BoundField DataField="Ctrl_Usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="Ctrl_Turno" HeaderText="Turno" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="gray" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                        </asp:GridView>
                    
</ContentTemplate>
                 
</asp:UpdatePanel>
</asp:TableCell>
                    </asp:TableRow></asp:Table>

                 <asp:HiddenField ID="HiddenField1" runat="server" />
    
    <asp:ModalPopupExtender ID="mpeEditOrder" runat="server" 
        PopupControlID="panelEditOrder" TargetControlID="HiddenField1"
         BackgroundCssClass="backgroundColor" >
    </asp:ModalPopupExtender>
    
    <asp:Panel ID="panelEditOrder" runat="server" BackColor="White">
    
         <asp:UpdatePanel ID="upEditOrder" runat="server">
            <ContentTemplate>   
                 <div id="popupcontainer" style="width:450px">
                    
                    
                    <asp:Table ID="Table2" runat="server" Width="653px" Height="30px" 
                         Font-Names="Century Gothic" Font-Size="x-Small" HorizontalAlign="Center" 
                         BorderStyle="Solid" BorderWidth="1px" >
                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
                    
                    <asp:TableCell Width="30">
             <asp:Label ID="lblRango" runat="server" Text="Proceso" Width="40" Height="20"></asp:Label>
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:TextBox ID="txtProceso" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="50"></asp:TextBox>
             </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
                    
                    <asp:TableCell Width="30">
             <asp:Label ID="Label1" runat="server" Text="Lote" Width="40" Height="20"></asp:Label>
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:TextBox ID="txtLote" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="50"></asp:TextBox>
             </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
                    
                    <asp:TableCell Width="30">
             <asp:Label ID="Label2" runat="server" Text="% Exportable Descarte" Width="40" Height="20"></asp:Label>
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:TextBox ID="txtDescarte" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="50"></asp:TextBox>
             </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
                    
                    <asp:TableCell Width="30">
             <asp:Label ID="Label3" runat="server" Text="% Exportable CAT II" Width="40" Height="20"></asp:Label>
             </asp:TableCell>

             <asp:TableCell Width="30">
             <asp:TextBox ID="txtCATII" runat="server" Height="25px" Font-Names="Century Gothic" Font-Size="Small" Enabled="False" ReadOnly="True" Width="50"></asp:TextBox>
             </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20" >  <asp:TableCell Width="30">
                    <asp:Button ID="btnClose" runat="server" Text="Cerrar" 
                                                CssClass="button" onclick="btnClose_Click" CausesValidation="false" />
                                                         </asp:TableCell></asp:TableRow>

                    
                    </asp:Table>



                    
                 </div>
             </ContentTemplate>
        </asp:UpdatePanel>

        
       

    </asp:Panel>

   </asp:Content>