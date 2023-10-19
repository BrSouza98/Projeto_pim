using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Helper
{
    public interface ISessao
    {
        void CreatSession_User(Funcionario func);
        void RemoveSession_User();
        Funcionario GetSession();
    }
}
