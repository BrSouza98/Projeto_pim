using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _metodos;

        public FuncionarioController(IFuncionarioRepository metodos)
        {
            _metodos = metodos;
        }

        public IActionResult Registro()
        {
            List<Funcionario> func = _metodos.GetAllFuncionarios();
            return View(func);
        }

        public IActionResult Registro_depen(int id)
        {

            Funcionario funcionario = _metodos.GetFuncionario(id);
            funcionario.dependentes = _metodos.GetAllDependentes(id);

            return View(funcionario.dependentes);

        }

        public IActionResult Detalhes(int id)
        {
            Funcionario funcionario = _metodos.GetFuncionario(id);
            List<Dependente> dependentes = _metodos.GetAllDependentes(id);

            ViewBag.dependentes = dependentes;
            return View(funcionario);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario func)
        {
            _metodos.CreateFunc(func);
            return RedirectToAction("Registro");
        }

        public IActionResult Create_depen(int id)
        {
            var dependente = new Dependente();
            dependente.funcionario = _metodos.GetFuncionario(id);
            return View(dependente);
        }

        [HttpPost]
        public IActionResult Create_depen(int id, Dependente dependente)
        {
            dependente.funcionario = _metodos.GetFuncionario(id);
            _metodos.CreateDep(dependente);
            return RedirectToAction("Registro_depen");
        }

        public IActionResult Editar(int id)
        {
            var funcionario = _metodos.GetFuncionario(id);

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Alterar(Funcionario func)
        {
            _metodos.UpdateFunc(func);
            return RedirectToAction("Registro");
        }

        public IActionResult Editar_depen(int id)
        {
                
            return View(_metodos.GetDependente(id));
        }

        [HttpPost]
        public IActionResult Alterar_depen(Dependente dependente, int id)
        {
            _metodos.UpdateDep(dependente);
            return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
        }
    }
}
