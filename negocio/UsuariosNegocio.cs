using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class UsuariosNegocio
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        
        public Usuario buscarPorId(long id)
        {
            Usuario user = new Usuario();
            string consulta = $"select nombre, mail, contrasenia, idTipoDeUsuario from Usuarios where id = {id}";
            try
            {
                AccesoDatos.setearConsulta(consulta);
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                {
                    user.Nombre = (string)AccesoDatos.Lector["nombre"];
                    user.Mail = (string)AccesoDatos.Lector["mail"];
                    user.Contrasena = (string)AccesoDatos.Lector["contrasenia"];
                    user.Id = id;
                    user.Tipo = (int)AccesoDatos.Lector["idTipoDeUsuario"] == 1 ? TipoUsuario.EMPLEADO : TipoUsuario.CLIENTE;
                }
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                AccesoDatos.cerrarConexion();
            }
            return user;
        }
        public bool ValidarLogueo(string _mail, string _pass, ref Usuario userLog)
        {
            bool respuesta = false;
            try
            {
                AccesoDatos.setearConsulta("select * from Usuarios where mail = '" + _mail + "' and contrasenia = '" + _pass + "'");
                AccesoDatos.ejecutarLectura();
                if (AccesoDatos.Lector.Read())
                {

                    userLog.Id = (long)AccesoDatos.Lector["id"];
                    userLog.Nombre = (string)AccesoDatos.Lector["nombre"];
                    userLog.Contrasena = (string)AccesoDatos.Lector["contrasenia"];
                    userLog.Mail = (string)AccesoDatos.Lector["mail"];
                    userLog.Tipo = (long)AccesoDatos.Lector["idTipoDeUsuario"] == 1 ? TipoUsuario.EMPLEADO : TipoUsuario.CLIENTE;
                    respuesta = true;
                }
            } catch (Exception e)
            {
                throw e;
            } finally
            {
                AccesoDatos.cerrarConexion();
            }
            return respuesta;
        }
        public long buscarIdPorMail (string mail)
        {
            long id = 0;
            string consulta = $"Select id from Usuarios where mail = '{mail}'";
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
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
            return id;
        }

        public void crearUsuario(string mail, string nombre="", string contrasenia = "", TipoUsuario tipo = TipoUsuario.CLIENTE)
        {
            string consulta = "Insert into Usuarios (mail, nombre, contrasenia, idTipoDeUsuario) values " +
                $"('{mail}', '{nombre}', '{contrasenia}', {(int)tipo})";
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
