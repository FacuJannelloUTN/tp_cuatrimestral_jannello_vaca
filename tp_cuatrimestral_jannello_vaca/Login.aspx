<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <h2 class="text-center">Acceso al portal de empleados</h2>
 <section>
  <div>
    <div class="row d-flex justify-content-center align-items-center">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://thumbs.dreamstime.com/b/design-can-be-used-as-logo-icon-as-complement-to-design-gear-computer-logo-icon-design-125299183.jpg" class="img-fluid login-img"
          alt="Logo computadora">
      </div>
      <div>
              <div class="form-outline mb-4">
                <label class="form-label" for="usuario-input">Email</label>
                  <asp:TextBox TextMode="Email" ID="mail" CssClass="form-control form-control-md" placeholder="Ingrese email" OnTextChanged="OnFocusCamposVacios" runat="server" />    
              </div>
              <div class="form-outline mb-3">
                <label class="form-label" for="contrasena-input">Contraseña</label>
                  <asp:TextBox TextMode="Password" ID="contrasena" CssClass="form-control form-control-md" placeholder="Ingrese contraseña" AutoPostBack="false" OnTextChanged="OnFocusCamposVacios" runat="server" />    
              </div>
              <div class="text-center text-lg-start mt-4 pt-2">
                  <asp:Button Text="Login" ID="login"  runat="server" CssClass="btn btn-primary btn-md" OnClick="ingreso"/>
                <span class="small fw-bold mt-2 pt-1 mb-0">¿No tenés usuario? <a href="#!"
                    class="link-danger">Registrarse</a></span>
              </div>
        </div>
      </div>
  </div>
</section>
</asp:Content>
