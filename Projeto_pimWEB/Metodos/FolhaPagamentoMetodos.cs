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
			_mdbc.folhaPagamento.Add(fp);
			_mdbc.SaveChanges();
			return fp;
		}

		public FolhaPagamento GetFolha(int id)
		{
			return _mdbc.folhaPagamento.FirstOrDefault(i => i.id_cod_FP == id) ;
		}
		
		public List<FolhaPagamento> ListarFolhas(int id)
		{
            return _mdbc.folhaPagamento.Where(i => i.id_cod_func == id).ToList();
        }

		public FolhaPagamento UpdateFolha(FolhaPagamento newFp)
		{
			throw new NotImplementedException();
		}
	}
}
