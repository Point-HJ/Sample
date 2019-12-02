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
    [Authorize]
    public class SelectionsController : ApiController
    {
        private NaytevarastoEntities db = new NaytevarastoEntities();

        // GET: api/Selections
        public IQueryable<Selection> GetSelection()
        {
            return db.Selection;
        }

        // GET: api/Selections/5
        [ResponseType(typeof(Selection))]
        public async Task<IHttpActionResult> GetSelection(int id)
        {
            Selection selection = await db.Selection.FindAsync(id);
            if (selection == null)
            {
                return NotFound();
            }

            return Ok(selection);
        }

        // PUT: api/Selections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSelection(int id, Selection selection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selection.BookID)
            {
                return BadRequest();
            }

            db.Entry(selection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectionExists(id))
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

        // POST: api/Selections
        [ResponseType(typeof(Selection))]
        public async Task<IHttpActionResult> PostSelection(Selection selection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Selection.Add(selection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = selection.BookID }, selection);
        }

        // DELETE: api/Selections/5
        [ResponseType(typeof(Selection))]
        public async Task<IHttpActionResult> DeleteSelection(int id)
        {
            Selection selection = await db.Selection.FindAsync(id);
            if (selection == null)
            {
                return NotFound();
            }

            db.Selection.Remove(selection);
            await db.SaveChangesAsync();

            return Ok(selection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelectionExists(int id)
        {
            return db.Selection.Count(e => e.BookID == id) > 0;
        }
    }
}