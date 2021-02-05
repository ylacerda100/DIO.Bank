using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
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
            Console.WriteLine("Obrigado por utilizar nosso serviço!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listando contas...");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta foi cadastrada");
                return;
            }
            foreach (var c in listaContas)
            {
                Console.WriteLine(c);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double saldoConta = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double creditoConta = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)tipoConta, saldoConta, creditoConta, nomeCliente);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}
