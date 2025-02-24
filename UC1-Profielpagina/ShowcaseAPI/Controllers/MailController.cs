using Microsoft.AspNetCore.Mvc;
using ShowcaseAPI.Models;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

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
                //mailtrap
            // // Looking to send emails in production? Check out our Email API/SMTP product!
            // var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            // {
            //     Credentials = new NetworkCredential("28e73d0a7206d8", "6e327052c95118"),
            //     EnableSsl = true
            // };
            // client.Send(form.Email, "janvandenpol11@gmail.com", form.Subject, "Sent by: "+form.FirstName+" "+form.LastName+"\nphone number: "+form.Phone+"\n\n"+form.Content);
            
                //sendgrid
                Execute(form);
            
            System.Console.WriteLine("Sent");
            
            return Ok();
        }
        
            //sendgrid
        static async Task Execute(Contactform form)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("janvandenpol11@gmail.com", form.FirstName+" "+form.LastName);
            var subject = form.Subject;
            var to = new EmailAddress("janvandenpol11@gmail.com", "Jan van den Pol");
            var plainTextContent = "Sent by: "+form.FirstName+" "+form.LastName+"\nphone number: "+form.Phone+"\n\n"+form.Content;
            var htmlContent = $"<strong>{"Sent by: "+form.FirstName+" "+form.LastName}</strong>" +
                                    $"<strong>{"  Phone number: "+form.Phone}</strong>" +
                                    $"<strong>{"  Email: "+form.Email}</strong>" +
                                    $"<p>{form.Content}</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
