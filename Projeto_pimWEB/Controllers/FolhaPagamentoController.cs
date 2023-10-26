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

		public IActionResult DescontosBeneficiosAdd(int id)
		{
			ViewBag.idFunc = id;
			return View();
		}

		public IActionResult CreatFolhaView(int id, FolhaPagamento folha)
		{
			Funcionario func = _metodos.GetFuncionario(id);
			func.dependentes = _metodos.GetAllDependentesFK(id);

			folha.Funcionario = func;
			folha.Descontos = _metodosFolha.GetAllDescontosFK(id);
			folha.Beneficios = _metodosFolha.GetAllBeneficiosFK(id);


			folha.Jornada = Calculos.CalcJornada(func.HoraSemanais);
			folha.SalarioBruto = Math.Round(Calculos.CalcSalarioBruto(func.Salario, folha.Beneficios, folha.Descontos, folha.Jornada, folha.HorasExtras, folha.Bonus, folha.Faltas, folha.Atrasos));
			folha.Inss = Math.Round(Calculos.CalcINSS(folha.SalarioBruto), 2);
			folha.Irrf = Math.Round(Calculos.CalcIRRF(folha.SalarioBruto, folha.Inss, func.dependentes), 2);
			folha.Fgts = Math.Round(Calculos.CalcFGTS(folha.SalarioBruto), 2);
			folha.SalarioLiquido = Math.Round(Calculos.CalcSalarioLiquido(folha.Inss, folha.Irrf, folha.SalarioBruto), 2);
			folha.DataEmissao = DateTime.Now.ToString("dd/MM/yyyy");
			folha.MesAnoRef = DateTime.Now.ToString("MM/yyyy");

			return View(folha);
		}

		[HttpPost]
		public IActionResult CreatFolha(FolhaPagamento fp, int id)
		{
			
			_metodosFolha.CreateFolha(fp);
			return RedirectToAction("Registro", "Funcionario");
		}


		public IActionResult CreateDescontos(int id)
		{
			Desconto desconto = new Desconto();
			desconto.Funcionario = _metodos.GetFuncionario(id);


			return View(desconto);

		}

		[HttpPost]
		public IActionResult CreateDescontos(int id, Desconto desconto)
		{
			
			_metodosFolha.CreateDesconto(desconto);
			return RedirectToAction("CreatFolhaView", new { action = "CreatFolhaView", id });
			

		}


		public IActionResult CreateBeneficios(int id)
		{
			Beneficio beneficio = new Beneficio();
			beneficio.Funcionario = _metodos.GetFuncionario(id);
			return View(beneficio);
		}

		[HttpPost]
		public IActionResult CreateBeneficios(int id, Beneficio beneficio)
		{

			_metodosFolha.CreateBeneficio(beneficio);
			return RedirectToAction("CreatFolhaView", new { action = "CreatFolhaView", id });
		}

		public IActionResult RegistroFolha_Func(int id)
		{
			List<FolhaPagamento> folhas = _metodosFolha.GetAllFolhaPagamento_FK(id);
			List<Desconto> descontos = _metodosFolha.GetAllDescontosFK(id);
			List<Beneficio> beneficios = _metodosFolha.GetAllBeneficiosFK(id);

			List<FolhaPagamento> Allfolhas = new List<FolhaPagamento>();

			foreach(var folha in folhas)
			{
				if(descontos != null && descontos.Any())
				{
					foreach (var desconto in descontos)
					{
						if (beneficios != null && beneficios.Any())
						{
							foreach (var beneficio in beneficios )
							{
								if (folha.id_cod_func == desconto.Funcionarioid_cod_func && folha.id_cod_func == beneficio.Funcionarioid_cod_func)
								{
									folha.desconto = desconto;
									folha.beneficio = beneficio;
									Allfolhas.Add(folha);
								}
							}
						}
						else
						{
							folha.desconto = desconto;
							Allfolhas.Add(folha);
						}
					}
				}
				else
				{
					if(beneficios != null && beneficios.Any())
					{
						foreach(var beneficio in beneficios)
						{
							if (folha.id_cod_func == beneficio.Funcionarioid_cod_func)
							{
								
								folha.beneficio = beneficio;
								Allfolhas.Add(folha);
							}
						}
					}
				}
				
			}

			Funcionario func = _metodos.GetFuncionario(id);
			func.Folhas = Allfolhas;

			return View(func);
		}

		public IActionResult Registro_Folhas()
		{
			List<FolhaPagamento> folha = _metodosFolha.GetAllFolhas();
			List<Funcionario> func = _metodos.GetAllFuncionarios();

			List<FolhaPagamento> ListaFinais = new List<FolhaPagamento>();

			foreach(FolhaPagamento fp in folha)
			{
				foreach(Funcionario funcionario in func)
				{
					if(fp.id_cod_func == funcionario.id_cod_func)
					{
						fp.Funcionario = funcionario;
						ListaFinais.Add(fp);
					}
				}
			}

			return View(ListaFinais);
		}
	}
}
