using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class MovimentarContaCorrenteHandler : IRequestHandler<MovimentarContaCorrenteCommand, IResult>
    {
        private readonly IMediator _mediator;
        private readonly IDatabaseBootstrap _databaseBootstrap;

        public MovimentarContaCorrenteHandler(IMediator mediator, IDatabaseBootstrap databaseBootstrap)
        {
            _mediator = mediator;
            _databaseBootstrap = databaseBootstrap;
        }

        public async Task<IResult> Handle(MovimentarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Valor < 0)
                {
                    return Results.Content("INVALID_VALUE");
                }

                if (request.TipoMovimento != "C" || request.TipoMovimento != "D")
                {
                    return Results.Content("INVALID_TYPE");
                }

                var contaCorrente = _databaseBootstrap.ConsultarContaCorrente(request.NumeroContaCorrente);

                var mensagem = string.Empty;

                if (contaCorrente != null)
                {
                    if (contaCorrente[0].Ativo != true)
                    {
                        return Results.Content("INACTIVE_ACCOUNT");
                    }
                    else
                    {
                        var movimentacao = new Movimentacao
                        {
                            Idmovimento = Guid.NewGuid().ToString(),
                            Idcontacorrente = contaCorrente[0].Idcontacorrente,
                            Datamovimento = DateTime.Now,
                            Tipomovimento = request.TipoMovimento,
                            Valor = request.Valor
                        };

                        mensagem = _databaseBootstrap.MovimentarContaCorrente(movimentacao);
                    }
                }
                else
                {
                    return Results.Content("INVALID_ACCOUNT");
                }

                return Results.Ok(mensagem);
            }
            catch (Exception ex) 
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
