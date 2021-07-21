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
    public class PlanContablesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PlanContables
        public IQueryable<PlanContable> GetPlanContable()
        {
            return db.PlanContable;
        }

        // GET: api/PlanContables/5
        [ResponseType(typeof(PlanContable))]
        public IHttpActionResult GetPlanContable(string id)
        {
            PlanContable planContable = db.PlanContable.Find(id);
            if (planContable == null)
            {
                return NotFound();
            }

            return Ok(planContable);
        }

        // PUT: api/PlanContables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlanContable(string id, PlanContable planContable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planContable.cod_cuenta)
            {
                return BadRequest();
            }

            db.Entry(planContable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanContableExists(id))
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

        // POST: api/PlanContables
        [ResponseType(typeof(PlanContable))]
        public IHttpActionResult PostPlanContable(PlanContable planContable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlanContable.Add(planContable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlanContableExists(planContable.cod_cuenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = planContable.cod_cuenta }, planContable);
        }

        // DELETE: api/PlanContables/5
        [ResponseType(typeof(PlanContable))]
        public IHttpActionResult DeletePlanContable(string id)
        {
            PlanContable planContable = db.PlanContable.Find(id);
            if (planContable == null)
            {
                return NotFound();
            }

            db.PlanContable.Remove(planContable);
            db.SaveChanges();

            return Ok(planContable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanContableExists(string id)
        {
            return db.PlanContable.Count(e => e.cod_cuenta == id) > 0;
        }
    }
}