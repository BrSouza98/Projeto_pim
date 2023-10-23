using System.ComponentModel.DataAnnotations;

namespace Projeto_pimWEB.Models.Classes
{
    public class Desconto
    {
        [Key]
        public int id_cod_des { get; set; } 
        public string Motivo {  get; set; }
        public double Valor { get; set; }

        public Folha_Pagamento Folha_Pagamento {  get; set; }
        public Funcionario Funcionario { get; set; }

        
    }
}