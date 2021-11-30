using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.Threading;

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
                Session["allDescuentos"] = allDescuentos;
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

        protected void MofidicarDescuento(object sender, EventArgs e)
        {
            try
            {
                var argument = ((Button)sender).CommandArgument;
                Descuento aux = new Descuento();

                int cont = 0;
                foreach (Descuento item in ((List<Descuento>)Session["allDescuentos"]))
                {
                    if (argument == item.Codigo.ToString() &&
                       ((TextBox)DescuentoRepeater.Items[cont].FindControl("DescuentoPorcentaje")).Text != "")
                    {
                        aux.Codigo = item.Codigo;
                        aux.Porcentaje = decimal.Parse(((TextBox)DescuentoRepeater.Items[cont].FindControl("DescuentoPorcentaje")).Text);
                        aux.Activa = ((CheckBox)DescuentoRepeater.Items[cont].FindControl("DescuentoActivo")).Checked;

                        DescuentoNegocio.ModificarCodigo(aux);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoModificado();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDatosVacios();", true);
                    }
                    cont++;
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoRechazado();", true);
            }
            finally
            {
                updateTablaPromociones();
                Session["allDescuentos"] = allDescuentos;
            }
            
            
        }

        protected void EliminarDescuento(object sender, EventArgs e)
        {
            try
            {
                var argument = ((Button)sender).CommandArgument;
                Descuento aux = new Descuento();

                int cont = 0;
                foreach (Descuento item in ((List<Descuento>)Session["allDescuentos"]))
                {
                    if (argument == item.Codigo.ToString())
                    {
                        aux.Codigo = item.Codigo;

                        DescuentoNegocio.EliminarCodigo(aux);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoEliminado();", true);
                        Thread.Sleep(1000);
                    }
                    cont++;
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertDatosVacios", "alertDescuentoRechazado();", true);
            }
            finally
            {
                updateTablaPromociones();
                Session["allDescuentos"] = allDescuentos;
                Response.Redirect("AdmPromociones.aspx", false);
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