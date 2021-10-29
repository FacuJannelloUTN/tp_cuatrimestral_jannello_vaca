using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    class Carrito
    {
        public int Id { get; set; } 
        public List<Producto> Productos { get; set; }
        public string CodCompra { get; set; }
        public string CodDescuento { get; set; }    
        public Usuario Comprador { get; set; }
        public bool ConEnvio { get; set; }
        public bool Finalizado { get; set; }
       
    }

}
