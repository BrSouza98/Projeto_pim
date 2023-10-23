using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Funcionario : Pessoa
    {
        [Key]
        public int id_cod_func { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio.")]
        [StringLength(30)]
        public string Departamento { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(30)]
		public string Cargo { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public double Salario { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public int HoraSemanais { get; set; }

        
        public bool Ativo { get; set; }
        public bool TemAcesso { get; set; }


		[StringLength(50)]
		public string Formacao { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
        [StringLength(11, ErrorMessage ="Informe apenas 11 caracteres.")]
		public string PIS { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string CTPS { get; set; }

        [NotMapped]
        public FolhaPagamento FpRecente { get; set; }
        [NotMapped]
        public ICollection<FolhaPagamento> Folhas { get; set; }
        [NotMapped]
        public ICollection<Dependente> dependentes { get; set; }
       

    }
}
