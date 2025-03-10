using PlayMatch.Core.Models;

public interface IConfiguracaoRepository
{
    Task<List<Configuracao>> GetTodasConfiguracoesAsync();
    Task<Configuracao> GetConfiguracaoAsync(string chave);
    Task AtualizarConfiguracaoAsync(Configuracao configuracao);
}
