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
    public class SelectionLangsController : ApiController
    {
        private NaytevarastoEntities db = new NaytevarastoEntities();

        // GET: api/SelectionLangs
        public IQueryable<SelectionLang> GetSelectionLang()
        {
            return db.SelectionLang;
        }

        // GET: api/SelectionLangs/5
        [ResponseType(typeof(SelectionLang))]
        public async Task<IHttpActionResult> GetSelectionLang(int id)
        {
            SelectionLang selectionLang = await db.SelectionLang.FindAsync(id);
            if (selectionLang == null)
            {
                return NotFound();
            }

            return Ok(selectionLang);
        }

        // PUT: api/SelectionLangs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSelectionLang(int id, SelectionLang selectionLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selectionLang.LangID)
            {
                return BadRequest();
            }

            db.Entry(selectionLang).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectionLangExists(id))
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

        // POST: api/SelectionLangs
        [ResponseType(typeof(SelectionLang))]
        public async Task<IHttpActionResult> PostSelectionLang(SelectionLang selectionLang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SelectionLang.Add(selectionLang);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = selectionLang.LangID }, selectionLang);
        }

        // DELETE: api/SelectionLangs/5
        [ResponseType(typeof(SelectionLang))]
        public async Task<IHttpActionResult> DeleteSelectionLang(int id)
        {
            SelectionLang selectionLang = await db.SelectionLang.FindAsync(id);
            if (selectionLang == null)
            {
                return NotFound();
            }

            db.SelectionLang.Remove(selectionLang);
            await db.SaveChangesAsync();

            return Ok(selectionLang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelectionLangExists(int id)
        {
            return db.SelectionLang.Count(e => e.LangID == id) > 0;
        }
    }
}