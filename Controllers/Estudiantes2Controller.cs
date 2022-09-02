using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    public class Estudiantes2Controller : ApiController
    {
        Interactivo2Entities db = new Interactivo2Entities();

        // GET api/<controller>
        public List<estudiante1> Get()
        {
            var consulta = from name1 in db.estudiante1
                           select name1;
            return consulta.ToList();
        }

        // GET api/<controller>/5
        public List<estudiante1> Get(int id)
        {
            var consulta = from name in db.estudiante1
                           where name.id_estudiante == id
                           select name;

            return consulta.ToList();



        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] estudiante1 estudiante)
        {
            try
            {
                db.estudiante1.Add(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, estudiante);
            }

            catch (Exception we)
            {
                var message = string.Format("estudiante1 with id_estudiante = {0} not found", estudiante.id_estudiante);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id,[FromBody] estudiante1 estudiante)
        {
            try
            {
                if (db.estudiante1.Find(id) != null)
                {
                    estudiante1 est = db.estudiante1.Find(id);
                    db.Entry(est).CurrentValues.SetValues(estudiante);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, db.estudiante1.Find(estudiante.id_estudiante));
                }
                else
                {
                    var message = string.Format("Estudiante with id = {0} not found", id);
                    HttpError error = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, error);
                }
            }catch(Exception we)
            {
                var message = string.Format("Estudiante with id = {0} not found", estudiante.id_estudiante);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }

        }



        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            string respuesta = "";
            estudiante1 estudiante = db.estudiante1.Find(id);

            if (estudiante != null)
            {
                db.estudiante1.Remove(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Estudiante eliminado");
            }
            else
            {
                var message = string.Format("Estudiante with id = {0} not found", id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }
        }
    }
}