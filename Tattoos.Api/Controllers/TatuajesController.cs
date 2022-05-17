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
using Tattoos.Common.Models;
using Tattoos.Domain.Models;

namespace Tattoos.Api.Controllers
{
    public class TatuajesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Tatuajes
        public IQueryable<Tatuajes> GetTatuajes()
        {
            return db.Tatuajes;
        }

        // GET: api/Tatuajes/5
        [ResponseType(typeof(Tatuajes))]
        public async Task<IHttpActionResult> GetTatuajes(int id)
        {
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            if (tatuajes == null)
            {
                return NotFound();
            }

            return Ok(tatuajes);
        }

        // PUT: api/Tatuajes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTatuajes(int id, Tatuajes tatuajes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tatuajes.TattooId)
            {
                return BadRequest();
            }

            db.Entry(tatuajes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TatuajesExists(id))
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

        // POST: api/Tatuajes
        [ResponseType(typeof(Tatuajes))]
        public async Task<IHttpActionResult> PostTatuajes(Tatuajes tatuajes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tatuajes.Add(tatuajes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tatuajes.TattooId }, tatuajes);
        }

        // DELETE: api/Tatuajes/5
        [ResponseType(typeof(Tatuajes))]
        public async Task<IHttpActionResult> DeleteTatuajes(int id)
        {
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            if (tatuajes == null)
            {
                return NotFound();
            }

            db.Tatuajes.Remove(tatuajes);
            await db.SaveChangesAsync();

            return Ok(tatuajes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TatuajesExists(int id)
        {
            return db.Tatuajes.Count(e => e.TattooId == id) > 0;
        }
    }
}