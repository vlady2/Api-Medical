using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string pass { get; set; }
    }
}