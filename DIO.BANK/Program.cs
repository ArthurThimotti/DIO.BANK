using System;
using System.Collections.Generic;
using DIO.BANK.Entities;
using DIO.BANK.Enum;

namespace DIO.BANK
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static Conta ContaTeste = new Conta((TipoConta)1,(TipoBanco)1, 1000, 1000, "ContaTeste");
  
        public static void Main(string[] args)
        {
            Console.Clear();
            listContas.Add(ContaTeste);
          
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

       

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO.BANK!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
            int inputTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Qual banco deseja abrir conta ? Digite 1 para Tradicional ou 2 para Banco Inter: ");
            int inputTipoBanco = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string inputNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double inputSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double inputCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)inputTipoConta, tipoBanco: (TipoBanco)inputTipoBanco,
                saldo: inputSaldo, credito: inputCredito, nome: inputNome);

            listContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas:");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }


        private static void Sacar()
        {
            Console.Write("Digite  o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorDeposito);
            
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
    }

}