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
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Alunos()
        {
            return View();
        }

    }
}