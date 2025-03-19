using AutoMapper;
using PlayMatch.Core.Models;

namespace PlayMatch.Front.Services
{
    public class ConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly IMapper _mapper;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository, IMapper mapper)
        {
            _configuracaoRepository = configuracaoRepository;
            _mapper = mapper;
        }

        public async Task<Models.Configuracao> GetConfiguracaoAsync(string chave)
        {
            Configuracao configuracao = await _configuracaoRepository.GetConfiguracaoAsync(chave);
            return  _mapper.Map<Models.Configuracao>(configuracao);
        }

        public async Task<List<Models.Configuracao>> GetTodasConfiguracoesAsync()
        {
            var configuracoes = await _configuracaoRepository.GetTodasConfiguracoesAsync();
            return _mapper.Map<List<Models.Configuracao>>(configuracoes);
        }
        public async Task AtualizarConfiguracaoAsync(Models.Configuracao configuracao)
        {
            if (configuracao.Tipo == "bool")
            {
                configuracao.Valor = configuracao.Valor.ToLower() == "true" ? "true" : "false";
            }
            else if (configuracao.Tipo == "timespan")
            {
                if (TimeSpan.TryParse(configuracao.Valor, out TimeSpan ts))
                {
                    configuracao.Valor = ts.ToString(); // Formato "hh:mm:ss"
                }
                else
                {
                    throw new ArgumentException($"Formato inválido para TimeSpan na configuração '{configuracao.Chave}'. Use hh:mm:ss");
                }
            }

            await _configuracaoRepository.AtualizarConfiguracaoAsync(_mapper.Map<Configuracao>(configuracao));
        }
    }
}
