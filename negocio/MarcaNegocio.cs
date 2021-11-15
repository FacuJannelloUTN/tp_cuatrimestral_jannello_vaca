using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class MarcaNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public List<Marca> listar(string where)
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                string consulta = "Select  * from MarcasProductos " + where;

                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Marca marca = new Marca((long)AccesoDatos.Lector["id"], (string)AccesoDatos.Lector["nombre"]);
                    lista.Add(marca);
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
                string consulta = $"Select id from MarcasProductos where nombre = '{nombre}'";
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                    returnedValue = (long)AccesoDatos.Lector["id"];
            } catch (Exception e)
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
                string consulta = $"Insert into MarcasProductos (nombre) values ('{capitalizeNombre}')";
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
            if (prodN.listar($"where idMarca = {id}").Count > 0)
            {
                return false;
            }
            try
            {
                string consulta = $"delete from MarcasProductos where id = '{id}'";
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
