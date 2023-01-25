using BuildWeek_Gruppo3_Clinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BuildWeek_Gruppo3_Clinica.Controllers
{
    public class UtenteController : Controller
    {
        ModelDBContext db = new ModelDBContext();
        // GET: Utente
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( Utente u)
        {
            string username = u.Username;
            string password = u.Password;

            var user = db.Utente.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ViewBag.Errore = "Username e/o Password errati";
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}