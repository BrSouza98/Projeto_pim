using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public interface IFolhaPagamentoRepository
    {
        public List<FolhaPagamento> ListarFolhas();
        public FolhaPagamento GetFolha(int id);
        public FolhaPagamento CreateFolha(FolhaPagamento entity);
        public FolhaPagamento UpdateFolha(FolhaPagamento entity);
    }
}
