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

		public FolhaPagamentoController(IFuncionarioRepository metodo)
		{
			_metodos = metodo;
		}
        

		public IActionResult Exibir(int id)
		{
			Funcionario func = _metodos.GetFuncionario(id);
			func.dependentes = _metodos.GetAllDependentesFK(id);
			FolhaPagamento fp = new FolhaPagamento();
			fp.Preencher_FolhaPagamento(func);
			return View(fp);
		}



	}
}
