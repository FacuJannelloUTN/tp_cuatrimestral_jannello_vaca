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
    public partial class Products : System.Web.UI.Page
    {
        public List<Producto> allProductos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            allProductos = productoNegocio.listar("");
            
        }
    }
}