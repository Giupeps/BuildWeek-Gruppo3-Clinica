using BuildWeek_Gruppo3_Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildWeek_Gruppo3_Clinica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetAnimalByMC(string MC)
        {
            ModelDBContext db = new ModelDBContext();

            AnimaliJson aj = new AnimaliJson();

            Anagr_Animale a = db.Anagr_Animale.Where(x => x.NrMicrochip == MC).Include(x => x.Tipologia).Include(x => x.Visite).FirstOrDefault();

            if (a == null)
            {
                ViewBag.msgEmpty = "Non è stato rilevato alcun Microchip";
            }
            else {
                aj.Nome = a.Nome;
                aj.NrMicrochip = a.NrMicrochip;
                aj.Foto = a.Foto;
                aj.Colore = a.Colore;
                aj.Razza = a.Tipologia.Animale + " " + a.Tipologia.Razza;
            }


            return Json(aj, JsonRequestBehavior.AllowGet);
        }
    }
}