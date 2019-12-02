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
    public class AspNetUsersController : ApiController
    {
        private NaytevarastoEntities db = new NaytevarastoEntities();

        // GET: api/AspNetUsers
        public IQueryable<AspNetUsers> GetAspNetUsers()
        {
            return db.AspNetUsers;
        }

        // GET: api/AspNetUsers/5
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IHttpActionResult> GetAspNetUsers(string id)
        {
            AspNetUsers aspNetUsers = await db.AspNetUsers.FindAsync(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return Ok(aspNetUsers);
        }

        // PUT: api/AspNetUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAspNetUsers(string id, AspNetUsers aspNetUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetUsers.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUsers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUsersExists(id))
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

        // POST: api/AspNetUsers
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IHttpActionResult> PostAspNetUsers(AspNetUsers aspNetUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetUsers.Add(aspNetUsers);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUsersExists(aspNetUsers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspNetUsers.Id }, aspNetUsers);
        }

        // DELETE: api/AspNetUsers/5
        [ResponseType(typeof(AspNetUsers))]
        public async Task<IHttpActionResult> DeleteAspNetUsers(string id)
        {
            AspNetUsers aspNetUsers = await db.AspNetUsers.FindAsync(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspNetUsers);
            await db.SaveChangesAsync();

            return Ok(aspNetUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUsersExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}