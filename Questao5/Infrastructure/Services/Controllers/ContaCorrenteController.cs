using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContaCorrenteController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
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
        public async Task<IActionResult> SaldoContaCorrente([FromQuery] int conta)
        {
            var query = new ConsultaSaldoContaCorrenteQuery(conta);

            var response = await _mediator.Send(query);

            return this.Ok(response);
        }
    }
}
