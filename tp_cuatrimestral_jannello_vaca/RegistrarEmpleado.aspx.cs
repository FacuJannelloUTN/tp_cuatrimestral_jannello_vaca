using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class RegistrarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.validateUsuarioLoggeado();
        }

        private void validateUsuarioLoggeado()
        {
            if (Session["UserLog"] == null)
            {
                Session.Add("error", "No tienes permiso para ver este contenido");
                Response.Redirect("Error.aspx", false);
            }
            else if (((Usuario)Session["UserLog"]).Tipo != TipoUsuario.EMPLEADO)
            {
                Session.Add("error", "No tienes permiso para ver este contenido");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void OnFocusCamposVacios(object sender, EventArgs e)
        {
            if (TextBoxMail.Text == "") { TextBoxMail.Focus(); }
            else if (TextBoxContrasena.Text == "") { TextBoxContrasena.Focus(); }
        }

        protected void login_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonCrearUsuario_Click(object sender, EventArgs e)
        {
            UsuariosNegocio usuarioNegocio = new UsuariosNegocio();
            long id = usuarioNegocio.buscarIdPorMail(TextBoxMail.Text);
            if (id != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertUsuarioOcupado", "alertUsuarioOcupado();", true);
                return;
            }
            usuarioNegocio.crearUsuario(TextBoxMail.Text, TextBoxNombre.Text, TextBoxContrasena.Text, TipoUsuario.EMPLEADO);
            ScriptManager.RegisterStartupScript(this, GetType(), "alertRegistroExitoso", "alertRegistroExitoso();", true);
        }
    }
}