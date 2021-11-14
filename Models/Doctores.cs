using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedical.Models
{
    public class Doctores
    {
        public Int64 doc_Id { get; set; }
        public string doc_Nombre { get; set; }
        public string doc_Especialidad { get; set; }
    }
}