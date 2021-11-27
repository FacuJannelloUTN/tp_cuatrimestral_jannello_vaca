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
    public partial class AdmPromociones : System.Web.UI.Page
    {
        public DescuentoNegocio DescuentoNegocio = new DescuentoNegocio();
        public List<Descuento> allDescuentos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.validateUsuarioLoggeado();
            if (!IsPostBack)
            {
                this.updateTablaPromociones();
                DescuentoRepeater.DataSource = allDescuentos;
                DescuentoRepeater.DataBind();

                int cont = 0;
                foreach (Descuento item in allDescuentos)
                {
                    ((TextBox)DescuentoRepeater.Items[cont].FindControl("DescuentoNombre")).Text = item.Codigo.ToString();
                    ((TextBox)DescuentoRepeater.Items[cont].FindControl("DescuentoPorcentaje")).Text = string.Format("{0:00.00}", item.Porcentaje);
                    ((CheckBox)DescuentoRepeater.Items[cont].FindControl("DescuentoActivo")).Checked = item.Activa;
                    cont++;
                }
            }
        }

        protected void AgregarDescuento(object sender, EventArgs e)
        {
            Descuento auxDescuento = new Descuento();
            if (DescuentoNombreNew.Text != "" && DescuentoPorcentajeNew.Text != "")
            {
                try
                {
                    auxDescuento.Codigo = DescuentoNombreNew.Text;
                    auxDescuento.Porcentaje = decimal.Parse(DescuentoPorcentajeNew.Text.Replace(".",","));
                    auxDescuento.Activa = DescuentoActivoNew.Checked;
                    if (DescuentoNegocio.AgregarDescuento(auxDescuento))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoAgregado();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoRechazado();", true);
                    }
                    DescuentoNombreNew.Text = "";
                    DescuentoPorcentajeNew.Text = "";
                    DescuentoActivoNew.Checked = false;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoRechazado();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDatosVacios();", true);
            }
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

        private void updateTablaPromociones()
        {
            DescuentoNegocio descuentoNegocio = new DescuentoNegocio();
            List<Descuento> allDescuentosFetched = descuentoNegocio.listar("");
            Session.Add("allDescuentos", allDescuentosFetched);
            allDescuentos = allDescuentosFetched;
        }
    }
}