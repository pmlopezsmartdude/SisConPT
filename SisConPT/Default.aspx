<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SisConPT._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <img alt="" src="Images/logosfg.png" />
    <h2>
        Bienvenido al sistema de control de producto terminado</h2>
    
        <h3>Operación del sistema:</h3>
    <ol class="round">
        <li class="one">
            <h5>Ingresar al sistema</h5>
            Al ingresar al sistema debera utilizar su cuenta y no debe olvidar seleccionar la planta con la cual operará.
            La selección incorrecta de planta no le permitirá encontrar la identificación correcta del producto al cual
            Usted sumistrará los datos de las planillas de control.
        </li>
        <li class="two">
            <h5>Selección del producto al cual Usted suministrará los datos</h5>
            El sistema está diseñado para seleccionar el producto mediante su código de barra,
            por lo tanto, para iniciar el registro, primero deberá selecciónar el producto escaneando
            su código de barra desde la etiqueta incorporada en el.
        </li>
        <li class="three">
            <h5>Que hacer en caso de no encontrar el producto?</h5>
            Favor tome contacto con el Area de informática y solicite instrucciones para continuar, esto se puede
            deber a que no se ha volcado la información del proceso desde Lotmanager al sistema.
        </li>
        <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
            <AnonymousTemplate>
                <li class="four">
                    <h5>Acceso a las aplicaciones de Control de Producto Terminado</h5>
                    El acceso a las aplicaciones de control de producto terminado esta solo permitido para usuarios autenticados
                    Por favor ingrese con su cuenta de usuario para permitirle el acceso.
                </li>

            </AnonymousTemplate>
            <LoggedInTemplate>
                <li class="four">
                    <h5>Acceso a las aplicaciones de Control de Producto Terminado</h5>
                    <a id="A1" runat="server" href="~/SisConPT/SisConPT.aspx">Aplicaciones de sistema de control de producto terminado.</a>
                </li>
                <li class="five">
                    <h5>Administre su contraseña</h5>
                    Usted se encuentra autenticado, si desea cambiar su contraseña puede hacerlo desde el siguiente link
                    <a id="Chpass" runat="server" href="~/Account/ChangePassword.aspx">Administre su contraseña</a>
                </li>
            </LoggedInTemplate>
        </asp:LoginView>
    </ol>
  
</asp:Content>
