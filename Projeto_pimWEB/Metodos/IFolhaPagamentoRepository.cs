using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public interface IFolhaPagamentoRepository
    {
        public FolhaPagamento CreateFolha(FolhaPagamento entity);
        public FolhaPagamento GetFolhaPagamento(int id);
        public List<FolhaPagamento> GetAllFolhaPagamento_FK(int id);
        public List<FolhaPagamento> GetAllFolhas();


		public Beneficio CreateBeneficio(Beneficio entity);
        public Desconto CreateDesconto(Desconto entity);
        public List<Desconto> GetAllDescontos(int id);

    }
}
