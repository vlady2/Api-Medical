using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Data
{
    public class Conexion
    {
        public string ConexionSQL()
        {
            string respuesta = "";
            try
            {
                //PInfos
                //pr_CitasOnline
                respuesta = @"Data Source=LAPTOP-JIMR5AJ2\SQLEXPRESS;Initial Catalog=PInfos;User ID=sa;Password=VL97vi19+";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return respuesta;
        }
    }
}