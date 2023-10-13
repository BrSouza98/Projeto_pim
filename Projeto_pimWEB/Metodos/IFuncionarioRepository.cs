using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
	public interface IFuncionarioRepository
    {
        Funcionario CreateFunc(Funcionario func);
        List<Funcionario> GetAllFuncionarios();
        Funcionario GetFuncionario(int id);
        Funcionario UpdateFunc(Funcionario func);

        /*Metodos da class Dependente*/
        Dependente CreateDep(Dependente dependente);
        List<Dependente> GetAllDependentes(int id);
        Dependente GetDependente(int id);
        Dependente UpdateDep(Dependente dependente);

    }
}
