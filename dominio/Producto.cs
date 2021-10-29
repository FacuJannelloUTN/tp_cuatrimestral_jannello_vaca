using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    class Producto
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Código de Artículo")]
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }

        [DisplayName("URL de la imagen")]
        public string URLimagen { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
