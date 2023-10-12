using Projeto_pimWEB.Data;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Metodos
{
    public class FuncionarioMetodos : I_FuncionarioMetodos
    {
        private readonly myDbContext _mbdt;

        public FuncionarioMetodos(myDbContext mbdt)
        {
            _mbdt = mbdt;
        }

        public Funcionario Adicionar(Funcionario func)
        {
            _mbdt.Add(func);
            this._mbdt.SaveChanges();
            return func;
        }

        public Dependente Create_depe(Dependente dependente)
        {
            _mbdt.dependentes.Add(dependente);
            this._mbdt.SaveChanges();
            return dependente;
        }

        public Funcionario retur_funcionario(int id)
        {
            return _mbdt.funcionarios.Where(i => i.id_cod_func == id).First();
        }

        public List<Funcionario> Listar_func()
        {
            return _mbdt.funcionarios.ToList();

        }

        public List<Dependente> Listar_depen(int id)
        {
            return _mbdt.dependentes.Where(d => d.funcionarioid_cod_func == id).ToList();
        }
    }

}
