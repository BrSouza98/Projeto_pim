using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Folha_Pagamento
    {
        [Key]
        public int id_cod_FP {  get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEmissao {  get; set; }

        [DataType(DataType.Date)]
        public DateTime MesRef {  get; set; }
        public string NomeFunc { get; set; }
        public string Cargo { get; set; }
        public float DiasTrabalhados { get; set; }
        public int id_cod_func { get; set; }
        public Funcionario Funcionario { get; set; }

        [NotMapped]
        private decimal SalarioBruto { get; set; }
        [NotMapped]
        private decimal SalarioLiquido { get; set; }
        [NotMapped]
        public ICollection<Desconto> Descontos { get; set; }
        [NotMapped]
        public ICollection<Beneficio> Beneficios { get; set; }


    }
}