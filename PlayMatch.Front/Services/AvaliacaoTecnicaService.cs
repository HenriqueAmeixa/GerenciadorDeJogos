using AutoMapper;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models.Jogadores;
using PlayMatch.Front.Models.Jogadores;

namespace PlayMatch.Front.Services
{
    public class AvaliacaoTecnicaService
    {
        private readonly IAvaliacaoTecnicaRepository _avaliacaoRepository;
        private readonly IMapper _mapper;
        public AvaliacaoTecnicaService(IAvaliacaoTecnicaRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }

        public async Task SalvarAvaliacaoAsync(AvaliacaoTecnicaDto avaliacao)
        {
            
            await _avaliacaoRepository.InserirAsync(_mapper.Map<AvaliacaoTecnica>(avaliacao));
        }

        public async Task<List<AvaliacaoTecnicaDto>> ObterAvaliacoesDoJogadorAsync(int jogadorId)
        {
            return  _mapper.Map<List<AvaliacaoTecnicaDto>>(await _avaliacaoRepository.ObterPorJogadorAsync(jogadorId));
        }

        public async Task<AvaliacaoTecnicaDto?> ObterUltimaAvaliacaoAsync(int jogadorId, int campeonatoId)
        {
            var avaliacao = await _avaliacaoRepository.ObterUltimaPorJogadorECampeonatoAsync(jogadorId, campeonatoId);
            return avaliacao != null ? _mapper.Map<AvaliacaoTecnicaDto>(avaliacao) : null;
        }


        public async Task<List<AvaliacaoTecnicaDto>> ObterPorCampeonatoAsync(int campeonatoId)
        {
            return _mapper.Map<List<AvaliacaoTecnicaDto>>(await _avaliacaoRepository.ObterPorCampeonatoAsync(campeonatoId));
        }

        public async Task DeletarAvaliacaoAsync(int avaliacaoId)
        {
            await _avaliacaoRepository.DeletarAsync(avaliacaoId);
        }
    }
}
