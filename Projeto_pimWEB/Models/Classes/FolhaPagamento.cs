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
        public Funcionario Funcionario { get; set; }
        public int Jornada { get; set; }
        public double SalarioBruto { get; set; }
        public double Inss { get ; set; }
        public double Irrf { get; set; }
        public double SalarioLiquido { get; set; }
        
        public double Fgts { get; set; }

        [NotMapped]
        public ICollection<Desconto> Descontos { get; set; }
        [NotMapped]
        public ICollection<Beneficio> Beneficios { get; set; }


        public double CalcSalarioBruto(double Salario)
        {
            double? valorHoraExtra = null;

            if(Beneficios != null && Beneficios.Any())
            {
                foreach(Beneficio Bene in Beneficios)
                {
                    if(Bene.Nome_Ben == "Hora Extra")
                    {
                        int Horas_extras = (int)Bene.valor;
                        double valorHora = Salario / Jornada;

                        valorHora *= 1.5;
                        valorHoraExtra = valorHora * Horas_extras;
                        break;
                    }
                }

                if(valorHoraExtra != null) 
                {
                    return Math.Round(Salario + (double)valorHoraExtra, 2);
                }
                
            }
            return Math.Round(Salario,2);

        }
        
        public double CalcINSS(double SalarioBruto)
        {
            double AcInss = 0;

            if (SalarioBruto <= 1320)
            {
                AcInss = SalarioBruto * 7.5 / 100;
            } else if (EstaEntre(1320.01, 2571.29, SalarioBruto))
            {
                AcInss = 99;
                AcInss += (SalarioBruto - 1320.01) * 9 / 100;
            } else if (EstaEntre(2571.30, 3856.94, SalarioBruto))
            {
                AcInss = 99;
                AcInss += 112.62;
                AcInss += (SalarioBruto - 2571.30) * 12 / 100;
            }else if(EstaEntre(3856.95, 7507.49, SalarioBruto))
            {
                AcInss = 99;
                AcInss += 112.62;
                AcInss += 154.28;
                AcInss += (SalarioBruto - 3856.95) * 14 / 100;

            }else if(SalarioBruto >= 7507.49)
            {
                AcInss = 99;
                AcInss += 112.62;
                AcInss += 154.28;
                AcInss += 511.08;
            }
            else
            {
                throw new Exception("Valor invalido");
            }

            return Math.Round(AcInss, 2);
        }

        public double CalcIRRF(double SalarioBruto, double ValorINSS, ICollection<Dependente> depen)
        {
            int qntdDepen = 0;
            
            if (depen != null && depen.Any())
            {
                qntdDepen = depen.Count();
            }
            
            double descontoDepen = qntdDepen * 189.59;

            double baseCalc = SalarioBruto - ValorINSS - descontoDepen;

            if (baseCalc <= 2112)
            {
                return 0;
            }else if(EstaEntre(2112.01, 2826.65, baseCalc))
            {
                return Math.Round((baseCalc * 7.5 / 100) - 158.40, 2);
            }else if(EstaEntre(2826.66, 3751.05, baseCalc))
            {
                return Math.Round((baseCalc * 15 / 100) - 370.40, 2);
            }else if(EstaEntre(3751.06, 4664.68, baseCalc))
            {
                return Math.Round((baseCalc * 22.5 / 100) - 651.73, 2);
            }
            else
            {
                return Math.Round((baseCalc * 27.5 / 100) - 884.96, 2);
            }
            
        }
   
        public double CalcSalarioLiquido(double ValorINSS, double ValorIRRF, double SalarioBruto)
        {
            return Math.Round((SalarioBruto - ValorINSS) - ValorIRRF, 2);
        }

        private bool EstaEntre(double valorMin, double ValorMax, double valor)
        {
            if(valor > valorMin && valor < ValorMax)
            {
                return true;
            }
            return false;
        }

        public void Preencher_FolhaPagamento(Funcionario func)
        {
            try
            {
                DataEmissao = DateTime.Now.ToString("dd/MM/yyyy");
                MesAnoRef = DateTime.Now.ToString("MM/yyyy");
                Funcionario = func;
                Jornada = Funcionario.HoraSemanais * 5;
                SalarioBruto = CalcSalarioBruto(Funcionario.Salario);
                Inss = CalcINSS(SalarioBruto);
                Irrf = CalcIRRF(SalarioBruto, Inss, Funcionario.dependentes);
                SalarioLiquido = CalcSalarioLiquido(Inss, Irrf, SalarioBruto);
                Fgts = SalarioBruto * 0.08;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}