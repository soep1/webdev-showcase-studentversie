using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Showcase_Profielpagina.Models;

namespace Showcase_Profielpagina.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Topteam()
        {
            return View();
        }
    }
}
