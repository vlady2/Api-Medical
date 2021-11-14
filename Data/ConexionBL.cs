using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Data
{
    public class ConexionBL
    {
        Conexion con = new Conexion();
        public string conexionSQL()
        {
            return con.ConexionSQL();
        }
    }
}