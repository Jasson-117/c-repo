using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppi.Models;

namespace WebAppi.Controllers
{
    public class NotasController : ApiController
    {
        Interactivo2Entities db = new Interactivo2Entities();

        // GET api/<controller>
        public List<notas1> Get()
        {
            var consulta = from name1 in db.notas1
                           select name1;
            return consulta.ToList();
        }

        // GET api/<controller>/5
        public List<notas1> Get(int id)
        {
            var consulta = from name in db.notas1
                           where name.id_estudiante == id
                           select name;

            return consulta.ToList();



        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] notas1 notas)
        {
            try
            {
                db.notas1.Add(notas);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, notas);
            }

            catch (Exception we)
            {
                var message = string.Format("notas1 with id = {0} not found", notas.id_notas);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }

        // PUT api/<controller>/5
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] notas1 estudiante)
        {
            try
            {
                if (db.notas1.Find(id) != null)
                {
                    notas1 est = db.notas1.Find(id);
                    db.Entry(est).CurrentValues.SetValues(estudiante);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, db.notas1.Find(estudiante.id_notas));
                }
                else
                {
                    var message = string.Format("notas with id = {0} not found", id);
                    HttpError error = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, error);
                }
            }
            catch (Exception we)
            {
                var message = string.Format("notas with id = {0} not found", estudiante.id_notas);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }

        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            string respuesta = "";
            notas1 estudiante = db.notas1.Find(id);

            if (estudiante != null)
            {
                db.notas1.Remove(estudiante);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "notas eliminado");
            }
            else
            {
                var message = string.Format("notas with id = {0} not found", id);
                HttpError error = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);

            }
        }
    }
}