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
    public class AnimaliController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Animali
        public ActionResult Index()
        {
            var anagr_Animale = db.Anagr_Animale.Include(a => a.Tipologia);
            return View(anagr_Animale.ToList());
        }

        // GET: Animali/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagr_Animale anagr_Animale = db.Anagr_Animale.Find(id);
            if (anagr_Animale == null)
            {
                return HttpNotFound();
            }
            return View(anagr_Animale);
        }

        // GET: Animali/Create
        public ActionResult Create()
        {
            ViewBag.IdTipo = new SelectList(db.Tipologia, "idTipo", "Animale");
            return View();
        }

        // POST: Animali/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAnimale,Nome,IdTipo,Colore,DataNascita,NrMicrochip,Proprietario,NomeProprietario,Indirizzo,Contatto,Foto,FileFoto")] Anagr_Animale anagr_Animale)
        {
            if (ModelState.IsValid)
            {
                string Path = Server.MapPath("~/Content/Assets/Img/" + anagr_Animale.FileFoto.FileName);
                anagr_Animale.FileFoto.SaveAs(Path);
                anagr_Animale.Foto = anagr_Animale.FileFoto.FileName;
                db.Anagr_Animale.Add(anagr_Animale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipo = new SelectList(db.Tipologia, "idTipo", "Animale", anagr_Animale.IdTipo);
            return View(anagr_Animale);
        }

        // GET: Animali/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagr_Animale anagr_Animale = db.Anagr_Animale.Find(id);
            if (anagr_Animale == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipo = new SelectList(db.Tipologia, "idTipo", "Animale", anagr_Animale.IdTipo);
            return View(anagr_Animale);
        }

        // POST: Animali/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAnimale,Nome,IdTipo,Colore,DataNascita,NrMicrochip,Proprietario,NomeProprietario,Indirizzo,Contatto,Foto")] Anagr_Animale anagr_Animale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anagr_Animale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipo = new SelectList(db.Tipologia, "idTipo", "Animale", anagr_Animale.IdTipo);
            return View(anagr_Animale);
        }

        // GET: Animali/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anagr_Animale anagr_Animale = db.Anagr_Animale.Find(id);
            if (anagr_Animale == null)
            {
                return HttpNotFound();
            }
            return View(anagr_Animale);
        }

        // POST: Animali/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anagr_Animale anagr_Animale = db.Anagr_Animale.Find(id);
            db.Anagr_Animale.Remove(anagr_Animale);
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
