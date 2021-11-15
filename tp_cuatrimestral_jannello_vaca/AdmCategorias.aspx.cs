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
    public partial class AdmCategorias : System.Web.UI.Page
    {
        public List<Categoria> allCategorias { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            allCategorias = CategoriaNegocio.listar("");
            this.updateTablaCategorias();
        }

        private void updateTablaCategorias()
        {
            TablaCategorias.Rows.Clear();
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell idHeader = new TableHeaderCell();
            TableHeaderCell nombreHeader = new TableHeaderCell();
            idHeader.Controls.Add(new LiteralControl("ID"));
            nombreHeader.Controls.Add(new LiteralControl("Nombre"));
            header.Cells.Add(idHeader);
            header.Cells.Add(nombreHeader);
            TablaCategorias.Rows.Add(header);
            foreach (Categoria Categoria in allCategorias)
            {
                TableRow r = new TableRow();
                TableCell id = new TableCell();
                TableCell nombre = new TableCell();
                id.Controls.Add(new LiteralControl(Categoria.Id.ToString()));
                nombre.Controls.Add(new LiteralControl(Categoria.Descripcion.ToString()));
                r.Cells.Add(id);
                r.Cells.Add(nombre);
                TablaCategorias.Rows.Add(r);
            }
        }
        protected void ButtonSubmitCategoria_Click(object sender, EventArgs e)
        {
            if (TextBoxCategoriaNueva.Text.Length > 0)
            {
                CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
                CategoriaNegocio.crear(TextBoxCategoriaNueva.Text);
                Page.Response.Redirect(Page.Request.Url.ToString(), true); // Recarga la página
            }
        }

        protected void ButtonBuscarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            string where = $"where nombre like '{TextBoxBuscarCategoria.Text}'";
            allCategorias = CategoriaNegocio.listar(where);
            this.updateTablaCategorias();
        }

        protected void TextBoxBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            allCategorias = CategoriaNegocio.listar("");
            this.updateTablaCategorias();
        }

        protected void ButtonEliminarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
            bool elimino = CategoriaNegocio.eliminar(TextBoxEliminarCategoria.Text);
            if (elimino)
            {
                LabelErrorEliminarCategoria.Visible = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                LabelErrorEliminarCategoria.Visible = true;
            }
        }

        protected void TextBoxEliminarCategoria_TextChanged(object sender, EventArgs e)
        {
            LabelErrorEliminarCategoria.Visible = false;
        }
    }
}