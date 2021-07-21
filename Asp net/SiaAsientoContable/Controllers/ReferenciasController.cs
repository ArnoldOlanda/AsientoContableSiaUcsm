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
    [EnableCors(origins:"http://localhost:3000",headers:"*",methods:"*")]
    public class ReferenciasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Referencias
        public IQueryable<Referencia> GetReferencia()
        {
            return db.Referencia;
        }

        // GET: api/Referencias/5
        [ResponseType(typeof(Referencia))]
        public IHttpActionResult GetReferencia(int id)
        {
            Referencia referencia = db.Referencia.Find(id);
            if (referencia == null)
            {
                return NotFound();
            }

            return Ok(referencia);
        }

        // PUT: api/Referencias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReferencia(int id, Referencia referencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referencia.cod_tipo)
            {
                return BadRequest();
            }

            db.Entry(referencia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenciaExists(id))
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

        // POST: api/Referencias
        [ResponseType(typeof(Referencia))]
        public IHttpActionResult PostReferencia(Referencia referencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Referencia.Add(referencia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = referencia.cod_tipo }, referencia);
        }

        // DELETE: api/Referencias/5
        [ResponseType(typeof(Referencia))]
        public IHttpActionResult DeleteReferencia(int id)
        {
            Referencia referencia = db.Referencia.Find(id);
            if (referencia == null)
            {
                return NotFound();
            }

            db.Referencia.Remove(referencia);
            db.SaveChanges();

            return Ok(referencia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferenciaExists(int id)
        {
            return db.Referencia.Count(e => e.cod_tipo == id) > 0;
        }
    }
}