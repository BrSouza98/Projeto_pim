using Projeto_pimWEB.Data;
using Projeto_pimWEB.Models.Classes;
using System;

namespace Projeto_pimWEB.Metodos
{
    public class FuncionarioMetodos : IFuncionarioRepository
    {
        private readonly myDbContext _mbdt;

        public FuncionarioMetodos(myDbContext mbdt)
        {
            _mbdt = mbdt;
        }

        /*Métodos Funcionario*/

        public Funcionario CreateFunc(Funcionario func)
        {
            _mbdt.Add(func);
            this._mbdt.SaveChanges();
            return func;
        }

        public Funcionario GetFuncionario(int id) // Retorna apenas o funcionario pela chave primaria 
        {
            Funcionario? func = _mbdt.funcionarios.Where(i => i.id_cod_func == id).FirstOrDefault();
            return func;
        }

        public List<Funcionario> GetAllFuncionarios() // Retorna todos os funcionarios 
        {
            return _mbdt.funcionarios.ToList();
        }

        public Funcionario GetFuncionarioEmail(string email)
        {
            Funcionario? func = _mbdt.funcionarios.FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
            return func;
        }

        public Funcionario UpdateFunc(Funcionario funcionario)
        {
            Funcionario func_db = GetFuncionario(funcionario.id_cod_func) ?? throw new Exception("Houve um erro na alteração dos dados");

            func_db.Nome = funcionario.Nome;
            func_db.Departamento = funcionario.Departamento;
            func_db.Cargo = funcionario.Cargo;
            func_db.SalarioBruto = funcionario.SalarioBruto;
            func_db.CargaHoraria = funcionario.CargaHoraria;
            func_db.Ativo = funcionario.Ativo;
            func_db.TemAcesso = funcionario.TemAcesso;
            func_db.Formacao = funcionario.Formacao;
            func_db.PIS = funcionario.PIS;
            func_db.CTPS = funcionario.CTPS;
            func_db.Genero = funcionario.Genero;
            func_db.DtNascimento = funcionario.DtNascimento;
            func_db.CPF = funcionario.CPF;
            func_db.RG = funcionario.RG;
            func_db.EstadoCivil = funcionario.EstadoCivil;
            func_db.Telefone = funcionario.Telefone;
            func_db.TelefoneR = funcionario.TelefoneR;
            func_db.Email = funcionario.Email;
            func_db.Cidade = funcionario.Cidade;
            func_db.Estado = funcionario.Estado;
            func_db.Nacionalidade = funcionario.Nacionalidade;
            func_db.Rua = funcionario.Rua;
            func_db.Numero = funcionario.Numero;
            func_db.Bairro = funcionario.Bairro;
            func_db.CEP = funcionario.CEP;
            func_db.Complemento = funcionario.Complemento;

            _mbdt.funcionarios.Update(func_db);
            _mbdt.SaveChanges();
            return func_db;
        }

        public Funcionario Desativar(int id)
        {
            var func_db = GetFuncionario(id) ?? throw new Exception("Houve um erro na desativação do funcionario");

            func_db.Ativo = false;
            func_db.TemAcesso = false;

            _mbdt.funcionarios.Update(func_db);
            _mbdt.SaveChanges();
            return func_db;
        }

        //Metodos dependentes 
        public Dependente CreateDep(Dependente dependente)
        {
            _mbdt.dependentes.Add(dependente);
            this._mbdt.SaveChanges();
            return dependente;
        }

        public List<Dependente> GetAllDependentesFK(int id) // Retorna apenas os dependentes com a chave estrangeira
        {
            return _mbdt.dependentes.Where(d => d.funcionarioid_cod_func == id).ToList();
        }

        public Dependente GetDependente(int id) // Retorna apenas o depentende pela chave primaria
        {
            return _mbdt.dependentes.Where(d => d.id_cod_dep == id).First();
        }

        public Dependente UpdateDep(Dependente dependente)
        {
            var depen_db = GetDependente(dependente.id_cod_dep) ?? throw new Exception("Houve um erro na alteração dos dados");

            depen_db.Nome = dependente.Nome;
            depen_db.Parentesco = dependente.Parentesco;
            depen_db.DtNascimento = dependente.DtNascimento;

            _mbdt.dependentes.Update(depen_db);
            _mbdt.SaveChanges();
            return depen_db;
        }

        public bool Delete_Depen(int id)
        {
            var depen_db = GetDependente(id) ?? throw new Exception("Houve um erro na desativação do dependente");

            _mbdt.dependentes.Remove(depen_db);
            _mbdt.SaveChanges();
            return true;
        }

        
    }

}
