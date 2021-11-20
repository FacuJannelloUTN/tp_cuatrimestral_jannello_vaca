using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int IdCarrito { get; set; }
        public string CodCompra { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal Ganancia { get; set; }
        public bool Entregado { get; set; }
    }
}
