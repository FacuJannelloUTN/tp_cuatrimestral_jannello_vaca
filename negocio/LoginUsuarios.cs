using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class LoginUsuarios
    {
        AccesoDatos AccesoDatos = new AccesoDatos("(local)\\SQLEXPRESS", "TPFinalPrograIII");
        public bool ValidarLogueo(string _mail, string _pass, ref Usuario userLog)
        {
            AccesoDatos.setearConsulta("select * from Usuarios where mail = '" + _mail + "' and contrasenia = '" + _pass + "'");
            AccesoDatos.ejecutarLectura();
            if (AccesoDatos.Lector.Read())
            {
               
                userLog.Id = (long)AccesoDatos.Lector["id"];
                userLog.Nombre = AccesoDatos.Lector.GetString(1);
                userLog.Contrasena = AccesoDatos.Lector.GetString(2);
                userLog.Mail = AccesoDatos.Lector.GetString(3);
                userLog.Tipo = (long)AccesoDatos.Lector["idTipoDeUsuario"];

                AccesoDatos.cerrarConexion();
                return true;
            }
            AccesoDatos.cerrarConexion();
            return false;
        }

    }
    
}
