using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public Marca(long id, string desc)
        {
            this.Id = id;
            this.Descripcion = desc;
        }
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
