using System.Text;
using Microsoft.AspNetCore.Mvc;
using Showcase_Profielpagina.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Showcase_Profielpagina.Controllers;

public class ContactController : Controller
{
    private readonly HttpClient _httpClient;
    public ContactController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7278");
    }
    
    //GET
    public ActionResult Me()
    {
        Contactform contactform = new Contactform();
        Console.WriteLine("hgello");
        contactform.Message = "Hello World!";
        return View(contactform);
    }
    
    // POST: ContactController
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Me(Contactform form)
    {
        Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
        if(!ModelState.IsValid)
        {
            Console.WriteLine("ggggggggggggg");
            
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            
            form.Message = "De ingevulde velden voldoen niet aan de gestelde voorwaarden";
            Console.WriteLine("Vieuwbag!!!!!!!!!!!!!!" +form.Message);
            return View(form);
        }

        Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var json = JsonConvert.SerializeObject(form, settings);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //Gebruik _httpClient om een POST-request te doen naar ShowcaseAPI die de Mail uiteindelijk verstuurt met Mailtrap (of een alternatief).
        //Verstuur de gegevens van het ingevulde formulier mee aan de API, zodat dit per mail verstuurd kan worden naar de ontvanger.
        //Hint: je kunt dit met één regel code doen. Niet te moeilijk denken dus. :-)
        //Hint: vergeet niet om de mailfunctionaliteit werkend te maken in ShowcaseAPI > Controllers > MailController.cs,
        //      nadat je een account hebt aangemaakt op Mailtrap (of een alternatief).

        
        Console.WriteLine("aaaaahhhhhhhhhhhhhhhhh");
        HttpResponseMessage response = await _httpClient.PostAsync("/api/mail", content);

        
        Console.WriteLine("aaaaabbbbbbbbbbbb");
        if(!response.IsSuccessStatusCode)
        {
            form.Message = "Er is iets misgegaan";
            Console.WriteLine("Vieuwbag!"+response.Content.ReadAsStringAsync().Result);
            return View(form);
        }

        form.Message = "Het contactformulier is verstuurd";
        
        Console.WriteLine("Vieuwbag!!!"+form.Message);
        return View(form);
    }
}