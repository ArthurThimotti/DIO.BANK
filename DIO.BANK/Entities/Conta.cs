using System;
using DIO.BANK.Enum;

namespace DIO.BANK.Entities
{
    public class Conta
    {
        Banco banco = new Banco();

        public Conta(TipoConta tipoConta, TipoBanco tipoBanco, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            TipoBanco = tipoBanco;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
            
        }

        private TipoConta TipoConta { get; set; }

        public TipoBanco TipoBanco { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        

        public bool Sacar(double valorSaque)
        {
            

            if (Saldo - (valorSaque + banco.TaxaSaque(TipoBanco)) < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valorSaque + banco.TaxaSaque(TipoBanco);
            Console.WriteLine("Saldo atual da conta de {0} é R$ {1}. Taxa debitada: R$ {2}", Nome, Saldo.ToString
                ("N2"), banco.TaxaSaque(TipoBanco));

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            Saldo += (valorDeposito - banco.TaxaDeposito(TipoBanco));

            Console.WriteLine("Saldo atual da conta de {0} é R$ {1}. Taxa debitada: R$ {2}", Nome, Saldo.ToString
                ("N2"), banco.TaxaSaque(TipoBanco));
           
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Saldo += valorTransferencia;
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + TipoConta + " | ";
            retorno += "TipoBanco: " + TipoBanco + "| ";
            retorno += "Nome: " + Nome + " | ";
            retorno += "Saldo: R$ " + Saldo.ToString("N2") + " | ";
            retorno += "Crédito: R$ " + Credito + " | ";
            return retorno;
        }
    }
}
