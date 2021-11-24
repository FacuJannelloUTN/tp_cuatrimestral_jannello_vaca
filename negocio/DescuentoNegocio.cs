using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DescuentoNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");

        public List<Descuento> listar(string where)
        {
            List<Descuento> lista = new List<Descuento>();
            try
            {
                string consulta = "Select * from Descuentos " + where;

                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Descuento desc = new Descuento();
                    desc.Codigo = (string)AccesoDatos.Lector["codigo"];
                    desc.Porcentaje = (decimal)AccesoDatos.Lector["porcentaje"];
                    desc.Activa = (bool)AccesoDatos.Lector["estado"];
                    lista.Add(desc);
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
        public decimal buscarPorCodigo(string codigo)
        {
           decimal descuento;
           try
           {
                string consulta = $"Select porcentaje from Descuentos where codigo = '{ codigo }' and estado = 1";
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                    descuento = (decimal)AccesoDatos.Lector["porcentaje"];
                else
                    descuento = 0;

           }
           catch (Exception ex)
           {
                throw ex;
           }
           finally
           {
                AccesoDatos.cerrarConexion();
           }
           return descuento;
        }
    }
}
