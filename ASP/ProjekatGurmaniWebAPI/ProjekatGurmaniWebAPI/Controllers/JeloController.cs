using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjekatGurmaniWebAPI.Models;

namespace ProjekatGurmaniWebAPI.Controllers
{
    public class JeloController : ApiController
    {
        private GurmaniModel db = new GurmaniModel();

        // GET: api/Jelo
        public IQueryable<Jelo> GetJelo()
        {
            return db.Jelo;
        }

        // GET: api/Jelo/5
        [ResponseType(typeof(Jelo))]
        public async Task<IHttpActionResult> GetJelo(int id)
        {
            Jelo jelo = await db.Jelo.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }

            return Ok(jelo);
        }

        // PUT: api/Jelo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJelo(int id, Jelo jelo)
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
                await db.SaveChangesAsync();
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

        // POST: api/Jelo
        [ResponseType(typeof(Jelo))]
        public async Task<IHttpActionResult> PostJelo(Jelo jelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jelo.Add(jelo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = jelo.id }, jelo);
        }

        // DELETE: api/Jelo/5
        [ResponseType(typeof(Jelo))]
        public async Task<IHttpActionResult> DeleteJelo(int id)
        {
            Jelo jelo = await db.Jelo.FindAsync(id);
            if (jelo == null)
            {
                return NotFound();
            }

            db.Jelo.Remove(jelo);
            await db.SaveChangesAsync();

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