using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        public int Id { get; set; } 
        public List<Producto> Productos { get; set; }
        public string CodCompra { get; set; }
        public Descuento Descuento { get; set; }    
        public Usuario Comprador { get; set; }
        public bool ConEnvio { get; set; }
        public bool Finalizado { get; set; }
        public bool Entregado { get; set; }
        
        public decimal MontoTotal { get; set; }

        public void generarCodigoAleatorio ()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[6];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                if (i == 0)
                {
                    Charsarr[i] = '#';
                }
                else { Charsarr[i] = characters[random.Next(characters.Length)]; }
            }

            var stringAleatorio = new String(Charsarr);
            this.CodCompra = stringAleatorio;
        }
        public int devolverBit(bool propiedad)
        {
            return propiedad ? 1 : 0;
        }
       
    }

}
