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
    public class NarudzbaController : ApiController
    {
        private GurmaniModel db = new GurmaniModel();

        // GET: api/Narudzba
        public IQueryable<Narudzba> GetNarudzba()
        {
            return db.Narudzba;
        }

        // GET: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public async Task<IHttpActionResult> GetNarudzba(int id)
        {
            Narudzba narudzba = await db.Narudzba.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            return Ok(narudzba);
        }

        // PUT: api/Narudzba/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNarudzba(int id, Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzba.id)
            {
                return BadRequest();
            }

            db.Entry(narudzba).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaExists(id))
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

        // POST: api/Narudzba
        [ResponseType(typeof(Narudzba))]
        public async Task<IHttpActionResult> PostNarudzba(Narudzba narudzba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Narudzba.Add(narudzba);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = narudzba.id }, narudzba);
        }

        // DELETE: api/Narudzba/5
        [ResponseType(typeof(Narudzba))]
        public async Task<IHttpActionResult> DeleteNarudzba(int id)
        {
            Narudzba narudzba = await db.Narudzba.FindAsync(id);
            if (narudzba == null)
            {
                return NotFound();
            }

            db.Narudzba.Remove(narudzba);
            await db.SaveChangesAsync();

            return Ok(narudzba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaExists(int id)
        {
            return db.Narudzba.Count(e => e.id == id) > 0;
        }
    }
}