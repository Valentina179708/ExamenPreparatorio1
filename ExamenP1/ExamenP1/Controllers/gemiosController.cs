using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExamenP1.Models;

namespace ExamenP1.Controllers
{
    public class gemiosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/gemios
        [Authorize]
        public IQueryable<gemio> Getgemios()
        {
            return db.gemios;
        }

        // GET: api/gemios/5
        [Authorize]
        [ResponseType(typeof(gemio))]
        public IHttpActionResult Getgemio(int id)
        {
            gemio gemio = db.gemios.Find(id);
            if (gemio == null)
            {
                return NotFound();
            }

            return Ok(gemio);
        }

        // PUT: api/gemios/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgemio(int id, gemio gemio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gemio.gemioID)
            {
                return BadRequest();
            }

            db.Entry(gemio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gemioExists(id))
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

        // POST: api/gemios
        [Authorize]
        [ResponseType(typeof(gemio))]
        public IHttpActionResult Postgemio(gemio gemio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gemios.Add(gemio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gemio.gemioID }, gemio);
        }

        // DELETE: api/gemios/5
        [Authorize]
        [ResponseType(typeof(gemio))]
        public IHttpActionResult Deletegemio(int id)
        {
            gemio gemio = db.gemios.Find(id);
            if (gemio == null)
            {
                return NotFound();
            }

            db.gemios.Remove(gemio);
            db.SaveChanges();

            return Ok(gemio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gemioExists(int id)
        {
            return db.gemios.Count(e => e.gemioID == id) > 0;
        }
    }
}