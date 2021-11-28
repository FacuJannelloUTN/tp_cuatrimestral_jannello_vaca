using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Descuento
    {
        public string Codigo {get; set; }
        public decimal Porcentaje { get; set; }
        public bool Activa { get; set; }

    }
}
