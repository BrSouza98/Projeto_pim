using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Pessoa
    {
        [Required(ErrorMessage ="Campo obrigatorio.")]
		[StringLength(50)]
		public string Nome { get; set; }

        public string? Genero { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[DataType(DataType.Date)]
        public string DtNascimento { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
        [StringLength(14)]
		public string CPF { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(12), MinLength(12)]
		public string RG { get; set; }

		[StringLength(60)]
		public string? Nacionalidade { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string EstadoCivil { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string Telefone {  get; set; }

		public string? TelefoneR { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[EmailAddress(ErrorMessage = "O e-mail informado não é valido.")]
		public string Email { get; set; }


		[DataType(DataType.Password)]
		[StringLength(20), MinLength(6, ErrorMessage = "Minimo de caractere para senha são 6.")]
        public string? Password { get; set; }

		[NotMapped]
		[Compare("Password", ErrorMessage = "Senhas diferentes.")]
		[DataType(DataType.Password)]
		[StringLength(20), MinLength(6, ErrorMessage = "Minimo de caractere para senha são 6.")]
		public string? ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(30)]
		public string Cidade { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public string Estado { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(100)]
		public string Rua { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(100)]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "Campo obrigatorio.")]
		[StringLength(9)]
		public string CEP { get; set; }

		[NotMapped]
		[StringLength(40)]
		public string? Complemento { get; set; }

    }

}
