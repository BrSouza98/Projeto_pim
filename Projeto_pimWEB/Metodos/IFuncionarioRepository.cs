using Projeto_pimWEB.Models.Classes;
using System.Collections.Specialized;

namespace Projeto_pimWEB.Metodos
{
	public interface IFuncionarioRepository
    {
        Funcionario GetFuncionarioEmail(string email);
        Funcionario CreateFunc(Funcionario func);
        List<Funcionario> GetAllFuncionarios();
        Funcionario GetFuncionario(int id);
        Funcionario UpdateFunc(Funcionario func);
        Funcionario Desativar (int id);

        /*Metodos da class Dependente*/
        Dependente CreateDep(Dependente dependente);
        List<Dependente> GetAllDependentesFK(int id);
        Dependente GetDependente(int id);
        Dependente UpdateDep(Dependente dependente);

        bool Delete_Depen(int id);
    }
}
