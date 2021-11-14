using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiMedical.Models;
using WebApiMedical.Data;

namespace WebApiMedical.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioData us = new UsuarioData();
        // GET api/<controller>
        public List<Usuarios> Get()
        {
            return us.getUsuario();
        }

        // GET api/<controller>/5
        public List<Usuarios> Get(int id)
        {
            return us.obtenerUsuarios(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Usuarios en)
        {
            return us.insertUsuario(en);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Usuarios en)
        {
            return us.updateUsuarios(en);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return us.removeUsuarios(id);
        }
    }
}