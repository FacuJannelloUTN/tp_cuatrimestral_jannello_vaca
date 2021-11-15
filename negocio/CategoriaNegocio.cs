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
                string consulta = "Select  * from CategoriasProductos" + where;

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
    }

}
