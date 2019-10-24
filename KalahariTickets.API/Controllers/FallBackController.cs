using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace KalahariTickets.API.Controllers
{
    public class FallBackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "index.html"), "text/HTML");
        }
    }
}