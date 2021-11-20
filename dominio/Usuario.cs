using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Mail { get; set; }
        public long Tipo { get; set; }

    }
}
