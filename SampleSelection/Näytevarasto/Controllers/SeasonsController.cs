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
        public async Task<IHttpActionResult> GetSeasons(int id)
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
        public async Task<IHttpActionResult> PutSeasons(int id, Seasons seasons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seasons.SeasonID)
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
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = seasons.SeasonID }, seasons);
        }

        // DELETE: api/Seasons/5
        [ResponseType(typeof(Seasons))]
        public async Task<IHttpActionResult> DeleteSeasons(int id)
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

        private bool SeasonsExists(int id)
        {
            return db.Seasons.Count(e => e.SeasonID == id) > 0;
        }
    }
}