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
    public partial class Login : System.Web.UI.Page
    {
        public Usuario userLog = new Usuario();
        public negocio.LoginUsuarios Consultas = new LoginUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            //OnFocusCamposVacios(sender, e);
            //if(contrasena.Text != "") { contrasena.Text = "asda"; }
        }

        protected void ingreso(object sender, EventArgs e)
        {
            try
            {
                if (mail.Text != "" && contrasena.Text != "")
                {
                    if (Consultas.ValidarLogueo(mail.Text, contrasena.Text, ref userLog))
                    {
                        Session["UserLog"] = userLog;

                        if (userLog.Tipo == 1)
                        {
                            Response.Redirect("AdmProductos.aspx");
                        }
                        else
                        {
                            Response.Redirect("Products.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('USUARIO NO ENCONTRADO')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('COMPLETE AMBOS CAMPOS')</script>");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }


        }

        protected void OnFocusCamposVacios(object sender, EventArgs e)
        {
            if(mail.Text == "") { mail.Focus(); }
            else if (contrasena.Text == "") { contrasena.Focus(); }
            else { ingreso(sender, e); }
        }
    }
}