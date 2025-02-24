using Microsoft.AspNetCore.Mvc;
using ShowcaseAPI.Models;
using System.Net;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        // POST api/<MailController>
        [HttpPost]
        public ActionResult Post([Bind("Email, Subject, Content")] Contactform form)
        {
            //Op brightspace staan instructies over hoe je de mailfunctionaliteit werkend kunt maken:
            //Project Web Development > De showcase > Week 2: contactpagina (UC2) > Hoe verstuur je een mail vanuit je webapplicatie met Mailtrap?
            
            
            // Looking to send emails in production? Check out our Email API/SMTP product!
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("28e73d0a7206d8", "6e327052c95118"),
                EnableSsl = true
            };
            client.Send(form.Email, "janvandenpol11@gmail.com", form.Subject, "Sent by: "+form.FirstName+" "+form.LastName+"\nphone number: "+form.Phone+"\n\n"+form.Content);
            System.Console.WriteLine("Sent");
            
            return Ok();
        }
    }
}
