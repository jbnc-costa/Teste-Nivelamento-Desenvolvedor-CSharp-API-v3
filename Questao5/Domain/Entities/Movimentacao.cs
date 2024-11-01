namespace Questao5.Domain.Entities
{
    public class Movimentacao
    {
        public string Idmovimento { get; set; } = string.Empty;
        public string Idcontacorrente { get; set; } = string.Empty;
        public DateTime Datamovimento { get; set; }
        public string Tipomovimento { get; set; } = string.Empty;
	    public double Valor {  get; set; }
    }
}
