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



        public JsonResult GetAnimalByMC(string MC)
        {
            ModelDBContext db = new ModelDBContext();

            AnimaliJson aj = new AnimaliJson();

            Anagr_Animale a = db.Anagr_Animale.Where(x => x.NrMicrochip == MC).Include(x => x.Tipologia).Include(x => x.Visite).FirstOrDefault();


            if (a != null) {         
            {
                    aj.IdAnimale = a.IdAnimale;
                    aj.Nome = a.Nome;
                    aj.NrMicrochip = a.NrMicrochip;
                    aj.Foto = a.Foto;
                    aj.Colore = a.Colore;
                    aj.Razza = a.Tipologia.Animale + " " + a.Tipologia.Razza;
            };
            }
            else { aj.Nome = null; }



            return Json(aj, JsonRequestBehavior.AllowGet);
        }
    }
}