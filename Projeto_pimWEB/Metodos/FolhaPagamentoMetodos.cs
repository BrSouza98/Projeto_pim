using Projeto_pimWEB.Data;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
	public class FolhaPagamentoMetodos : IFolhaPagamentoRepository
	{
		public readonly myDbContext _mdbc;
		public FolhaPagamentoMetodos(myDbContext myDbContext)
		{
			_mdbc = myDbContext;
		}
		public FolhaPagamento CreateFolha(FolhaPagamento fp)
		{
			_mdbc.Add(fp);
			return fp;
		}

		public FolhaPagamento GetFolha(int id)
		{
			return _mdbc.folhaPagamento.Where(i => i.id_cod_FP == id).FirstOrDefault();
		}

		public List<FolhaPagamento> ListarFolhas()
		{
			return _mdbc.folhaPagamento.ToList();
		}

		public FolhaPagamento UpdateFolha(FolhaPagamento newFp)
		{
			throw new NotImplementedException();
		}
	}
}
