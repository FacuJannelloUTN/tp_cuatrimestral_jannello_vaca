using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public List<Categoria> listar(string where)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                string consulta = "Select  * from CategoriasProductos " + where;

                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Categoria categoria = new Categoria((long)AccesoDatos.Lector["id"], (string)AccesoDatos.Lector["nombre"]);
                    lista.Add(categoria);
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
        public long buscarPorNombre(string nombre)
        {
            long returnedValue = 0;
            try
            {
                string consulta = $"Select id from CategoriasProductos where nombre = '{nombre}'";
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                    returnedValue = (long)AccesoDatos.Lector["id"];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            return returnedValue;
        }
        public void crear(string nombre)
        {
            string capitalizeNombre = char.ToUpper(nombre[0]) + nombre.ToLower().Substring(1);
            try
            {
                string consulta = $"Insert into CategoriasProductos (nombre) values ('{capitalizeNombre}')";
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

        public bool eliminar(string id)
        {
            ProductoNegocio prodN = new ProductoNegocio();
            if (prodN.listar($"where idCategoria = {id}").Count > 0)
            {
                return false;
            }
            try
            {
                string consulta = $"delete from CategoriasProductos where id = '{id}'";
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
            return true;
        }
    }

}
