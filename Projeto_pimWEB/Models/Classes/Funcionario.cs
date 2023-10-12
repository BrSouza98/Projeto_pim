using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Funcionario : Pessoa
    {
        [Key]
        public int id_cod_func { get; set; }
        public string Departamento { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBruto { get; set; }
        public float CargaHoraria { get; set; }
        public bool Ativo { get; set; }
        public bool TemAcesso { get; set; }
        public string Formacao { get; set; }
        public string PIS { get; set; }
        public string CTPS { get; set; }

        [NotMapped]
        public Folha_Pagamento FpRecente { get; set; }
        public ICollection<Folha_Pagamento> Folhas { get; set; }
        public ICollection<Dependente> dependentes { get; set; }

        
     
    }
}
