using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using dominio;

namespace negocio
{
    public class CarritoNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        
        public List<Carrito> listar(string where)
        {
            string consulta = "Select C.id 'id', " +
                "codCompra, codDescuento, idComprador, conEnvio, fechaRealizado," +
                "fechaEntregado, finalizado, entregado, monto," +
                "D.estado 'estadoDescuento', D.porcentaje 'porcentajeDescuento', U.nombre 'nombreUsuario', U.contrasenia 'contraseniaUsuario', U.mail 'mailUsuario', U.idTipoDeUsuario 'tipoUsuario' " +
                "from Carritos C " +
                "left join Descuentos D on D.codigo = C.codDescuento " +
                "left join Usuarios U on U.id = C.idComprador";
            List<Carrito> carritos = new List<Carrito>();
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Carrito carrito = new Carrito();
                    carrito.Id = (long)AccesoDatos.Lector["id"];
                    carrito.CodCompra = (string)AccesoDatos.Lector["codCompra"];
                    carrito.Descuento = new Descuento();
                    if (!(AccesoDatos.Lector["estadoDescuento"] is DBNull))
                        carrito.Descuento.Activa = (bool)AccesoDatos.Lector["estadoDescuento"];
                    if (!(AccesoDatos.Lector["codDescuento"] is DBNull))
                        carrito.Descuento.Codigo = (string)AccesoDatos.Lector["codDescuento"];
                    if (!(AccesoDatos.Lector["porcentajeDescuento"] is DBNull))
                        carrito.Descuento.Porcentaje = (decimal)AccesoDatos.Lector["porcentajeDescuento"];
                    carrito.Comprador = new Usuario();
                    if (!(AccesoDatos.Lector["idComprador"] is DBNull))
                        carrito.Comprador.Id = (long)AccesoDatos.Lector["idComprador"];
                    if (!(AccesoDatos.Lector["contraseniaUsuario"] is DBNull))
                        carrito.Comprador.Contrasena = (string)AccesoDatos.Lector["contraseniaUsuario"];
                    if (!(AccesoDatos.Lector["nombreUsuario"] is DBNull))
                        carrito.Comprador.Nombre = (string)AccesoDatos.Lector["nombreUsuario"];
                    if (!(AccesoDatos.Lector["mailUsuario"] is DBNull))
                        carrito.Comprador.Mail = (string)AccesoDatos.Lector["mailUsuario"];
                    if (!(AccesoDatos.Lector["tipoUsuario"] is DBNull))
                        carrito.Comprador.Tipo = (long)AccesoDatos.Lector["tipoUsuario"] == 1 
                            ? TipoUsuario.EMPLEADO : TipoUsuario.CLIENTE;
                    if (!(AccesoDatos.Lector["conEnvio"] is DBNull))
                        carrito.ConEnvio = (bool)AccesoDatos.Lector["conEnvio"];
                    if (!(AccesoDatos.Lector["finalizado"] is DBNull))
                        carrito.Finalizado = (bool)AccesoDatos.Lector["finalizado"];
                    if (!(AccesoDatos.Lector["monto"] is DBNull))
                        carrito.MontoTotal = (decimal)AccesoDatos.Lector["monto"];
                    if (!(AccesoDatos.Lector["entregado"] is DBNull))
                        carrito.Entregado = (bool)AccesoDatos.Lector["entregado"];
                    if (!(AccesoDatos.Lector["fechaEntregado"] is DBNull))
                        carrito.FechaEntregado = AccesoDatos.Lector.GetDateTime(6);
                    if (!(AccesoDatos.Lector["fechaRealizado"] is DBNull))
                        carrito.FechaRealizado = AccesoDatos.Lector.GetDateTime(5);
                    carritos.Add(carrito);
                }

            } catch (Exception e)
            {
                throw e;
            } finally
            {
                AccesoDatos.cerrarConexion();
            }
            if (carritos.Count != 0)
            {
                foreach (var carrito in carritos)
                {
                    carrito.Productos = this.buscarProductosDeUnCarritoPorID(carrito.Id);
                }
            }
            return carritos;
        }
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

        private List<Producto> buscarProductosDeUnCarritoPorID(long id)
        {
            List<Producto> lista = new List<Producto>();
            string consulta = $"Select idProducto from ProductosEnCarritos where idCarrito = {id}";
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    ProductoNegocio prodNegocio = new ProductoNegocio();
                    long idProd = (long)AccesoDatos.Lector["idProducto"];
                    Producto prod = prodNegocio.listar($"where P.id = {idProd}")[0];
                    lista.Add(prod);
                }
            } catch (Exception e)
            {

                throw e;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            return lista;
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
        public void entregarPedido (long id)
        {
            string consulta = $"update Carritos set entregado = 1 where id = {id}";
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejectutarAccion();
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                AccesoDatos.cerrarConexion();
            }
        }

        public void reabrirPedido(long id)
        {
            string consulta = $"update Carritos set entregado = 0 where id = {id}";
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejectutarAccion();
            }
            catch (Exception e)
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
