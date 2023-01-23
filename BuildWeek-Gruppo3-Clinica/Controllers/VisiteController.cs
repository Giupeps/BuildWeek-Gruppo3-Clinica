using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuildWeek_Gruppo3_Clinica.Models;

namespace BuildWeek_Gruppo3_Clinica.Controllers
{
    public class VisiteController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Visite
        public ActionResult Index(int? id)
        {
            var visite = db.Visite.Where( v => v.IdAnimale == id).ToList();
            return View(visite);
        }

        // GET Animale come PartialView
        public ActionResult PartialViewSingleAnimal(int? id)
        {
            Anagr_Animale animal = db.Anagr_Animale.Find(id);         
            return View(animal);
        }

        // GET: Visite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            return View(visite);
        }

        // GET: Visite/Create
        public ActionResult Create()
        {
            ViewBag.IdAnimale = new SelectList(db.Anagr_Animale, "IdAnimale", "Nome");
            return View();
        }

        // POST: Visite/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVisita,IdAnimale,Data,Referto,Diagnosi")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                db.Visite.Add(visite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnimale = new SelectList(db.Anagr_Animale, "IdAnimale", "Nome", visite.IdAnimale);
            return View(visite);
        }

        // GET: Visite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAnimale = new SelectList(db.Anagr_Animale, "IdAnimale", "Nome", visite.IdAnimale);
            return View(visite);
        }

        // POST: Visite/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVisita,IdAnimale,Data,Referto,Diagnosi")] Visite visite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnimale = new SelectList(db.Anagr_Animale, "IdAnimale", "Nome", visite.IdAnimale);
            return View(visite);
        }

        // GET: Visite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visite visite = db.Visite.Find(id);
            if (visite == null)
            {
                return HttpNotFound();
            }
            return View(visite);
        }

        // POST: Visite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visite visite = db.Visite.Find(id);
            db.Visite.Remove(visite);
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
