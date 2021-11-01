using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        public decimal Descuento { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Descuento = 0;
        }

        protected void ButtonSubmitCodigo_Click(object sender, EventArgs e)
        {
            DescuentoNegocio descuentoNegocio = new DescuentoNegocio();
            this.Descuento = descuentoNegocio.buscarPorCodigo(TextBoxCodigoDescuento.Text);
            if (this.Descuento == 0)
            {
                LabelMensajeRespuestaCodigo.CssClass = "text-danger";
                LabelMensajeRespuestaCodigo.Text = "El código no existe";
            }
            else
            {
                LabelMensajeRespuestaCodigo.CssClass = "text-success";
                LabelMensajeRespuestaCodigo.Text = "Código aprobado";
                LabelDescuento.Text = $"{this.Descuento}%";
            }

        }
    }
}