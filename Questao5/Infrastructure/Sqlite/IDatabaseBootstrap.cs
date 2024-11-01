using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite
{
    public interface IDatabaseBootstrap
    {
        void Setup();
        List<Contacorrente> ConsultarContaCorrente(int conta);
        string MovimentarContaCorrente(Movimentacao movimentacao);
        List<Movimentacao> ConsultarMonvimentacaoContaCorrente(string idcontacorrente);
    }
}