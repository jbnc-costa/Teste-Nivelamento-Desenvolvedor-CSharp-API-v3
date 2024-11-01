namespace Questao5.Application.Commands.Requests
{
    public class MovimentarContaCorrenteRequest
    {
        public Int32 NumeroContaCorrente { get; set; }
        public Double Valor {  get; set; }
        public string TipoMovimento { get; set; } = string.Empty;
    }
}
