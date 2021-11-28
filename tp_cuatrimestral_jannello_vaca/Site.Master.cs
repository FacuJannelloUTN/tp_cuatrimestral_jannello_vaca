using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class SiteMaster : MasterPage
    {
        public Usuario usuario { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "TP Cuatrimestral Jannello-Vaca";
            usuario = new Usuario();
            if (Session["UserLog"] != null)
            {
              usuario = (Usuario)Session["UserLog"];
                if (usuario.Tipo == TipoUsuario.EMPLEADO)
                  {
                    PanelLogoUtn.Visible = false;
                    PanelMenuParaClientes.Visible = false;
                    PanelMenuParaEmpleados.Visible = true;
                }
                PanelUsuarioLoggeado.Visible = true;
                AccesoAPortalEmpleados.Visible = false;
            }

        }

        protected void utnLogo_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("/", false);
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("UserLog");
            Response.Redirect("Default.aspx", false);
        }
    }
}