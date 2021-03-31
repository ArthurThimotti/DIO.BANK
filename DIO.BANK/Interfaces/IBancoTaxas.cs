using System;
using DIO.BANK.Enum;

namespace DIO.BANK.Interfaces
{
    public interface IBancoTaxas
    {
        double TaxaTransferência(TipoBanco banco);

        double TaxaDeposito(TipoBanco banco);

        double TaxaSaque(TipoBanco banco);


    }
}
