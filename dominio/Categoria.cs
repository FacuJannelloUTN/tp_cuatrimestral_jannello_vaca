using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Categoria(int id, string desc)
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
