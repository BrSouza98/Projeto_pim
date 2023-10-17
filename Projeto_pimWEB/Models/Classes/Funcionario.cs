using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Funcionario : Pessoa
    {
        [Key]
        public int id_cod_func { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(30)]
        public string Departamento { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio")]
		[MaxLength(30)]
		public string Cargo { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio")]
		public decimal SalarioBruto { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio")]
		public float CargaHoraria { get; set; }

        
        public bool Ativo { get; set; }
        public bool TemAcesso { get; set; }


		[Required(ErrorMessage = "Campo obrigatorio")]
		[MaxLength(50)]
		public string Formacao { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio")]
		public string PIS { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio")]
		public string CTPS { get; set; }

        [NotMapped]
        public Folha_Pagamento? FpRecente { get; set; }
        [NotMapped]
        public ICollection<Folha_Pagamento>? Folhas { get; set; }
        [NotMapped]
        public ICollection<Dependente>? dependentes { get; set; }
       

    }
}
