using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_pimWEB.Controllers
{
	public class FolhaPagamentoController : Controller
	{
		// GET: FolhaPagamentoController
		public ActionResult Index()
		{
			return View();
		}

		// GET: FolhaPagamentoController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: FolhaPagamentoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FolhaPagamentoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FolhaPagamentoController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: FolhaPagamentoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FolhaPagamentoController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: FolhaPagamentoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
