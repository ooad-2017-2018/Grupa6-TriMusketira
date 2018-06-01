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
    public class StavkeNarudzbeController : ApiController
    {
        private GurmaniModel db = new GurmaniModel();

        // GET: api/StavkeNarudzbe
        public IQueryable<StavkeNarudzbe> GetStavkeNarudzbe()
        {
            return db.StavkeNarudzbe;
        }

        // GET: api/StavkeNarudzbe/5
        [ResponseType(typeof(StavkeNarudzbe))]
        public async Task<IHttpActionResult> GetStavkeNarudzbe(int id)
        {
            StavkeNarudzbe stavkeNarudzbe = await db.StavkeNarudzbe.FindAsync(id);
            if (stavkeNarudzbe == null)
            {
                return NotFound();
            }

            return Ok(stavkeNarudzbe);
        }

        // PUT: api/StavkeNarudzbe/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStavkeNarudzbe(int id, StavkeNarudzbe stavkeNarudzbe)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostStavkeNarudzbe(StavkeNarudzbe stavkeNarudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StavkeNarudzbe.Add(stavkeNarudzbe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stavkeNarudzbe.id }, stavkeNarudzbe);
        }

        // DELETE: api/StavkeNarudzbe/5
        [ResponseType(typeof(StavkeNarudzbe))]
        public async Task<IHttpActionResult> DeleteStavkeNarudzbe(int id)
        {
            StavkeNarudzbe stavkeNarudzbe = await db.StavkeNarudzbe.FindAsync(id);
            if (stavkeNarudzbe == null)
            {
                return NotFound();
            }

            db.StavkeNarudzbe.Remove(stavkeNarudzbe);
            await db.SaveChangesAsync();

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