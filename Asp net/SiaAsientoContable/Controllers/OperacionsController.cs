using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SiaAsientoContable.Models;
using System.Web.Http.Cors;

namespace SiaAsientoContable.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class OperacionsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Operacions
        public IQueryable<Operacion> GetOperacion()
        {
            return db.Operacion;
        }

        // GET: api/Operacions/5
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult GetOperacion(int id)
        {
            Operacion operacion = db.Operacion.Find(id);
            if (operacion == null)
            {
                return NotFound();
            }

            return Ok(operacion);
        }

        // PUT: api/Operacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOperacion(int id, Operacion operacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operacion.t_oper)
            {
                return BadRequest();
            }

            db.Entry(operacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Operacions
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult PostOperacion(Operacion operacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operacion.Add(operacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = operacion.t_oper }, operacion);
        }

        // DELETE: api/Operacions/5
        [ResponseType(typeof(Operacion))]
        public IHttpActionResult DeleteOperacion(int id)
        {
            Operacion operacion = db.Operacion.Find(id);
            if (operacion == null)
            {
                return NotFound();
            }

            db.Operacion.Remove(operacion);
            db.SaveChanges();

            return Ok(operacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperacionExists(int id)
        {
            return db.Operacion.Count(e => e.t_oper == id) > 0;
        }
    }
}