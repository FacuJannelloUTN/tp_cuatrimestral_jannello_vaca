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

        public Descuento buscarPorCodigo(string codigo)
        {
            Descuento desc = new Descuento();
            try
            {
                string consulta = $"Select * from Descuentos where codigo = '{ codigo }'";
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                {
                    desc.Porcentaje = (decimal)AccesoDatos.Lector["porcentaje"];
                    desc.Codigo = codigo;
                    desc.Activa = (bool)AccesoDatos.Lector["estado"];
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
            return desc;
        }
        public List<Descuento> listar(string where = "")
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
        public bool AgregarDescuento(Descuento auxDescuentos) 
        {
            bool err = false;
            try
            {
                string query = "";
            
                query = "Insert into Descuentos values (";
                query += ("'" + auxDescuentos.Codigo + "',");
                query += ( auxDescuentos.Porcentaje.ToString().Replace(",", ".") + ",");

                query += (Convert.ToByte(auxDescuentos.Activa)) + ")";
            
                AccesoDatos.setearConsulta(query);
                AccesoDatos.ejectutarAccion();
                err = true;
            }
            catch
            {
                err = false;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            return err;
        }

        public void ModificarCodigo(Descuento auxDescuentos)
        {
            try
            {
                string query = "";
                query = "Update Descuentos set ";
                query += ("porcentaje = " + auxDescuentos.Porcentaje.ToString().Replace(",", ".") + ",");
                query += ("estado = " + Convert.ToByte(auxDescuentos.Activa));

                query += " where codigo = '" + auxDescuentos.Codigo + "'";
                AccesoDatos.setearConsulta(query);
                AccesoDatos.ejectutarAccion();
            }
            catch
            {

            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }


        }

        public void EliminarCodigo(Descuento auxDescuentos)
        {
            try
            {
                string query = "";
                query = "Delete Descuentos ";
                query += " where codigo = '" + auxDescuentos.Codigo + "'";
                AccesoDatos.setearConsulta(query);
                AccesoDatos.ejectutarAccion();
            }
            catch
            {

            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }


        }
    }
}
