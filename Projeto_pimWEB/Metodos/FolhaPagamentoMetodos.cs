using Projeto_pimWEB.Data;
using Projeto_pimWEB.Models.Classes;
using System.Drawing;

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
		

		public List<FolhaPagamento> GetAllFolhaPagamento_FK(int id)
		{
			return _mdbc.folhaPagamento.Where(i => i.id_cod_func == id).ToList();
		}

		public List<FolhaPagamento> GetAllFolhas()
		{
			return _mdbc.folhaPagamento.ToList();
		}

		public FolhaPagamento GetFolhaPagamento_PK(int id)
		{
			return _mdbc.folhaPagamento.FirstOrDefault(i => i.id_cod_FP == id);
		}
		
		// Metodos para beneficos.
		public Beneficio CreateBeneficio(Beneficio entity)
		{
			_mdbc.beneficios.Add(entity);
			this._mdbc.SaveChanges();
			return entity;
        }

		public List<Beneficio> GetAllBeneficiosFK(int id)
		{
			return _mdbc.beneficios.Where(i => i.id_cod_Ben == id).ToList();
		}

		// Metodos para Descontos.
		public Desconto CreateDesconto(Desconto entity)
		{
			_mdbc.descontos.Add(entity);
			this._mdbc.SaveChanges();
			return entity;
		}

        public List<Desconto> GetAllDescontosFK(int id)
        {
			return _mdbc.descontos.Where(i => i.Funcionarioid_cod_func == id).ToList();
        }
	}
}
