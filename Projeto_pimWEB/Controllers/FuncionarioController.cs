using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Filter;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models.Classes;
using System;

namespace Projeto_pimWEB.Controllers
{
    [UserFilterON]
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
            funcionario.dependentes = _metodos.GetAllDependentesFK(id);

            return View(funcionario);

        }

        public IActionResult Detalhes(int id)
        {
            Funcionario funcionario = _metodos.GetFuncionario(id);
            funcionario.dependentes = _metodos.GetAllDependentesFK(id);

            return View(funcionario);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario func)
        {
            try
            {
				if (ModelState.IsValid)
				{
					_metodos.CreateFunc(func);
					TempData["MensagemSucesso"] = $"Sucesso ao cadastrar: {func.Nome}";
					return RedirectToAction("Registro");
				}

				return View(func);
			}
            catch (Exception ex)
            {
				TempData["MensagemErro"] = $"Não foi possivel cadastrar: {func.Nome}." +
                    $"Mais detalhes: {ex.Message}";
				return RedirectToAction("Registro");
			}
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
            try
            {
                if (ModelState.IsValid) 
                {
                    dependente.funcionario = _metodos.GetFuncionario(id);
                    _metodos.CreateDep(dependente);
                    TempData["MensagemSucesso"] = $"Sucesso ao cadastrar: {dependente.Nome}";
                    return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
                }
                return View(dependente);
            }

            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar: {dependente.Nome}." +
                    $"Mais detalhes: {ex.Message}";
                return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
            }
            
        }

        public IActionResult Editar(int id)
        {
            var funcionario = _metodos.GetFuncionario(id);
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Alterar(Funcionario func)
        {
            if(ModelState.IsValid)
            {
				_metodos.UpdateFunc(func);
				return RedirectToAction("Registro");
			}

            return View("Editar", func);
        }

        public IActionResult Editar_depen(int id)
        {
            var dependente = _metodos.GetDependente(id);
            return View(dependente);
        }

        [HttpPost]
        public IActionResult Alterar_depen(Dependente dependente, int id)
        {
            _metodos.UpdateDep(dependente);
            return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
        }

        public IActionResult Desativar(int id)
        {
            _metodos.Desativar(id);
            return RedirectToAction("Registro");
        }

        public IActionResult Deletar_Dependente(int id)
        {
            Dependente dependente = _metodos.GetDependente(id);

            _metodos.Delete_Depen(id);
            return RedirectToAction("Registro_depen", new { action = "Registro_depen", id = dependente.funcionarioid_cod_func });
        }
    }
}
