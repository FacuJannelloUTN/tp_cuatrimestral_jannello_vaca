﻿using System;
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
        public List<Carrito> Carritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            List<Carrito> carritos = carritoNegocio.listar("");
            Carritos = carritos;
        }
    }
}