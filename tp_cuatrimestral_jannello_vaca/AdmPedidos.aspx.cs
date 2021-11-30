using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Diagnostics;
using dominio;

namespace tp_cuatrimestral_jannello_vaca
{
    public partial class AdmPedidos : System.Web.UI.Page
    {
        public List<Carrito> CarritosPendientes { get; set; }
        public List<Carrito> CarritosEntregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.updateTablas();
            }
        }

        private void updateTablas()
        {
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            List<Carrito> carritos = carritoNegocio.listar("");
            CarritosPendientes = carritos.FindAll((carrito) => carrito.Finalizado == true && carrito.Entregado == false);
            CarritosEntregados = carritos.FindAll((carrito) => carrito.Finalizado == true && carrito.Entregado == true);
            Session.Add("carritosPendientes", CarritosPendientes);
            Session.Add("carritosEntregados", CarritosEntregados);
            TablaPedidosPendientes.DataSource = (List<Carrito>)Session["carritosPendientes"];
            TablaPedidosPendientes.DataBind();
            TablaPedidosEntregados.DataSource = (List<Carrito>)Session["carritosEntregados"];
            TablaPedidosEntregados.DataBind();
        }

        protected void ButtonConfirmarEntrega_Click(object sender, EventArgs e)
        {
            long id = long.Parse(((Button)sender).CommandArgument);
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            carritoNegocio.entregarPedido(id);
            this.updateTablas();
        }

        protected void ButtonReabrirPedido_Click(object sender, EventArgs e)
        {
            long id = long.Parse(((Button)sender).CommandArgument);
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            carritoNegocio.reabrirPedido(id);
            this.updateTablas();

        }
    }
}