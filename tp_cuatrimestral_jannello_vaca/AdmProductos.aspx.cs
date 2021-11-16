using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Data;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class AdmProductos : System.Web.UI.Page
    {
        public List<Producto> allProductos { get; set; }
        public List<Categoria> allCategorias { get; set; }
        public List<Marca> allMarcas { get; set; }
        public Producto selectedProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.updateTablaProductos();
            this.agregarMarcasADropdown();
            this.agregarCategoriasADropdown();
            selectedProducto = allProductos[0];
            this.updateDataSelectedProducto();
        }
        private void updateTablaProductos()
        {
            ProductoNegocio prodNegocio = new ProductoNegocio();
            allProductos = prodNegocio.listar("");
            TablaProductos.DataSource = allProductos;
            TablaProductos.DataBind();
        }
        private void agregarCategoriasADropdown()
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            allCategorias = catNegocio.listar("");
            DropDownListCategorias.DataSource = allCategorias;
            DropDownListCategorias.DataBind();

        }
        private void agregarMarcasADropdown()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            allMarcas = marcaNegocio.listar("");
            DropDownListMarcas.DataSource = allMarcas;
            DropDownListMarcas.DataBind();

        }
        private void updateDataSelectedProducto()
        {
            TextBoxNombreProducto.Text = selectedProducto.Nombre;
            ImageProducto.ImageUrl = selectedProducto.URLimagen;
            TextBoxDescripcionProducto.Text = selectedProducto.Descripcion;
            TextBoxURLImagen.Text = selectedProducto.URLimagen;
            TextBoxCodigoProducto.Text = selectedProducto.CodigoArticulo;
            DropDownListCategorias.SelectedValue = allCategorias.Find(x => x.Id == selectedProducto.Categoria.Id).ToString();
            DropDownListMarcas.SelectedValue = allMarcas.Find(x => x.Id == selectedProducto.Marca.Id).ToString();
        }

    }
}