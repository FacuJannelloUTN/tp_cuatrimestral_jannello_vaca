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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        public decimal Descuento { get; set; }
        public Carrito Carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.Descuento = 0;
                if (Session["Carrito"] != null)
                {
                    Carrito carrito = (Carrito)Session["Carrito"];
                    carrito.Descuento = new Descuento();
                    carrito.Descuento.Porcentaje = 0;
                    carrito.Descuento.Codigo = "";
                }        
            }
            Carrito = new Func<Carrito>(() => {
              Carrito carritoVacio = new Carrito();
              carritoVacio.Productos = new List<Producto>();
              carritoVacio.Descuento = new Descuento();
              carritoVacio.Descuento.Porcentaje = 0;
              carritoVacio.Descuento.Codigo = "";
              return Session["Carrito"] != null
                ? (Carrito)Session["Carrito"]
                : carritoVacio;
            })();
            Descuento = new Func<decimal>(() => {
                return Session["DescuentoActivo"] != null
                  ? (decimal)Session["DescuentoActivo"]
                  : 0;
            })();
            if (Request.QueryString["reducir"] != null)
            {
                Carrito cart = (Carrito)Session["Carrito"];
                Producto productoARemover = cart.Productos.Find(x => x.Id == long.Parse(Request.QueryString["reducir"]));
                cart.Productos.Remove(productoARemover);
                Session.Add("Carrito", cart);
            }
            if (Request.QueryString["aumentar"] != null)
            {
                Carrito cart = (Carrito)Session["Carrito"];
                Producto productoARemover = cart.Productos.Find(x => x.Id == long.Parse(Request.QueryString["aumentar"]));
                cart.Productos.Add(productoARemover);
                Session.Add("Carrito", cart);
            }
            if (Request.QueryString["reducirTodo"] != null)
            {
                Carrito cart = (Carrito)Session["Carrito"];
                cart.Productos.RemoveAll(x => x.Id == long.Parse(Request.QueryString["reducirTodo"]));
                Session.Add("Carrito", cart);
            }
        }

        protected void ButtonSubmitCodigo_Click(object sender, EventArgs e)
        {
            DescuentoNegocio descuentoNegocio = new DescuentoNegocio();
            decimal descuento = descuentoNegocio.buscarPorCodigo(TextBoxCodigoDescuento.Text);
            Session.Add("DescuentoActivo", descuento);
            Descuento = descuento;
            if (descuento == 0)
            {
                LabelMensajeRespuestaCodigo.CssClass = "text-danger";
                LabelMensajeRespuestaCodigo.Text = "El código no existe";

            }
            else
            {
                LabelMensajeRespuestaCodigo.CssClass = "text-success";
                LabelMensajeRespuestaCodigo.Text = "Código aprobado";
            }
            Carrito.Descuento = new Descuento();
            Carrito.Descuento.Codigo = TextBoxCodigoDescuento.Text;
            Carrito.Descuento.Porcentaje = descuento;
            Session.Add("Carrito", Carrito);
        }

        protected void ButtonAvanzar_Click(object sender, EventArgs e)
        {
            
            if (Carrito.Productos.Count == 0)
            {
                LabelErrorAlAvanzar.Visible = true;
                return;
            }
            LabelErrorAlAvanzar.Visible = false;
            Step1.Visible = false;
            Step2.Visible = true;
            ButtonAvanzar.Visible = false;
        }

        protected void CheckBoxConEnvio_CheckedChanged(object sender, EventArgs e)
        {
            return;
        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            LabelErrorAlAvanzar.Visible = false;
            Step1.Visible = false;
            Step2.Visible = false;
            PanelCarrito.Visible = false;
            StepConfirm.Visible = true;
            ButtonAvanzar.Visible = false;
            Session.Remove("Carrito");
        }
    }
}