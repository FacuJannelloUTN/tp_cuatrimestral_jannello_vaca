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
            string consultaCarritos =  $"Insert into Carritos (codCompra, codDescuento, idComprador, conEnvio, finalizado, entregado, monto, fechaRealizado) " +
                $"values ('{carrito.CodCompra}', '{carrito.Descuento.Codigo}', {carrito.Comprador.Id}, {carrito.devolverBit(carrito.ConEnvio)}, {carrito.devolverBit(carrito.Finalizado)}, {carrito.devolverBit(carrito.Entregado)}, {carrito.MontoTotal}, '{carrito.FechaRealizado}')";
            
            try
            {
                AccesoDatos.setearConsulta(consultaCarritos);
                AccesoDatos.ejectutarAccion();
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            this.cargarProductosDeCarrito(carrito.Productos, carrito.CodCompra);
        }
        private void cargarProductosDeCarrito(List<Producto> productos, string codCompra)
        {
            long idCarrito = this.buscarIdPorCodigoCompra(codCompra);
            foreach (var producto in productos)
            {
                string consultaProducto = $"Insert into ProductosEnCarritos (idCarrito, idProducto) values" +
                    $"({idCarrito}, {producto.Id})";
                try
                {
                    AccesoDatos.setearConsulta(consultaProducto);
                    AccesoDatos.ejectutarAccion();
                } catch (Exception e)
                {
                    throw e;
                } finally
                {
                    AccesoDatos.cerrarConexion();
                }
            }
        }
        private long buscarIdPorCodigoCompra(string cod)
        {
            long id = 0;
            string consulta = $"Select id from Carritos where codCompra ='{cod}'";
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                {
                    id = (long)AccesoDatos.Lector["id"];
                }
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                AccesoDatos.cerrarConexion();
            }
            return id;
        }
    }
}
