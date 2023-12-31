﻿using Projeto_pimWEB.Models.Classes;
using System.Transactions;

namespace Projeto_pimWEB.Metodos.Calculos
{
	public class Calculos
	{
		public static double CalcFGTS(double SalarioBruto)
		{
			return SalarioBruto * 0.08;
		}

		public static int CalcJornada(int HorasSemanais)
		{
			return HorasSemanais * 5;
		}


		public static double CalcSalarioBruto(
			double Salario, 
			ICollection<Beneficio>? beneficios, 
			ICollection<Desconto>? descontos ,
			int Jornada, 
			int? horasExtra,
			int? bonus,
			int? faltas,
			int? atrasos)
		{
			double valortotalBene = 0;
			double valortotalDesc = 0;

			/*Calculos descontos*/

			if (atrasos != null && atrasos > 0)
			{
				double descAtraso = (Salario / Jornada) * (int)atrasos;
				Salario -= descAtraso;
			}

			if (faltas != null && faltas > 0)
			{
				double valorFalta = (Salario / 30) * (int)faltas;
				Salario -= valorFalta;
			}

			if (descontos != null && descontos.Any()) 
			{
				foreach (Desconto desc in descontos)
				{
					valortotalDesc += desc.Valor;

				}
				Salario -= valortotalDesc;

			}
			 /*Calculos adicionais*/
			if (bonus != null && bonus > 0)
			{
				Salario += (int)bonus;
			}

			if (horasExtra != null)
			{
                double valorHora = Salario / Jornada;
				valorHora *= 1.5;
				double TotalHoraExtra = (int)horasExtra * valorHora;
				Salario += TotalHoraExtra;
				
            }

			if (beneficios != null && beneficios.Any())
			{
				foreach (Beneficio Bene in beneficios)
				{
					valortotalBene = Bene.valor;
				}
				Salario += valortotalBene;
			}

			return Salario;
		}

		public static double CalcINSS(double SalarioBruto)
		{
			double AcInss = 0;

			if (SalarioBruto <= 1320)
			{
				AcInss = SalarioBruto * 7.5 / 100;
			}
			else if (EstaEntre(1320.01, 2571.29, SalarioBruto))
			{
				AcInss = 99;
				AcInss += (SalarioBruto - 1320.01) * 9 / 100;
			}
			else if (EstaEntre(2571.30, 3856.94, SalarioBruto))
			{
				AcInss = 99;
				AcInss += 112.62;
				AcInss += (SalarioBruto - 2571.30) * 12 / 100;
			}
			else if (EstaEntre(3856.95, 7507.49, SalarioBruto))
			{
				AcInss = 99;
				AcInss += 112.62;
				AcInss += 154.28;
				AcInss += (SalarioBruto - 3856.95) * 14 / 100;

			}
			else if (SalarioBruto >= 7507.49)
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

			return AcInss;
		}

		public static double CalcIRRF(double SalarioBruto, double ValorINSS, ICollection<Dependente> depen)
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
				return  0;
			}
			else if (EstaEntre(2112.01, 2826.65, baseCalc))
			{
				return  (baseCalc * 7.5 / 100) - 158.40;
			}
			else if (EstaEntre(2826.66, 3751.05, baseCalc))
			{
				return (baseCalc * 15 / 100) - 370.40;
			}
			else if (EstaEntre(3751.06, 4664.68, baseCalc))
			{
				return (baseCalc * 22.5 / 100) - 651.73;
			}
			else
			{
				return (baseCalc * 27.5 / 100) - 884.96;
			}

		}

		public static double CalcSalarioLiquido(double ValorINSS, double ValorIRRF, double SalarioBruto)
		{
			return (SalarioBruto - ValorINSS) - ValorIRRF;
		}

		public static bool EstaEntre(double valorMin, double ValorMax, double valor)
		{
			if (valor > valorMin && valor < ValorMax)
			{
				return true;
			}
			return false;
		}

	}
}
