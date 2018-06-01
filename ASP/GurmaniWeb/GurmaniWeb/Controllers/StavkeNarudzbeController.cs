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
using GurmaniWeb.Models;

namespace GurmaniWeb.Controllers
{
    public class StavkeNarudzbeController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/StavkeNarudzbe
        public IQueryable<StavkeNarudzbe> GetStavkeNarudzbe()
        {
            return db.StavkeNarudzbe;
        }

        // GET: api/StavkeNarudzbe/5
        [ResponseType(typeof(StavkeNarudzbe))]
        public IHttpActionResult GetStavkeNarudzbe(int id)
        {
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzbe.Find(id);
            if (stavkeNarudzbe == null)
            {
                return NotFound();
            }

            return Ok(stavkeNarudzbe);
        }

        // PUT: api/StavkeNarudzbe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavkeNarudzbe(int id, StavkeNarudzbe stavkeNarudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavkeNarudzbe.id)
            {
                return BadRequest();
            }

            db.Entry(stavkeNarudzbe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StavkeNarudzbeExists(id))
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

        // POST: api/StavkeNarudzbe
        [ResponseType(typeof(StavkeNarudzbe))]
        public IHttpActionResult PostStavkeNarudzbe(StavkeNarudzbe stavkeNarudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StavkeNarudzbe.Add(stavkeNarudzbe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stavkeNarudzbe.id }, stavkeNarudzbe);
        }

        // DELETE: api/StavkeNarudzbe/5
        [ResponseType(typeof(StavkeNarudzbe))]
        public IHttpActionResult DeleteStavkeNarudzbe(int id)
        {
            StavkeNarudzbe stavkeNarudzbe = db.StavkeNarudzbe.Find(id);
            if (stavkeNarudzbe == null)
            {
                return NotFound();
            }

            db.StavkeNarudzbe.Remove(stavkeNarudzbe);
            db.SaveChanges();

            return Ok(stavkeNarudzbe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StavkeNarudzbeExists(int id)
        {
            return db.StavkeNarudzbe.Count(e => e.id == id) > 0;
        }
    }
}