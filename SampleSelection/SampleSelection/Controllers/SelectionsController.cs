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
        public async Task<IHttpActionResult> GetSelection(long id)
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
        public async Task<IHttpActionResult> PutSelection(long id, Selection selection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selection.ISBN)
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

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SelectionExists(selection.ISBN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = selection.ISBN }, selection);
        }

        // DELETE: api/Selections/5
        [ResponseType(typeof(Selection))]
        public async Task<IHttpActionResult> DeleteSelection(long id)
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

        private bool SelectionExists(long id)
        {
            return db.Selection.Count(e => e.ISBN == id) > 0;
        }
    }
}