using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admGemio.Models;

namespace admGemio.Controllers
{
    public class gemiosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: gemios
        [Authorize]
    }
        public ActionResult Index()
        {
            return View(db.gemios.ToList());
        }

    // GET: gemios/Details/5
    [Authorize]
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gemio gemio = db.gemios.Find(id);
            if (gemio == null)
            {
                return HttpNotFound();
            }
            return View(gemio);
        }

    // GET: gemios/Create
    [Authorize]
    public ActionResult Create()
        {
            return View();
        }

    // POST: gemios/Create
    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
    // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize]
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gemioID,Friendofgemio,Place,Email,Birthdate")] gemio gemio)
        {
            if (ModelState.IsValid)
            {
                db.gemios.Add(gemio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gemio);
        }

    // GET: gemios/Edit/5
    [Authorize]
    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gemio gemio = db.gemios.Find(id);
            if (gemio == null)
            {
                return HttpNotFound();
            }
            return View(gemio);
        }

    // POST: gemios/Edit/5
    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
    // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gemioID,Friendofgemio,Place,Email,Birthdate")] gemio gemio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gemio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gemio);
        }

    // GET: gemios/Delete/5
    [Authorize]
    public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gemio gemio = db.gemios.Find(id);
            if (gemio == null)
            {
                return HttpNotFound();
            }
            return View(gemio);
        }

    // POST: gemios/Delete/5
    [Authorize]
    [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gemio gemio = db.gemios.Find(id);
            db.gemios.Remove(gemio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
