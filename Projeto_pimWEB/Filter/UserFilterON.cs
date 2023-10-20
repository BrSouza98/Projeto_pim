using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Projeto_pimWEB.Models.Classes;
using System.Drawing;

namespace Projeto_pimWEB.Filter
{
    public class UserFilterON : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string? SessionUser = context.HttpContext.Session.GetString("SessionOn");

            if(string.IsNullOrEmpty(SessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login"}, {"action", "login" } });
            }
            else
            {
                Funcionario? func = JsonConvert.DeserializeObject<Funcionario>(SessionUser);
                if (func == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "login" } });
                }
            }

            base.OnActionExecuted(context);
        }

    }
}
