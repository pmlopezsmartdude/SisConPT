<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso-CC-PAC-005-CODCAJ.aspx.cs" Inherits="SisConPT.SisConPT.Ingreso_CC_PAC_005_CODCAJ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
        <script type="text/javascript">
            function doClick(buttonName, e) {//the purpose of this function is to allow the enter key to point to the correct button to click.
                var key;

                if (window.event)
                    key = window.event.keyCode;     //IE
                else
                    key = e.which;     //firefox

                if (key == 13) {
                    //Get the button the user wants to have clicked
                    var btn = document.getElementById(buttonName);
                    if (btn != null) { //If we find the button click it
                        btn.click();
                        event.keyCode = 0
                    }
                }

            }
    </script>
  
    <h3>CC-PAC-005</h3>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLoadData">
    <asp:Label ID="Label1" runat="server" Text="Código Caja" Height="20px" Font-Names="Century Gothic" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="CodCaja" runat="server" Height="25" Font-Names="Century Gothic" Font-Size="Small"></asp:TextBox>
     
    <asp:Button ID="btnLoadData"  runat="server"  style="display: none" /><br />
    <br />
    </asp:Panel>
    <asp:Table ID="UnitecDatos" runat="server" Width="653px" Height="90px" Font-Names="Century Gothic" Font-Size="X-Small">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell Width="30">
                <asp:Label ID="Label2" runat="server" Text="Turno" Width="50" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                <asp:TextBox ID="Turno" runat="server" ReadOnly="True" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label7" runat="server" Text="Especie" width="30" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="10">
                <asp:TextBox ID="especieid" runat="server" ReadOnly="True" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="especietext" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">

            <asp:TableCell>
                <asp:Label ID="Label4" runat="server" Text="Linea" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="60">
                <asp:TextBox ID="Linea" runat="server" ReadOnly="True" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label5" runat="server" Text="Variedad" width="30" Height="20"></asp:Label>
            </asp:TableCell>
            <asp:TableCell >
                <asp:TextBox ID="Variedad" runat="server" ReadOnly="True" width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="VariedadText" runat="server" ReadOnly="True" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
            <asp:TableCell>
                <asp:Label runat="server">Proceso</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Textbox ID="NroProceso" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:Textbox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Marca</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Marca" runat="server" ReadOnly="true" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="MarcaTxt" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Lote</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Lote" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Embalaje</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Embalaje" runat="server" ReadOnly="true" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Embalajetx" runat="server" ReadOnly="true" Width="100" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Peso</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Peso" runat="server" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server">Envase</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Envase" runat="server" ReadOnly="true" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="Envasetxt" runat="server" ReadOnly="true" Width="130" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server">Calibre</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="Calibre" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Prod. Real</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdReal" ReadOnly="true" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdRealtxt" ReadOnly="true" Width="100" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" Height="20">
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Salida</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="Salida" ReadOnly="true" Width="50" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" Height="10">Prod. Etiquetado</asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdEtiq" ReadOnly="true" Width="30" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="ProdEtiqtxt" ReadOnly="true" Width="100" Height="20" Enabled="False"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

 
</asp:Content>
