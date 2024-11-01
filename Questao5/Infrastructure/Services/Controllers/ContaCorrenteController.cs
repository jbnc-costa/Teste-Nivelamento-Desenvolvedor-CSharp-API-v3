using IdempotentAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    //[Idempotent(Enabled = true)]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaCorrenteController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Idempotent(ExpireHours = 48)]
        public async Task<IActionResult> MovimentarContaCorrente([FromBody] MovimentarContaCorrenteRequest movimentarContaCorrenteRequest)
        {
            var movimentarContaCorrenteCommand = new MovimentarContaCorrenteCommand
            {
                NumeroContaCorrente = movimentarContaCorrenteRequest.NumeroContaCorrente,
                Valor = movimentarContaCorrenteRequest.Valor,
                TipoMovimento = movimentarContaCorrenteRequest.TipoMovimento
            };

            var response = await _mediator.Send(movimentarContaCorrenteCommand);

            return this.Ok(response);
        }

        [HttpGet]
        //[Idempotent(ExpireHours = 48)]
        public async Task<IActionResult> SaldoContaCorrente([FromQuery] int conta)
        {
            var query = new ConsultarSaldoContaCorrenteQuery(conta);

            var response = await _mediator.Send(query);

            return this.Ok(response);
        }
    }
}
