using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IConfiguracaoRepository : IGenericRepository<Configuracao>
    {
        Task<T> GetConfiguracao<T>(string chave);
        Task<Dictionary<string, object>> GetTodasConfiguracoesAsync();
    }
}
