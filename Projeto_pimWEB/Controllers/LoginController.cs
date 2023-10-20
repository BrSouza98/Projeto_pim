using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Helper;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models;

namespace Projeto_pimWEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISessao _session;

        private readonly IFuncionarioRepository _metodos;

        public LoginController(IFuncionarioRepository metodos, ISessao sessao)
        {
            _metodos = metodos;
            _session = sessao;
        }

        public IActionResult login()
        {

            if (_session.GetSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel login)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var funcionario = _metodos.GetFuncionarioEmail(login.email);

                    if(funcionario != null)
                    {
                        if(funcionario.Email.ToLower() == login.email.ToLower() && funcionario.Password.ToLower() == login.password.ToLower()) 
                        {

                            _session.CreatSession_User(funcionario);
                            return RedirectToAction("Index", "Home");
                        }


                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";

                }

                return View("login");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente, detalher do erro {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _session.RemoveSession_User();
            return RedirectToAction("login", "Login");

        }

    }
}
