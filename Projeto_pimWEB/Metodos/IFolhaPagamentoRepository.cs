using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public interface IFolhaPagamentoRepository
    {
        public FolhaPagamento CreateFolha(FolhaPagamento entity);
        public FolhaPagamento GetFolhaPagamento(int id);
        
        public Beneficio CreateBeneficio(Beneficio entity);
        public Desconto CreateBeneficio(Desconto entity);

    }
}
