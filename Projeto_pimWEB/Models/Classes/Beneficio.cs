﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class Beneficio
    {
        [Key]
        public int id_cod_Ben {  get; set; }
        public string Nome_Ben { get; set; }
        public double valor {  get; set; }

        [NotMapped]
        public FolhaPagamento? Folha_Pagamento { get; set; }


        public int Funcionarioid_cod_func {  get; set; }
        [ForeignKey("Funcionarioid_cod_func")]
        public Funcionario? Funcionario {get; set;}

        
    }
}