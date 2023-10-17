using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Pessoa
    {
        [Required(ErrorMessage ="Campo obrigatorio.")]
		[MaxLength(50)]
		public string Nome { get; set; }

        public string Genero { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[DataType(DataType.Date)]
        public DateTime DtNascimento { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
        [MaxLength(14)]
		public string CPF { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(12)]
		public string RG { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string EstadoCivil { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[Phone(ErrorMessage ="O número informado não é valido.")]
		public string Telefone {  get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[Phone(ErrorMessage = "O número informado não é valido.")]
		public string TelefoneR { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[EmailAddress(ErrorMessage = "O e-mail informado não é valido.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[DataType(DataType.Password)]
		[MaxLength(20), MinLength(6, ErrorMessage = "Minimo de caractere para senha são 6.")]
        public string Password { get; set; }

		[NotMapped]
		[Required(ErrorMessage = "Campo obrigatorio.")]
		[Compare("Password", ErrorMessage = "Senhas diferentes.")]
		[DataType(DataType.Password)]
		[MaxLength(20), MinLength(6, ErrorMessage = "Minimo de caractere para senha são 6.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(30)]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(20), MinLength(2, ErrorMessage = "Minimo de caractere para Estado são 2.")]
		public string Estado { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(60)]
		public string Pais { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(100)]
		public string Rua { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[MaxLength(100)]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string CEP { get; set; }

		[NotMapped]
		[MaxLength(40)]
		public string? Complemento { get; set; }

    }

}
