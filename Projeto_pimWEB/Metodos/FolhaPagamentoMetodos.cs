using Microsoft.EntityFrameworkCore.Diagnostics;
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

		public Beneficio GetBeneficio_PK(int id) 
		{
			return _mdbc.beneficios.FirstOrDefault(i => i.id_cod_Ben == id);
		}

		public bool Delete_beneficio(int id)
		{
			var beneficio = GetBeneficio_PK(id) ?? throw new Exception("Houve um erro para deletar o beneficio");

			_mdbc.beneficios.Remove(beneficio);
			_mdbc.SaveChanges();
			return true;
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

		public Desconto GetDescontos_PK(int id)
		{
			return _mdbc.descontos.FirstOrDefault(i => i.id_cod_des == id);
		}

		public bool Delete_desconto(int id)
		{
			var desconto = GetDescontos_PK(id) ?? throw new Exception("Houve um erro para deletar o desconto");

			_mdbc.descontos.Remove(desconto);
			_mdbc.SaveChanges();
			return true;

		}
	}
}
