using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMedical.Data;
using WebApiMedical.Models;

namespace WebApiMedical.Controllers
{
    public class DocController : ApiController
    {
        DoctoresData doc = new DoctoresData();
        // GET api/<controller>
        public List<Doctores> Get()
        {
            return doc.getDoctores();
        }

        // GET api/<controller>/5
        public List<Doctores> Get(int id)
        {
            return doc.getDoctor(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Doctores value)
        {
            return doc.insertDoctores(value);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Doctores value)
        {
            return doc.updateDoctores(value);
        }

        //// DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return doc.removeDoctores(id);
        }
    }
}