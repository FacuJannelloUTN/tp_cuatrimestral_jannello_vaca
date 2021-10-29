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
          <form class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
              <div class="form-outline mb-4">
                <input type="text" id="usuario-input" class="form-control form-control-md"
                  placeholder="Ingrese el nombre de usuario" />
                <label class="form-label" for="usuario-input">Nombre de usuario</label>
              </div>
              <div class="form-outline mb-3">
                <input type="password" id="contrasena-input" class="form-control form-control-md"
                  placeholder="Contraseña" />
                <label class="form-label" for="contrasena-input">Contraseña</label>
              </div>

              <div class="text-center text-lg-start mt-4 pt-2">
                <button type="button" class="btn btn-primary btn-md"
                  style="padding-left: 2.5rem; padding-right: 2.5rem;">Login</button>
                <span class="small fw-bold mt-2 pt-1 mb-0">¿No tenés usuario? <a href="#!"
                    class="link-danger">Registrarse</a></span>
              </div>
            </form>
        </div>
      </div>
  </div>
</section>
</asp:Content>
