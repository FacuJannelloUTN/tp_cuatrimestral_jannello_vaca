using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CarritoNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public void cargarUnCarrito(Carrito carrito)
        {
            string consulta =  $"Insert into Carritos (codCompra, codDescuento, idComprador, conEnvio, finalizado, entregado, monto) " +
                $"values ('{carrito.CodCompra}', '{carrito.Descuento.Codigo}', {carrito.Comprador.Id}, {carrito.devolverBit(carrito.ConEnvio)}, {carrito.devolverBit(carrito.Finalizado)}, {carrito.devolverBit(carrito.Entregado)}, {carrito.MontoTotal})";

            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejectutarAccion();
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
        }
    }
}
