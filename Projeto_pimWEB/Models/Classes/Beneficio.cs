using System.ComponentModel.DataAnnotations;

namespace Projeto_pimWEB.Models.Classes
{
    public class Beneficio
    {
        [Key]
        public int id_cod_Ben {  get; set; }
        public string Nome_Ben { get; set; }
        public double valor {  get; set; }
        
        
        public FolhaPagamento? Folha_Pagamento { get; set; }
        public Funcionario? Funcionario {get; set;}

        
    }
}