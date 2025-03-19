using AutoMapper;
using PlayMatch.Core.Models;

namespace PlayMatch.Front.Services
{
    public class SelecaoJogadoresService
    {
        private readonly JogadorService _jogadorService;
        private readonly ConfiguracaoService _configuracaoService;
        private readonly PartidaService _partidaService;
        private readonly IMapper _mapper;

        public SelecaoJogadoresService(JogadorService jogadorService, ConfiguracaoService configuracaoService, PartidaService partidaService, IMapper mapper)
        {
            _jogadorService = jogadorService;
            _configuracaoService = configuracaoService;
            _partidaService = partidaService;
            _mapper = mapper;
        }

        public async Task<List<Models.Jogador>> ObterJogadoresDisponiveisAsync()
        {
            var todosJogadores = await _jogadorService.GetJogadoresAsync();
            var jogadoresSelecionados = await ObterJogadoresSelecionadosAsync();

            var jogadoresDisponiveis = todosJogadores
                .Where(j => !jogadoresSelecionados.Any(s => s.Id == j.Id))
                .ToList();

            return jogadoresDisponiveis;
        }

        public async Task<List<Models.Jogador>> ObterJogadoresSelecionadosAsync()
        {
            var manterVencedoresConfig = await _configuracaoService.GetConfiguracaoAsync("manter_vencedores");
            bool manterVencedores = manterVencedoresConfig?.ValorBool ?? false;

            if (manterVencedores)
            {
                return await _partidaService.GetVencedoresUltimaPartidaAsync();
            }

            return new List<Models.Jogador>();
        }
    }

}
