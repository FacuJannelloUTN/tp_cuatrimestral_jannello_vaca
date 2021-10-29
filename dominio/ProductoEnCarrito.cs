using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    class ProductoEnCarrito: Producto 
    {
        public decimal precioDeVenta { get; set; }
        public int cantidad { get; set;  }
    }
}
