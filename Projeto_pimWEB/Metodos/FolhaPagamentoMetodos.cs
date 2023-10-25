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

		public FolhaPagamento GetFolhaPagamento(int id)
		{
			return _mdbc.folhaPagamento.FirstOrDefault(i => i.id_cod_FP == id);
		}

		// Metodos para descontos e beneficos.
		public Beneficio CreateBeneficio(Beneficio entity)
		{
			_mdbc.beneficios.Add(entity);
			this._mdbc.SaveChanges();
			return entity;
		}

		public Desconto CreateBeneficio(Desconto entity)
		{
			_mdbc.descontos.Add(entity);
			this._mdbc.SaveChanges();
			return entity;
		}

		
	}
}
