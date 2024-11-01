using MediatR;

namespace Questao5.Application.Queries.Requests
{
    public class ConsultarSaldoContaCorrenteQuery : IRequest<IResult>
    {
        public int Conta { get; set; }


        public ConsultarSaldoContaCorrenteQuery(int conta)
        {
            Conta = conta;
        }
    }
}
