using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Models
{
    public class Diagnosticos
    {
        public int d_Id { get; set; }
        public string d_Diagnostico { get; set; }
        public int con_Fk { get; set; }
        public string d_Fecha { get; set; }
    }
}