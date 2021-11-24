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