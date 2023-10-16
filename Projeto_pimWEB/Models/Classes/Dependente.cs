using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Dependente
    {
        [Key]
        public int id_cod_dep {  get; set; }

        public string Nome {  get; set; }
        public DateTime DtNascimento { get; set; }
        public string Parentesco {  get; set; }


        [ForeignKey(nameof(Dependente))]
        public int funcionarioid_cod_func { get; set; }
        public Funcionario funcionario { get; set; }

        
    }
}