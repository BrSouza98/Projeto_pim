﻿using Microsoft.Extensions.Options;
using NuGet.Versioning;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_pimWEB.Models.Classes
{
    public class FolhaPagamento
    {
        [Key]
        public int id_cod_FP {  get; set; }

        [DataType(DataType.Date)]
        public string DataEmissao { get; set; } 

        [DataType(DataType.Date)]
        public string MesAnoRef {  get; set; }

        public int id_cod_func { get; set; }
        [ForeignKey("id_cod_func")]
        public Funcionario? Funcionario { get; set; }

        public int Jornada { get; set; }
        public double SalarioBruto { get; set; }
        public double Inss { get ; set; }
        public double Irrf { get; set; }
        public double SalarioLiquido { get; set; }
        public int? HorasExtras { get; set; }
        public int? Bonus { get; set; }
        public int? Faltas { get; set; }
        public int? Atrasos { get; set; }
		public double Fgts { get; set; }

        [NotMapped]
        public ICollection<Desconto> Descontos { get; set; }
		[NotMapped]
		public Desconto desconto { get; set; }
        [NotMapped]
        public ICollection<Beneficio> Beneficios { get; set; }
		[NotMapped]
		public Beneficio beneficio { get; set; }

       

    }
}