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
    public class SubdiariosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Subdiarios
        public IQueryable<Subdiario> GetSubdiario()
        {
            return db.Subdiario;
        }

        // GET: api/Subdiarios/5
        [ResponseType(typeof(Subdiario))]
        public IHttpActionResult GetSubdiario(int id)
        {
            Subdiario subdiario = db.Subdiario.Find(id);
            if (subdiario == null)
            {
                return NotFound();
            }

            return Ok(subdiario);
        }

        // PUT: api/Subdiarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubdiario(int id, Subdiario subdiario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subdiario.cod_sub)
            {
                return BadRequest();
            }

            db.Entry(subdiario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubdiarioExists(id))
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

        // POST: api/Subdiarios
        [ResponseType(typeof(Subdiario))]
        public IHttpActionResult PostSubdiario(Subdiario subdiario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subdiario.Add(subdiario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subdiario.cod_sub }, subdiario);
        }

        // DELETE: api/Subdiarios/5
        [ResponseType(typeof(Subdiario))]
        public IHttpActionResult DeleteSubdiario(int id)
        {
            Subdiario subdiario = db.Subdiario.Find(id);
            if (subdiario == null)
            {
                return NotFound();
            }

            db.Subdiario.Remove(subdiario);
            db.SaveChanges();

            return Ok(subdiario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubdiarioExists(int id)
        {
            return db.Subdiario.Count(e => e.cod_sub == id) > 0;
        }
    }
}