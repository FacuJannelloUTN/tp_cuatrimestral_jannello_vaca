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
                AccesoDatos.cerrarConexion();
                string consulta = "Select  * from MarcasProductos" + where;

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
    }
}
