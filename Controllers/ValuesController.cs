using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    public class ValuesController : ApiController
    {
        InteractivoEntities db = new InteractivoEntities();
        // GET api/values
        public IEnumerable<Estudiante> Get()
        {
            return db.Estudiante.ToList();
        }

        // GET api/values/5
        public Estudiante Get(string id)
        {
            return db.Estudiante.Find(id);
        }

        // POST api/values
        public string Post([FromBody] Estudiante estudiante)
        {
            try
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                return "Estudiante Adicionado";
            }

            catch (Exception we)
            {
                return "Error al insertar registro";
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
