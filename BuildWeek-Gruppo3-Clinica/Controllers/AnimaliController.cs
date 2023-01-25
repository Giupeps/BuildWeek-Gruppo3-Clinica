using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

        // Pagina Ricerca Ricoveri
        public ActionResult RicoveriAttivi()
        {
            return View(db.Tipologia.ToList());
        }

        // JQuery
        public JsonResult GetAnimalByType( string[] selezione)
        {
            List<AnimaliJson> aj = new List<AnimaliJson>();
   
            foreach (var i in selezione)
            {
                int Id = Convert.ToInt32(i);

                List<Anagr_Animale> an = db.Anagr_Animale.Where(x => x.IdTipo == Id && x.Proprietario == false).Include( x => x.Tipologia ).ToList();

                foreach (var item in an)
                {
                    AnimaliJson j = new AnimaliJson { Nome = item.Nome, Foto = item.Foto, Razza = item.Tipologia.Razza, DataNascita = item.DataNascita.ToShortDateString(), IdAnimale = item.IdAnimale, DataRicovero = item.DataNascita };
                    j.Giorni = j.GetDate();
                    aj.Add(j);
                }
            }

            return Json(aj, JsonRequestBehavior.AllowGet);
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
            ViewBag.IdTipo = Tipologia.SelectListTipo;

            return View();
        }

        // POST: Animali/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anagr_Animale anagr_Animale)
        {
            if (ModelState.IsValid)
            {
                if (anagr_Animale.FileFoto != null) {
                string Path = Server.MapPath("/Content/Assets/Img/" + anagr_Animale.FileFoto.FileName);
                anagr_Animale.FileFoto.SaveAs(Path);
                anagr_Animale.Foto = anagr_Animale.FileFoto.FileName;
                }
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
        public ActionResult Edit(Anagr_Animale anagr_Animale)
        {
            if (ModelState.IsValid == true && anagr_Animale.FileFoto !=null)
            {
                string Path = Server.MapPath("~/Content/Assets/Img/" + anagr_Animale.FileFoto.FileName);
                anagr_Animale.FileFoto.SaveAs(Path);
                anagr_Animale.Foto = anagr_Animale.FileFoto.FileName;
                db.Entry(anagr_Animale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }else if (ModelState.IsValid)
            {
                Anagr_Animale animaleDB = db.Anagr_Animale.Find(anagr_Animale.IdAnimale);
                animaleDB.Nome = anagr_Animale.Nome;
                animaleDB.IdTipo = anagr_Animale.IdTipo;
                animaleDB.Colore = anagr_Animale.Colore;
                animaleDB.DataNascita = anagr_Animale.DataNascita;
                animaleDB.NrMicrochip = anagr_Animale.NrMicrochip;
                animaleDB.Proprietario = anagr_Animale.Proprietario;
                animaleDB.NomeProprietario = anagr_Animale.NomeProprietario;
                animaleDB.Indirizzo = anagr_Animale.Indirizzo;
                animaleDB.Contatto = anagr_Animale.Contatto;
                animaleDB.Foto = db.Anagr_Animale.Find(anagr_Animale.IdAnimale).Foto;
                db.Entry(animaleDB).State = EntityState.Modified;
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

        public JsonResult GetDetails(int id)
        {
            var visite = db.Visite.Where(v => v.IdAnimale == id).ToList();
            return Json( visite, JsonRequestBehavior.AllowGet);
        }


    }
}
