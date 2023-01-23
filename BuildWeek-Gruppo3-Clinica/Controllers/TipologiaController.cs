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
    public class TipologiaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Tipologia
        public ActionResult Index()
        {
            return View(db.Tipologia.ToList());
        }


        // GET: Tipologia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipologia/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tipologia tipologia)
        {
            if (ModelState.IsValid)
            {
                db.Tipologia.Add(tipologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipologia);
        }

        // GET: Tipologia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipologia tipologia = db.Tipologia.Find(id);
            if (tipologia == null)
            {
                return HttpNotFound();
            }
            return View(tipologia);
        }

        // POST: Tipologia/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tipologia tipologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipologia);
        }

        // GET: Tipologia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipologia tipologia = db.Tipologia.Find(id);
            if (tipologia == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", tipologia);
        }

        // POST: Tipologia/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Delete(int id)
        {
            Tipologia tipologia = db.Tipologia.Find(id);
            db.Tipologia.Remove(tipologia);
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
