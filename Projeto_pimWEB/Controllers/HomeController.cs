using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Filter;
using Projeto_pimWEB.Helper;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models;
using System.Diagnostics;

namespace Projeto_pimWEB.Controllers
{
    [UserFilterON]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISessao session)
        {
            _logger = logger;
 
        }

        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}