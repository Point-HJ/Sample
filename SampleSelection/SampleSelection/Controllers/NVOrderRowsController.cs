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
    public class NVOrderRowsController : ApiController
    {
        private NaytevarastoEntities db = new NaytevarastoEntities();

        // GET: api/NVOrderRows
        public IQueryable<NVOrderRows> GetNVOrderRows()
        {
            return db.NVOrderRows;
        }

        // GET: api/NVOrderRows/5
        [ResponseType(typeof(NVOrderRows))]
        public async Task<IHttpActionResult> GetNVOrderRows(int id)
        {
            NVOrderRows nVOrderRows = await db.NVOrderRows.FindAsync(id);
            if (nVOrderRows == null)
            {
                return NotFound();
            }

            return Ok(nVOrderRows);
        }

        // PUT: api/NVOrderRows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNVOrderRows(int id, NVOrderRows nVOrderRows)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nVOrderRows.OrderID)
            {
                return BadRequest();
            }

            db.Entry(nVOrderRows).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NVOrderRowsExists(id))
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

        // POST: api/NVOrderRows
        [ResponseType(typeof(NVOrderRows))]
        public async Task<IHttpActionResult> PostNVOrderRows(NVOrderRows nVOrderRows)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NVOrderRows.Add(nVOrderRows);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nVOrderRows.OrderID }, nVOrderRows);
        }

        // DELETE: api/NVOrderRows/5
        [ResponseType(typeof(NVOrderRows))]
        public async Task<IHttpActionResult> DeleteNVOrderRows(int id)
        {
            NVOrderRows nVOrderRows = await db.NVOrderRows.FindAsync(id);
            if (nVOrderRows == null)
            {
                return NotFound();
            }

            db.NVOrderRows.Remove(nVOrderRows);
            await db.SaveChangesAsync();

            return Ok(nVOrderRows);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NVOrderRowsExists(int id)
        {
            return db.NVOrderRows.Count(e => e.OrderID == id) > 0;
        }
    }
}