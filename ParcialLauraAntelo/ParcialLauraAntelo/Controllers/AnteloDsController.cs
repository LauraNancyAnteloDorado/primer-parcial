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
using ParcialLauraAntelo.Models;

namespace ParcialLauraAntelo.Controllers
{
    public class AnteloDsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AnteloDs
        [Authorize]
        public IQueryable<AnteloD> GetAnteloDs()
        {
            return db.AnteloDs;
        }

        // GET: api/AnteloDs/5
        [Authorize]
        [ResponseType(typeof(AnteloD))]
        public IHttpActionResult GetAnteloD(string id)
        {
            AnteloD anteloD = db.AnteloDs.Find(id);
            if (anteloD == null)
            {
                return NotFound();
            }

            return Ok(anteloD);
        }

        // PUT: api/AnteloDs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnteloD(string id, AnteloD anteloD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anteloD.Name)
            {
                return BadRequest();
            }

            db.Entry(anteloD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnteloDExists(id))
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

        // POST: api/AnteloDs
        [Authorize]
        [ResponseType(typeof(AnteloD))]
        public IHttpActionResult PostAnteloD(AnteloD anteloD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnteloDs.Add(anteloD);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnteloDExists(anteloD.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anteloD.Name }, anteloD);
        }

        // DELETE: api/AnteloDs/5
        [Authorize]
        [ResponseType(typeof(AnteloD))]
        public IHttpActionResult DeleteAnteloD(string id)
        {
            AnteloD anteloD = db.AnteloDs.Find(id);
            if (anteloD == null)
            {
                return NotFound();
            }

            db.AnteloDs.Remove(anteloD);
            db.SaveChanges();

            return Ok(anteloD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnteloDExists(string id)
        {
            return db.AnteloDs.Count(e => e.Name == id) > 0;
        }
    }
}