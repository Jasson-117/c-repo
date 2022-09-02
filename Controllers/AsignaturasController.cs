using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    public class AsignaturasController : ApiController
    {
        Interactivo2Entities db = new Interactivo2Entities();

        // GET api/<controller>
        public List<asignatura> Get()
        {
            var consulta = from name1 in db.asignatura
                           select name1;
            return consulta.ToList();
        }

        // GET api/<controller>/5
        public List<asignatura> Get(int id)
        {
            var consulta = from name in db.asignatura
                           where name.id_asignatura == id
                           select name;

            return consulta.ToList();



        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] asignatura asignaturaa)
        {
            try
            {
                db.asignatura.Add(asignaturaa);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, asignaturaa);
            }

            catch (Exception we)
            {
                var message = string.Format("asignatura with id_estudiante = {0} not found", asignaturaa.id_asignatura);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

 }
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] asignatura estudiante)
        {
            try
            {
                if (db.asignatura.Find(id) != null)
                {
                    asignatura est = db.asignatura.Find(id);
                    db.Entry(est).CurrentValues.SetValues(estudiante);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, db.asignatura.Find(estudiante.id_asignatura));
                }
                else
                {
                    var message = string.Format("asignatura with id = {0} not found", id);
                    HttpError error = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, error);
                }
            }
            catch (Exception we)
            {
                var message = string.Format("asignatura with id = {0} not found", estudiante.id_asignatura);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }

        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            string respuesta = "";
            asignatura estudiante = db.asignatura.Find(id);

            if (estudiante != null)
            {
                db.asignatura.Remove(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "asignatura eliminado");
            }
            else
            {
                var message = string.Format("asignatura with id = {0} not found", id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }
        }
    }
}