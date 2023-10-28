using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Desconto
    {
        [Key]
        public int id_cod_des { get; set; } 
        public string Motivo {  get; set; }
        public double Valor { get; set; }

        [NotMapped]
        public FolhaPagamento Folha_Pagamento {  get; set; }

        public int Funcionarioid_cod_func {  get; set; }
        [ForeignKey("Funcionarioid_cod_func")]
        public Funcionario? Funcionario { get; set; }

        
    }
}