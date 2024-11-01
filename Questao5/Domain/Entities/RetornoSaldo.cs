namespace Questao5.Domain.Entities
{
    public class RetornoSaldo
    {
        public int Conta { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataSaldo { get; set; } = DateTime.Now;
        public double Valor { get; set; }
    }
}
