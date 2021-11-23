using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DescuentoNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public decimal buscarPorCodigo(string codigo)
        {
           decimal descuento;
           try
           {
                string consulta = $"Select porcentaje from Descuentos where codigo = '{ codigo }'";
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
