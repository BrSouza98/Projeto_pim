using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Projeto_pimWEB.Filter;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Models.Classes;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.SqlClient;

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
			catch(DbUpdateException ex)
			{

				if (ex.InnerException is SqliteException sqlite )
				{
					switch (sqlite.SqliteErrorCode)
					{
						case 19: TempData["MensagemErro"] = $"O {func.Email} já esta cadastrado.\n" +
								 $"Mais detalhes: {ex.InnerException.Message}";

								 return RedirectToAction("Registro");
					}

				}
				
				TempData["MensagemErro"] = $"Não foi possivel cadastrar: {func.Nome}.\n" +
					$"Mais detalhes: {ex.Message}";

				return RedirectToAction("Registro");

			}

			catch (Exception ex)
			{

				TempData["MensagemErro"] = $"Não foi possivel cadastrar: {func.Nome}.\n" +
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


				dependente.funcionario = _metodos.GetFuncionario(id);
				_metodos.CreateDep(dependente);
				TempData["MensagemSucesso"] = $"Sucesso ao cadastrar: {dependente.Nome}";
				return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });


			}

			catch (Exception ex)
			{
				TempData["MensagemErro"] = $"Não foi possivel cadastrar: {dependente.Nome}.\n" +
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
			try
			{
				if(ModelState.IsValid)
				{
					_metodos.UpdateFunc(func);
					TempData["MensagemSucesso"] = $"Dados alterados com sucesso do(a): {func.Nome}";
					return RedirectToAction("Registro");
				}
				return View("Editar", func);
			}
			catch (Exception ex)
			{
				TempData["MensagemErro"] = $"Ops, erro na alteração dos dados do(a): {func.Nome}.\n" +
					$"Mais detalher: {ex.Message}";
				return RedirectToAction("Registro");
			}

		}

		public IActionResult Editar_depen(int id)
		{
			var dependente = _metodos.GetDependente(id);
			return View(dependente);
		}

		[HttpPost]
		public IActionResult Alterar_depen(Dependente dependente, int id)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_metodos.UpdateDep(dependente);
					TempData["MensagemSucesso"] = $"Dados do(a): {dependente.Nome} alterados com sucesso.";
					return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
				}
				return View("Editar_depen", id);
			}
			catch (Exception ex)
			{
				TempData["MensagemErro"] = $"Ops, erro na alteração dos dados do(a) dependente: {dependente.Nome}.\n" +
					$"Mais detalher: {ex.Message}";
				return RedirectToAction("Registro_depen", new { action = "Registro_depen", id });
			}

		}

		public IActionResult Desativar(int id)
		{
			try
			{
				var func = _metodos.Desativar(id);
				TempData["MensagemSucesso"] = $"Sucesso ao desativar o(a) funcionario(a): {func.Nome}";
				return RedirectToAction("Registro");
			}
			catch (Exception ex)
			{
				var func = _metodos.GetFuncionario(id);
				TempData["MensagemErro"] = $"Ops, houve um erro ao tentar desativar o(a) funcionario(a): {func.Nome}.\n" +
					$"Mais detalhes: {ex.Message}";
				return RedirectToAction("Registro");
			}
		}

		public IActionResult Deletar_Dependente(int id)
		{
			try
			{
				var dependente = _metodos.GetDependente(id);
				if (ModelState.IsValid)
				{
					bool apagado = _metodos.Delete_Depen(id);
					if (apagado)
					{
						TempData["MensagemSucesso"] = $"Dependente: {dependente.Nome} foi apagado com sucesso.";
						return RedirectToAction("Registro_depen", new { action = "Registro_depen", id = dependente.funcionarioid_cod_func });
					}
				}
				return RedirectToAction("Registro_depen", new { action = "Registro_depen", id = dependente.funcionarioid_cod_func });
			}
			catch (Exception ex)
			{
				var dependente = _metodos.GetDependente(id);
				TempData["MensagemErro"] = $"Ops, houve um erro ao tentar deletar o dependente:{dependente.Nome}.\n" +
					$"Mais detalhes: {ex.Message}";
				return RedirectToAction("Registro_depen", new { action = "Registro_depen", id = dependente.funcionarioid_cod_func });
			}

		}


	}
}
