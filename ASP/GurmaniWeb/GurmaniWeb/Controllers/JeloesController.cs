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
    public class JeloesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Jeloes
        public IQueryable<Jelo> GetJelo()
        {
            return db.Jelo;
        }

        // GET: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult GetJelo(int id)
        {
            Jelo jelo = db.Jelo.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jeloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJelo(int id, Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jelo.id)
            {
                return BadRequest();
            }

            db.Entry(jelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JeloExists(id))
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

        // POST: api/Jeloes
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult PostJelo(Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jelo.Add(jelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jelo.id }, jelo);
        }

        // DELETE: api/Jeloes/5
        [ResponseType(typeof(Jelo))]
        public IHttpActionResult DeleteJelo(int id)
        {
            Jelo jelo = db.Jelo.Find(id);
            if (jelo == null)
            {
                return NotFound();
            }

            db.Jelo.Remove(jelo);
            db.SaveChanges();

            return Ok(jelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JeloExists(int id)
        {
            return db.Jelo.Count(e => e.id == id) > 0;
        }
    }
}