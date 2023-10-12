using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public interface I_FuncionarioMetodos
    {
        Funcionario Adicionar(Funcionario func);
        List<Funcionario> Listar_func();
        List<Dependente> Listar_depen(int id);
        public Funcionario retur_funcionario(int id);
        Dependente Create_depe(Dependente dependente);


    }
}
