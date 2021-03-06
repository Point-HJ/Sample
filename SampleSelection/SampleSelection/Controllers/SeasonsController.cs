﻿using System;
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
        public IQueryable<Season> GetSeason()
        {
            return db.Season;
        }

        // GET: api/Seasons/5
        [ResponseType(typeof(Season))]
        public async Task<IHttpActionResult> GetSeason(int id)
        {
            Season season = await db.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }

            return Ok(season);
        }

        // PUT: api/Seasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeason(int id, Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != season.SeasonID)
            {
                return BadRequest();
            }

            db.Entry(season).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(id))
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
        [ResponseType(typeof(Season))]
        public async Task<IHttpActionResult> PostSeason(Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Season.Add(season);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = season.SeasonID }, season);
        }

        // DELETE: api/Seasons/5
        [ResponseType(typeof(Season))]
        public async Task<IHttpActionResult> DeleteSeason(int id)
        {
            Season season = await db.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }

            db.Season.Remove(season);
            await db.SaveChangesAsync();

            return Ok(season);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeasonExists(int id)
        {
            return db.Season.Count(e => e.SeasonID == id) > 0;
        }
    }
}