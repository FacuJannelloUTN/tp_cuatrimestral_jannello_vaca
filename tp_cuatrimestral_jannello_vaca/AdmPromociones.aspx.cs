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
        public List<Descuento> allDescuentos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void updateTablaPromociones()
        {
            DescuentoNegocio descuentoNegocio = new DescuentoNegocio();
            List<Descuento> allDescuentosFetched = descuentoNegocio.listar("");
            Session.Add("allDescuentos", allDescuentosFetched);
            allDescuentos = allDescuentosFetched;
        }
    }
}