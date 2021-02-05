using System;

namespace DIO.Bank
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }


        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valor)
        {
            if (this.Saldo - valor < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }

            this.Saldo -= valor;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é {this.Saldo}");

        }

        public void Transferir(double valor, Conta contaDestino)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"TipoConta {TipoConta} | ";
            retorno += $"Nome {this.Nome} | ";
            retorno += $"Saldo {this.Saldo} | ";
            retorno += $"Crédito {this.Credito}";
            return retorno;
        }
    }
}