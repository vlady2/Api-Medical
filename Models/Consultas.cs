using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Models
{
    public class Consultas
    {
        public Int64 con_Id { get; set; }
        public string con_Paciente { get; set; }
        public string doc_Fk { get; set; }
        public string con_Fecha { get; set; }
        public string con_Hora { get; set; }
    }
}