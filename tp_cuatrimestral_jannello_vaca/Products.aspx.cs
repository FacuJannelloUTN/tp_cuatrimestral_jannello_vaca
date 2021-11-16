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
                CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
                MarcaNegocio MarcaNegocio = new MarcaNegocio();
                allProductos = productoNegocio.listar("");

                products_categorias.Items.Clear();
                products_categorias.Items.Add("Todos");
                foreach (Categoria item in CategoriaNegocio.listar(""))
                {
                    products_categorias.Items.Add(item.Descripcion);
                }

                products_marca.Items.Clear();
                products_marca.Items.Add("Todos");
                foreach (Marca item in MarcaNegocio.listar(""))
                {
                    products_marca.Items.Add(item.Descripcion);
                }
        }

        protected void products_buscar_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            allProductos = productoNegocio.listar($"and P.nombre like '{products_buscar.Text}'");
            return;

        }
    }
}