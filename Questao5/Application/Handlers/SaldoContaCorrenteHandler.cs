using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class SaldoContaCorrenteHandler : IRequestHandler<ConsultarSaldoContaCorrenteQuery, IResult>
    {
        private readonly IMediator _mediator;
        private readonly IDatabaseBootstrap _databaseBootstrap;

        public SaldoContaCorrenteHandler(IMediator mediator, IDatabaseBootstrap databaseBootstrap)
        {
            _mediator = mediator;
            _databaseBootstrap = databaseBootstrap;
        }

        public async Task<IResult> Handle(ConsultarSaldoContaCorrenteQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contaCorrente = _databaseBootstrap.ConsultarContaCorrente(request.Conta);

                double saldo = 0;

                if (contaCorrente != null)
                {
                    if (contaCorrente[0].Ativo != true)
                    {
                        return Results.Content("INACTIVE_ACCOUNT");
                    }
                    else
                    {
                        var listaMovimentacao = _databaseBootstrap.ConsultarMonvimentacaoContaCorrente(contaCorrente[0].Idcontacorrente);

                        if (listaMovimentacao != null)
                        {
                            foreach (var item in listaMovimentacao)
                            {
                                switch(item.Tipomovimento)
                                {
                                    case "C":
                                        saldo += item.Valor;
                                        break;
                                    case "D":
                                        saldo -= item.Valor;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    return Results.Content("INVALID_ACCOUNT");
                }

                var retornoSaldo = new RetornoSaldo
                {
                    Conta = request.Conta,
                    Nome = contaCorrente[0].Nome,
                    Valor = saldo
                };

                return Results.Ok(retornoSaldo);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
