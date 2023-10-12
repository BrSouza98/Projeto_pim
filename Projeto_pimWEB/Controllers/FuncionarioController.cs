using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly I_FuncionarioMetodos _metodos;

        public FuncionarioController(I_FuncionarioMetodos metodos)
        {
            _metodos = metodos;
        }

        public IActionResult Registro()
        {
            var func = _metodos.Listar_func();
            return View(func);
        }

        public IActionResult Registro_depen(int id)
        {
            var dependente = _metodos.Listar_depen(id);
            return View(dependente);
        }

        public IActionResult Detalhes(int id)
        {
            var funcionario = _metodos.retur_funcionario(id);
            List<Dependente> dependentes = _metodos.Listar_depen(id);

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
            _metodos.Adicionar(func);
            return RedirectToAction("Index");
        }

        public IActionResult Create_depen(int id)
        {
            Dependente dependente = new Dependente();
            dependente.funcionario = _metodos.retur_funcionario(id);
            return View(dependente);
        }

        [HttpPost]
        public IActionResult Create_depen(int id, Dependente dependente)
        {
            dependente.funcionario = _metodos.retur_funcionario(id);
            _metodos.Create_depe(dependente);
            return RedirectToAction("Registro");
        }

    }
}
