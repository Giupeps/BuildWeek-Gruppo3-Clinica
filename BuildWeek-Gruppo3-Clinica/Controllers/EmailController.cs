using BuildWeek_Gruppo3_Clinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BuildWeek_Gruppo3_Clinica.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Contattaci()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contattaci(Email email)
        {
            MailAddress mittente = new MailAddress("buildweek@yahoo.com");
            MailAddress destinatario = new MailAddress(email.EmailMittente);

            MailMessage messaggio = new MailMessage();
            messaggio.Subject = "Email inviata dal sito";
            messaggio.Body = email.Messaggio;
            messaggio.From = mittente;
            messaggio.To.Add(destinatario);

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.yahoo.com";
            //client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("buildweek@yahoo.com", "giuseppeLeader22");
            client.Send(messaggio);

            return View();
        }
    }
}