using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    public class EstudianteController : ApiController
    {
        InteractivoEntities db = new InteractivoEntities();
        // GET api/<controller>
        public IEnumerable<Estudiante> Get()
        {
            return db.Estudiante.ToList();
        }

        // GET api/<controller>/5
        public Estudiante Get(int id)
        {

                return db.Estudiante.Find(id);
         
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Estudiante estudiante)
        {
            try
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,estudiante);
            }

            catch (Exception we)
            {
                var message = string.Format("Estudiante with id = {0} not found", estudiante.id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id,[FromBody] Estudiante estudiante)
        {
           Estudiante estudiante1 = db.Estudiante.Find(id);

            if(estudiante1 != null)
            { 
            db.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"Estudiante acctualizado");
            }
            else{
                var message = string.Format("Estudiante with id = {0} not found", estudiante.id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            string respuesta = "";
            Estudiante estudiante = db.Estudiante.Find(id);

            if (estudiante !=null) {
                db.Estudiante.Remove(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Estudiante eliminado");
            }else
            {
                var message = string.Format("Estudiante with id = {0} not found", id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }
        }
    }
}