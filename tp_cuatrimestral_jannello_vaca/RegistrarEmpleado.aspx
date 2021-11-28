<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEmpleado.aspx.cs" Inherits="tp_cuatrimestral_jannello_vaca.RegistrarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2 class="text-center">Registrar un nuevo empleado</h2>
 <section>
  <div>
    <div class="row d-flex justify-content-center align-items-center">
      <div>
              <div class="form-outline mb-3">
                <label class="form-label" for="contrasena-input">Nombre de usuario</label>
                  <asp:TextBox  ID="TextBoxNombre" CssClass="form-control form-control-md" placeholder="Ingrese nombre" AutoPostBack="false" OnTextChanged="OnFocusCamposVacios" runat="server" />    
              </div>
              <div class="form-outline mb-4">
                <label class="form-label" for="usuario-input">Email</label>
                  <asp:TextBox TextMode="Email" ID="TextBoxMail" CssClass="form-control form-control-md" placeholder="Ingrese email" OnTextChanged="OnFocusCamposVacios" runat="server" />    
              </div>
              <div class="form-outline mb-3">
                <label class="form-label" for="contrasena-input">Contraseña</label>
                  <asp:TextBox TextMode="Password" ID="TextBoxContrasena" CssClass="form-control form-control-md" placeholder="Ingrese contraseña" AutoPostBack="false" OnTextChanged="OnFocusCamposVacios" runat="server" />    
              </div>
              <div class="text-center text-lg-start mt-4 pt-2">
                  <asp:Button Text="Crear usuario" ID="ButtonCrearUsuario"  runat="server" CssClass="btn btn-primary btn-md" OnClick="ButtonCrearUsuario_Click"/>
              </div>
        </div>
      </div>
  </div>
</section>
<script>
    function alertUsuarioOcupado() {
        Swal.fire({
            title: '¡Ups!',
            text: 'Ya hay un empleado con ese correo',
            icon: 'error',
            timer: 1500,
            showConfirmButton: false
        })
    }
    function alertRegistroExitoso() {
        Swal.fire({
            title: '¡Usuario creado!',
            text: 'Ya podrá loggearse',
            icon: 'success',
            timer: 1500,
            showConfirmButton: false
        })
    }
</script>
</asp:Content>
