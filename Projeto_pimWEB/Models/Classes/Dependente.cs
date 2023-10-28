using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Dependente
    {
        [Key]
        public int id_cod_dep {  get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(50)]
		public string Nome {  get; set; }

        
        [Required(ErrorMessage = "Campo obrigatorio.")]
        [DataType(DataType.Date)]
        public string DtNascimento { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(15)]
		public string Parentesco {  get; set; }

        public int funcionarioid_cod_func { get; set; }
        [ForeignKey("funcionarioid_cod_func")]
        public Funcionario? funcionario { get; set; }

        
    }
}