using Microsoft.Extensions.Options;
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

        [ForeignKey(nameof(Funcionario))]
        public int id_cod_func { get; set; }
        public Funcionario? Funcionario { get; set; }
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

        public void CalcJornada(int horas)
        {
            Jornada = horas * 5;
        }


        public void CalcSalarioBruto(double Salario)
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
                    SalarioBruto = Salario + (double)valorHoraExtra;
                }
                
            }
            SalarioBruto = Salario;
        }
        
        public void CalcINSS(double SalarioBruto)
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

            Inss = AcInss;
        }

        public void CalcIRRF(double SalarioBruto, double ValorINSS, ICollection<Dependente> depen)
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
                Irrf = 0;
            }else if(EstaEntre(2112.01, 2826.65, baseCalc))
            {
                Irrf = (baseCalc * 7.5 / 100) - 158.40;
            }else if(EstaEntre(2826.66, 3751.05, baseCalc))
            {
                Irrf = (baseCalc * 15 / 100) - 370.40;
            }else if(EstaEntre(3751.06, 4664.68, baseCalc))
            {
                Irrf = (baseCalc * 22.5 / 100) - 651.73;
            }
            else
            {
                Irrf = (baseCalc * 27.5 / 100) - 884.96;
            }
            
        }
   
        public void CalcSalarioLiquido(double ValorINSS, double ValorIRRF, double SalarioBruto)
        {
            SalarioLiquido = (SalarioBruto - ValorINSS) - ValorIRRF;
        }

        private bool EstaEntre(double valorMin, double ValorMax, double valor)
        {
            if(valor > valorMin && valor < ValorMax)
            {
                return true;
            }
            return false;
        }

    }
}