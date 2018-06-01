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
    public class AdministratorController : ApiController
    {
        private GurmaniModel db = new GurmaniModel();

        // GET: api/Administrator
        public IQueryable<Administrator> GetAdministrator()
        {
            return db.Administrator;
        }

        // GET: api/Administrator/5
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> GetAdministrator(int id)
        {
            Administrator administrator = await db.Administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/Administrator/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrator(int id, Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrator.ID)
            {
                return BadRequest();
            }

            db.Entry(administrator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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

        // POST: api/Administrator
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> PostAdministrator(Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrator.Add(administrator);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administrator.ID }, administrator);
        }

        // DELETE: api/Administrator/5
        [ResponseType(typeof(Administrator))]
        public async Task<IHttpActionResult> DeleteAdministrator(int id)
        {
            Administrator administrator = await db.Administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.Administrator.Remove(administrator);
            await db.SaveChangesAsync();

            return Ok(administrator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministratorExists(int id)
        {
            return db.Administrator.Count(e => e.ID == id) > 0;
        }
    }
}