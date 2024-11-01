using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {

        public int Conta { get; set; }
        public string Titular { get; set; }
        public double Valor { get; set; } = 0;

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            Conta = numero;
            Titular = titular;
            Valor = depositoInicial;
        }

        public ContaBancaria(int numero, string titular)
        {
            Conta = numero;
            Titular = titular;
        }

        public override string ToString()
        {
            return String.Format("Conta: {0}, Titular: {1}, Saldo: $ {2}:", Conta, Titular, Valor);
        }

        public void Deposito(double valor)
        {
            Valor += valor;
        }

        public void Saque (double valor)
        {
            double taxa = 3.50;
            Valor = Valor - valor - taxa;
        }
    }
}
