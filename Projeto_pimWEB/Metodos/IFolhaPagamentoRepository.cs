using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public interface IFolhaPagamentoRepository
    {
        public FolhaPagamento CreateFolha(FolhaPagamento entity);
        public FolhaPagamento GetFolhaPagamento_PK(int id);
        public List<FolhaPagamento> GetAllFolhaPagamento_FK(int id);
        public List<FolhaPagamento> GetAllFolhas();


        // Beneficios
		public Beneficio CreateBeneficio(Beneficio entity);
        public List<Beneficio> GetAllBeneficiosFK(int id);
        public Beneficio GetBeneficio_PK(int id);
        public bool Delete_beneficio(int id);

		// Descontos
		public Desconto CreateDesconto(Desconto entity);
        public List<Desconto> GetAllDescontosFK(int id);
        public Desconto GetDescontos_PK(int id);
        public bool Delete_desconto (int id);


    }
}
