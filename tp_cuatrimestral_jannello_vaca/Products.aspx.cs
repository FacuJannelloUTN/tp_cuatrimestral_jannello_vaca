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
            if (!IsPostBack)
            {

                ProductoNegocio productoNegocio = new ProductoNegocio();
                CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
                MarcaNegocio MarcaNegocio = new MarcaNegocio();

                allProductos = productoNegocio.listar("");
                Session["Catalogo"] = allProductos;


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

                if (Request.QueryString["producto"] != null)
                {
                    Carrito carrito = new Func<Carrito>(() => {
                        return Session["Carrito"] != null
                            ? (Carrito)Session["Carrito"]
                            : new Carrito();
                    })();
                    if (carrito.Productos != null)
                    {
                       carrito.Productos.Add(allProductos.Find(x => x.Id == long.Parse(Request.QueryString["producto"])));
                    }
                    else
                    {
                        carrito.Productos = new List<Producto>();
                        carrito.Productos.Add(allProductos.Find(x => x.Id == long.Parse(Request.QueryString["producto"])));
                    }
                    Session.Add("Carrito", carrito);
                }
            }
            allProductos = ((List<Producto>)Session["Catalogo"]);
        }

        protected void products_buscar_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            //allProductos = productoNegocio.listar($"and P.nombre like '%{products_buscar.Text}%'");
            string NombreProd    = products_buscar.Text;
            string CategoriaProd = products_categorias.SelectedValue;
            string MarcaProducto = products_marca.SelectedValue;
            string mininoProd    = products_precioMinimo.Text;
            string maximoProd    = products_precioMaximo.Text;

            string consulta = "";


            if(NombreProd != "")
            {
                consulta += " and P.nombre like '%" + NombreProd + "%'";
            }
            if (CategoriaProd != "Todos")
            {
                consulta += " and C.nombre = '" + CategoriaProd + "'";
            }
            if (MarcaProducto != "Todos")
            {
                consulta += " and M.nombre = '" + MarcaProducto + "'";
            }
            if (mininoProd != "" && maximoProd != "")
            {
                consulta += " and P.Precio between " + mininoProd + " and " + maximoProd;
            }
            else if (mininoProd != "")
            {
                consulta += " and P.Precio >= " + mininoProd;
            }
            else if (maximoProd != "")
            {
                consulta += " and P.Precio <= " + maximoProd;
            }

            if(productoNegocio.listar(consulta).Count() > 0)
            {
                Session["Catalogo"] = productoNegocio.listar(consulta);
                allProductos = ((List<Producto>)Session["Catalogo"]);
            }

            return;

        }

    }
}