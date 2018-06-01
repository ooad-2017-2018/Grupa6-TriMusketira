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
    public class ObjekatController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Objekat
        public IQueryable<Objekat> GetObjekat()
        {
            return db.Objekat;
        }

        // GET: api/Objekat/5
        [ResponseType(typeof(Objekat))]
        public IHttpActionResult GetObjekat(int id)
        {
            Objekat objekat = db.Objekat.Find(id);
            if (objekat == null)
            {
                return NotFound();
            }

            return Ok(objekat);
        }

        // PUT: api/Objekat/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObjekat(int id, Objekat objekat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objekat.id)
            {
                return BadRequest();
            }

            db.Entry(objekat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjekatExists(id))
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

        // POST: api/Objekat
        [ResponseType(typeof(Objekat))]
        public IHttpActionResult PostObjekat(Objekat objekat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objekat.Add(objekat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = objekat.id }, objekat);
        }

        // DELETE: api/Objekat/5
        [ResponseType(typeof(Objekat))]
        public IHttpActionResult DeleteObjekat(int id)
        {
            Objekat objekat = db.Objekat.Find(id);
            if (objekat == null)
            {
                return NotFound();
            }

            db.Objekat.Remove(objekat);
            db.SaveChanges();

            return Ok(objekat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjekatExists(int id)
        {
            return db.Objekat.Count(e => e.id == id) > 0;
        }
    }
}