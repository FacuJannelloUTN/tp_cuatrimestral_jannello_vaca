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
        public Producto selectedProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            this.updateTablaProductos();
            this.updateDropdownMarcas();
            this.updateDropdownCategorias();
            this.setearProductoVacioEnSession();
            }
        }

        private void updateTablaProductos()
        {
            ProductoNegocio prodNegocio = new ProductoNegocio();
            List<Producto> allProductos = prodNegocio.listar("");
            Session.Add("allProductos", allProductos);
            TablaProductos.DataSource = (List<Producto>)Session["allProductos"];
            TablaProductos.DataBind();
        }
        private void updateDropdownCategorias()
        {

            CategoriaNegocio catNegocio = new CategoriaNegocio();
            List<Categoria> allCategorias = catNegocio.listar("");
            Session.Add("allCategorias", allCategorias);
            DropDownListCategorias.DataSource = (List<Categoria>)Session["allCategorias"];
            DropDownListCategorias.DataBind();
            DropDownListCategoriasCreacion.DataSource = (List<Categoria>)Session["allCategorias"];
            DropDownListCategoriasCreacion.DataBind();

        }
        private void updateDropdownMarcas()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> allMarcas = marcaNegocio.listar("");
            Session.Add("allMarcas", allMarcas);
            DropDownListMarcas.DataSource = (List<Marca>)Session["allMarcas"];
            DropDownListMarcas.DataBind();
            DropDownListMarcasCreacion.DataSource = (List<Marca>)Session["allMarcas"];
            DropDownListMarcasCreacion.DataBind();
        }
        private void updateDataSelectedProducto()
        {
            TextBoxNombreProducto.Text = selectedProducto.Nombre;
            ImageProducto.ImageUrl = selectedProducto.URLimagen;
            TextBoxDescripcionProducto.Text = selectedProducto.Descripcion;
            TextBoxURLImagen.Text = selectedProducto.URLimagen;
            TextBoxCodigoProducto.Text = selectedProducto.CodigoArticulo;
            TextBoxPrecio.Text = selectedProducto.Precio.ToString();
            TextBoxStock.Text = selectedProducto.Stock.ToString();
            DropDownListCategorias.SelectedValue = ((List<Categoria>)Session["allCategorias"]).Find(x => x.Id == selectedProducto.Categoria.Id).Id.ToString();
            DropDownListMarcas.SelectedValue = ((List<Marca>)Session["allMarcas"]).Find(x => x.Id == selectedProducto.Marca.Id).Id.ToString();
        }


        protected void TextBoxCodigoProducto_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.CodigoArticulo = TextBoxCodigoProducto.Text;
            Session.Add("selectedProducto", prod);
        }

        protected void TextBoxDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Descripcion = TextBoxDescripcionProducto.Text;
            Session.Add("selectedProducto", prod);
        }

        protected void TextBoxNombreProducto_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Nombre = TextBoxNombreProducto.Text;
            Session.Add("selectedProducto", prod);
        }

        protected void TextBoxStock_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Stock = long.Parse(TextBoxStock.Text);
            Session.Add("selectedProducto", prod);
        }

        protected void DropDownListMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = long.Parse(DropDownListMarcas.SelectedItem.Value);
            Marca marca = ((List<Marca>)Session["allMarcas"]).Find(m => m.Id == id);
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Marca = marca;
            Session.Add("selectedProducto", prod);
        }

        protected void DropDownListCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = long.Parse(DropDownListCategorias.SelectedItem.Value);
            Categoria categoria = ((List<Categoria>)Session["allCategorias"]).Find(m => m.Id == id);
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Categoria = categoria;
            Session.Add("selectedProducto", prod);
        }

        protected void TextBoxURLImagen_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.URLimagen = TextBoxURLImagen.Text;
            Session.Add("selectedProducto", prod);
            ImageProducto.ImageUrl = prod.URLimagen;
        }

        protected void TextBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)Session["selectedProducto"];
            prod.Precio = decimal.Parse(TextBoxPrecio.Text);
            Session.Add("selectedProducto", prod);
        }

        protected void ButtonCrear_Click(object sender, EventArgs e)
        {
            PanelCreacionProducto.Visible = true;
            PanelSelectedProducto.Visible = false;
        }

        protected void ButtonCancelarCreacion_Click(object sender, EventArgs e)
        {
            this.setearProductoVacioEnSession();
            this.vaciarCamposCreacion();
            PanelCreacionProducto.Visible = false;
        }

        protected void TextBoxNombreCreacion_TextChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.Nombre = TextBoxNombreCreacion.Text;
            Session.Add("productoCreacion", prod);
        }

        protected void TextBoxDescripcionCreacion_TextChanged(object sender, EventArgs e)
        {

            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.Descripcion = TextBoxDescripcionCreacion.Text;
            Session.Add("productoCreacion", prod);
        }

        protected void TextBoxCodigoProductoCreacion_TextChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.CodigoArticulo = TextBoxCodigoProductoCreacion.Text;
            Session.Add("productoCreacion", prod);

        }

        protected void TextBoxStockCreacion_TextChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.Stock = long.Parse(TextBoxStockCreacion.Text);
            Session.Add("productoCreacion", prod);
        }

        protected void TextBoxURLImagenCreacion_TextChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.URLimagen = TextBoxURLImagenCreacion.Text;
            Session.Add("productoCreacion", prod);
            ImageCreacion.ImageUrl = prod.URLimagen;
        }

        protected void TextBoxPrecioCreacion_TextChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            prod.Precio = decimal.Parse(TextBoxPrecioCreacion.Text);
            Session.Add("productoCreacion", prod);

        }

        protected void DropDownListCategoriasCreacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            long id = long.Parse(DropDownListCategoriasCreacion.SelectedItem.Value);
            prod.Categoria = ((List<Categoria>)Session["allCategorias"]).Find(c => c.Id == id);
            Session.Add("productoCreacion", prod);
        }

        protected void DropDownListMarcasCreacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod = (Producto)Session["productoCreacion"];
            long id = long.Parse(DropDownListMarcasCreacion.SelectedItem.Value);
            prod.Marca = ((List<Marca>)Session["allMarcas"]).Find(m => m.Id == id);
            Session.Add("productoCreacion", prod);
        }

        protected void ButtonConfirmarCreacion_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            ProductoNegocio prodNeg = new ProductoNegocio();
            prodNeg.crearNuevo((Producto)Session["productoCreacion"]);
            this.updateTablaProductos();
            this.vaciarCamposCreacion();
            this.setearProductoVacioEnSession();
            PanelCreacionProducto.Visible = false;
        }

        protected void setearProductoVacioEnSession()
        {
            Producto productoVacio = new Producto();
            long idMarca = long.Parse(DropDownListMarcasCreacion.SelectedItem.Value);
            long idCategoria = long.Parse(DropDownListCategoriasCreacion.SelectedItem.Value);
            productoVacio.Categoria = ((List<Categoria>)Session["allCategorias"]).Find(c => c.Id == idCategoria);
            productoVacio.Marca = ((List<Marca>)Session["allMarcas"]).Find(m => m.Id == idMarca);
            Session.Add("productoCreacion", productoVacio);
        }

        protected void vaciarCamposCreacion()
        {
            TextBoxCodigoProductoCreacion.Text = "";
            TextBoxNombreCreacion.Text = "";
            TextBoxDescripcionCreacion.Text = "";
            TextBoxStockCreacion.Text = "";
            TextBoxURLImagenCreacion.Text = "";
            TextBoxPrecioCreacion.Text = "";
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio prodNeg = new ProductoNegocio();
            Producto prod = (Producto)Session["selectedProducto"];
            prodNeg.eliminarConBajaLogica(prod.Id);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void ButtonVerDetalle_Click(object sender, EventArgs e)
        {
            long id = long.Parse(((Button)sender).CommandArgument);
            selectedProducto = ((List<Producto>)Session["allProductos"]).Find(p => p.Id == id);
            this.updateDataSelectedProducto();
            Session.Add("selectedProducto", selectedProducto);
            PanelSelectedProducto.Visible = true;
            PanelCreacionProducto.Visible = false;
        }

        protected void ButtonGuardarCambios_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
            Producto prod = (Producto)Session["selectedProducto"];
            ProductoNegocio prodNeg = new ProductoNegocio();
            prodNeg.actualizar(prod);
            this.updateTablaProductos();

        }
    }
}