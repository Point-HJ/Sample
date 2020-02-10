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
using Näytevarasto;

namespace Näytevarasto.Controllers
{
    public class AspNetRolesController : ApiController
    {
        private STGchannelEntities db = new STGchannelEntities();

        // GET: api/AspNetRoles
        public IQueryable<AspNetRoles> GetAspNetRoles()
        {
            return db.AspNetRoles;
        }

        // GET: api/AspNetRoles/5
        [ResponseType(typeof(AspNetRoles))]
        public async Task<IHttpActionResult> GetAspNetRoles(string id)
        {
            AspNetRoles aspNetRoles = await db.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return Ok(aspNetRoles);
        }

        // PUT: api/AspNetRoles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAspNetRoles(string id, AspNetRoles aspNetRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetRoles.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetRoles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRolesExists(id))
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

        // POST: api/AspNetRoles
        [ResponseType(typeof(AspNetRoles))]
        public async Task<IHttpActionResult> PostAspNetRoles(AspNetRoles aspNetRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetRoles.Add(aspNetRoles);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetRolesExists(aspNetRoles.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspNetRoles.Id }, aspNetRoles);
        }

        // DELETE: api/AspNetRoles/5
        [ResponseType(typeof(AspNetRoles))]
        public async Task<IHttpActionResult> DeleteAspNetRoles(string id)
        {
            AspNetRoles aspNetRoles = await db.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            db.AspNetRoles.Remove(aspNetRoles);
            await db.SaveChangesAsync();

            return Ok(aspNetRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetRolesExists(string id)
        {
            return db.AspNetRoles.Count(e => e.Id == id) > 0;
        }
    }
}