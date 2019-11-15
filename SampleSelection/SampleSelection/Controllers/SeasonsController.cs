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
using SampleSelection.Models;

namespace SampleSelection.Controllers
{
    public class SeasonsController : ApiController
    {
        private NaytevarastoEntities db = new NaytevarastoEntities();

        // GET: api/Seasons
        public IQueryable<Seasons> GetSeasons()
        {
            return db.Seasons;
        }

        // GET: api/Seasons/5
        [ResponseType(typeof(Seasons))]
        public async Task<IHttpActionResult> GetSeasons(string id)
        {
            Seasons seasons = await db.Seasons.FindAsync(id);
            if (seasons == null)
            {
                return NotFound();
            }

            return Ok(seasons);
        }

        // PUT: api/Seasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeasons(string id, Seasons seasons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seasons.Season)
            {
                return BadRequest();
            }

            db.Entry(seasons).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonsExists(id))
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

        // POST: api/Seasons
        [ResponseType(typeof(Seasons))]
        public async Task<IHttpActionResult> PostSeasons(Seasons seasons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seasons.Add(seasons);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeasonsExists(seasons.Season))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seasons.Season }, seasons);
        }

        // DELETE: api/Seasons/5
        [ResponseType(typeof(Seasons))]
        public async Task<IHttpActionResult> DeleteSeasons(string id)
        {
            Seasons seasons = await db.Seasons.FindAsync(id);
            if (seasons == null)
            {
                return NotFound();
            }

            db.Seasons.Remove(seasons);
            await db.SaveChangesAsync();

            return Ok(seasons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeasonsExists(string id)
        {
            return db.Seasons.Count(e => e.Season == id) > 0;
        }
    }
}