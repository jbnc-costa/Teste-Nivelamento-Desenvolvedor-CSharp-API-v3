using MediatR;

namespace Questao5.Application.Queries.Requests
{
    public class ConsultaSaldoContaCorrenteQuery : IRequest<IResult>
    {
        public int Conta { get; set; }


        public ConsultaSaldoContaCorrenteQuery(int conta)
        {
            Conta = conta;
        }
    }
}
