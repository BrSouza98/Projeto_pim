using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Data;
using Projeto_pimWEB.Filter;
using Projeto_pimWEB.Metodos;
using Projeto_pimWEB.Metodos.Calculos;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Controllers
{
	[UserFilterON]
	public class FolhaPagamentoController : Controller
	{

		private readonly IFuncionarioRepository _metodos;
		private readonly IFolhaPagamentoRepository _metodosFolha;

		public FolhaPagamentoController(IFuncionarioRepository metodo, IFolhaPagamentoRepository metodoFolha)
		{
			_metodos = metodo;
			_metodosFolha = metodoFolha;
		}


		public IActionResult CreatFolha(int id)
		{
			// Lista de beneficios
			// Lista de descontos

			Funcionario func = _metodos.GetFuncionario(id);
			func.dependentes = _metodos.GetAllDependentesFK(id);

			FolhaPagamento folha = new FolhaPagamento();
			folha.Funcionario = func;

			folha.Jornada = Calculos.CalcJornada(func.HoraSemanais);
			folha.SalarioBruto = Calculos.CalcSalarioBruto(func.Salario, folha.Beneficios, folha.Jornada);
			folha.Inss = Calculos.CalcINSS(folha.SalarioBruto);
			folha.Irrf = Calculos.CalcIRRF(folha.SalarioBruto, folha.Inss, func.dependentes);
			folha.Fgts = Calculos.CalcFGTS(folha.SalarioBruto);
			folha.SalarioLiquido = Calculos.CalcSalarioLiquido(folha.Inss, folha.Irrf, folha.SalarioBruto);
			folha.DataEmissao = DateTime.Now.ToString("dd/MM/yyyy");
			folha.MesAnoRef = DateTime.Now.ToString("MM/yyyy");

			return View(folha);
		}

		[HttpPost]
		public IActionResult CreatFolha(FolhaPagamento fp)
		{
			_metodosFolha.CreateFolha(fp);
			return RedirectToAction("Registro", "Funcionario");
		}


	}
}
