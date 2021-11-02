using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductoNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public List<Producto> listar(string where)
        {
            List<Producto> lista = new List<Producto>();
            try
            {

                string consulta = "Select  P.id id,P.codArticulo,P.nombre,P.descripcion,M.nombre 'marca',C.nombre 'categoria'," +
                                    "P.URLimagen,P.precio, P.idMarca IdMarca, P.idCategoria IdCategoria, S.cantidad 'stock' from Productos P " +
                                    "inner join MarcasProductos M on M.id=P.idMarca " +
                                    "inner join CategoriasProductos C on C.id=P.idCategoria " +
                                    "inner join StocksProductos S on S.id=P.idStock" + where;
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (long)AccesoDatos.Lector["id"];
                    if (!(AccesoDatos.Lector["codArticulo"] is DBNull))
                        producto.CodigoArticulo = (string)AccesoDatos.Lector["codArticulo"];
                    if (!(AccesoDatos.Lector["nombre"] is DBNull))
                        producto.Nombre = (string)AccesoDatos.Lector["nombre"];
                    if (!(AccesoDatos.Lector["descripcion"] is DBNull))
                        producto.Descripcion = (string)AccesoDatos.Lector["descripcion"];
                    if (!(AccesoDatos.Lector["URLimagen"] is DBNull))
                        producto.URLimagen = (string)AccesoDatos.Lector["URLimagen"];
                    if (!(AccesoDatos.Lector["precio"] is DBNull))
                        producto.Precio = (decimal)AccesoDatos.Lector["precio"];
                    if (!(AccesoDatos.Lector["marca"] is DBNull))
                        producto.Marca = new Marca((long)AccesoDatos.Lector["idMarca"], (string)AccesoDatos.Lector["marca"]);
                    if (!(AccesoDatos.Lector["categoria"] is DBNull))
                        producto.Categoria = new Categoria((long)AccesoDatos.Lector["idCategoria"], (string)AccesoDatos.Lector["categoria"]);
                    if (!(AccesoDatos.Lector["stock"] is DBNull))
                        producto.Stock = (long)AccesoDatos.Lector["stock"];
                    lista.Add(producto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            return lista;
        }
    }
}
