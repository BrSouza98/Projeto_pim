using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? SessionUser = HttpContext.Session.GetString("SessionOn");

            if(string.IsNullOrEmpty(SessionUser) )  return null; 

            Funcionario? func = JsonConvert.DeserializeObject<Funcionario>(SessionUser);
            return View(func);
        }
    }
}
