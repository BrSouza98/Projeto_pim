using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_pimWEB.Data;
using Projeto_pimWEB.Filter;
using Projeto_pimWEB.Metodos;
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
			Funcionario func = _metodos.GetFuncionario(id);
            FolhaPagamento folha = new FolhaPagamento();
			folha.Funcionario = func;
			folha.Funcionario.dependentes = _metodos.GetAllDependentesFK(id);
			folha.DataEmissao = DateTime.Now.ToString("dd/MM/yyyy");
			folha.MesAnoRef = DateTime.Now.ToString("MM/yyyy");
			folha.CalcJornada(func.HoraSemanais);
			folha.CalcSalarioBruto(func.Salario);
			folha.CalcINSS(folha.SalarioBruto);
			folha.CalcIRRF(folha.SalarioBruto, folha.Inss, func.dependentes);
			folha.CalcSalarioLiquido(folha.Inss, folha.Irrf, folha.SalarioBruto);
			folha.Fgts = (folha.SalarioBruto * 0.08);

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
