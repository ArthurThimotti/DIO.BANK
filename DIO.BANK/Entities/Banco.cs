using System;
using DIO.BANK.Enum;
using DIO.BANK.Interfaces;

namespace DIO.BANK.Entities
{
    public class Banco : IBancoTaxas
    {
        private double taxaAnuidade { get; set; }
        private double taxaTransferência { get; set; }
        private double taxaSaque { get; set; }

        public double TaxaDeposito(TipoBanco banco)
        {
            if (banco.Equals(TipoBanco.BancoTradicional))
            {
                taxaAnuidade = 11.90;
            }
            else
                taxaAnuidade = 0;

            return taxaAnuidade;
        }

        public double TaxaTransferência(TipoBanco banco)
        {
            if (banco.Equals(TipoBanco.BancoTradicional))
            {
                taxaTransferência = 10.90;
            }
            else
                taxaTransferência = 0;

            return taxaAnuidade;
        }

        public double TaxaSaque(TipoBanco banco)
        {
            if (banco.Equals(TipoBanco.BancoTradicional))
            {
                taxaSaque = 6.90;
            }
            else
                taxaSaque = 0;
            return taxaSaque;
        }


    }
}
