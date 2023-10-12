using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string EstadoCivil { get; set; }
        public string Telefone {  get; set; }
        public string TelefoneR { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }

    }

}
