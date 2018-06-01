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
    public class ObjekatController : ApiController
    {
        private GurmaniModel db = new GurmaniModel();

        // GET: api/Objekat
        public IQueryable<Objekat> GetObjekat()
        {
            return db.Objekat;
        }

        // GET: api/Objekat/5
        [ResponseType(typeof(Objekat))]
        public async Task<IHttpActionResult> GetObjekat(int id)
        {
            Objekat objekat = await db.Objekat.FindAsync(id);
            if (objekat == null)
            {
                return NotFound();
            }

            return Ok(objekat);
        }

        // PUT: api/Objekat/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutObjekat(int id, Objekat objekat)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostObjekat(Objekat objekat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objekat.Add(objekat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = objekat.id }, objekat);
        }

        // DELETE: api/Objekat/5
        [ResponseType(typeof(Objekat))]
        public async Task<IHttpActionResult> DeleteObjekat(int id)
        {
            Objekat objekat = await db.Objekat.FindAsync(id);
            if (objekat == null)
            {
                return NotFound();
            }

            db.Objekat.Remove(objekat);
            await db.SaveChangesAsync();

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