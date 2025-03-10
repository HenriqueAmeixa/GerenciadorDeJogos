using PlayMatch.Core.Models;
using PlayMatch.Core.Data.Interfaces;

namespace PlayMatch.Front.Services
{
    public class ConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;
        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository)
        {
            _configuracaoRepository = configuracaoRepository;
        }
        public async Task<T> GetConfiguracao<T>(string chave)
        {
            return await _configuracaoRepository.GetConfiguracao<T>(chave);
        }
        public async Task<Dictionary<string, object>> GetTodasConfiguracoesAsync()
        {
            return await _configuracaoRepository.GetTodasConfiguracoesAsync();
        }
    }
}
