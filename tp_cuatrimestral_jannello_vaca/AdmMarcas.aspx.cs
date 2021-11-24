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
    public partial class AdmMarcas : System.Web.UI.Page
    {
        public List<Marca> allMarcas {get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            this.validateUsuarioLoggeado();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            allMarcas = marcaNegocio.listar("");
            this.updateTablaMarcas();
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
        private void updateTablaMarcas()
        {
            TablaMarcas.Rows.Clear();
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell idHeader = new TableHeaderCell();
            TableHeaderCell nombreHeader = new TableHeaderCell();
            idHeader.Controls.Add(new LiteralControl("ID"));
            nombreHeader.Controls.Add(new LiteralControl("Nombre"));
            header.Cells.Add(idHeader);
            header.Cells.Add(nombreHeader);
            TablaMarcas.Rows.Add(header);
            foreach (Marca marca in allMarcas)
            {
                TableRow r = new TableRow();
                TableCell id = new TableCell();
                TableCell nombre = new TableCell();
                id.Controls.Add(new LiteralControl(marca.Id.ToString()));
                nombre.Controls.Add(new LiteralControl(marca.Descripcion.ToString()));
                r.Cells.Add(id);
                r.Cells.Add(nombre);
                TablaMarcas.Rows.Add(r);
            }
        }
        protected void ButtonSubmitMarca_Click(object sender, EventArgs e)
        {
            if (TextBoxMarcaNueva.Text.Length > 0)
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marcaNegocio.crear(TextBoxMarcaNueva.Text);
                Page.Response.Redirect(Page.Request.Url.ToString(), true); // Recarga la página
            }
        }

        protected void ButtonBuscarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            string where = $"where nombre like '{TextBoxBuscarMarca.Text}'";
            allMarcas = marcaNegocio.listar(where);
            this.updateTablaMarcas();
        }

        protected void TextBoxBuscarMarca_TextChanged(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            allMarcas = marcaNegocio.listar("");
            this.updateTablaMarcas();
        }

        protected void ButtonEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            bool elimino = marcaNegocio.eliminar(TextBoxEliminarMarca.Text);
            if (elimino)
            {
                LabelErrorEliminarMarca.Visible = false;
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                LabelErrorEliminarMarca.Visible = true;
            }
        }

        protected void TextBoxEliminarMarca_TextChanged(object sender, EventArgs e)
        {
            LabelErrorEliminarMarca.Visible = false;
        }
    }
}