using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class RodadaService
    {
        private readonly IRodadaRepository _rodadaRepository;
        private readonly IMapper _mapper;

        public RodadaService(IRodadaRepository rodadaRepository, IMapper mapper)
        {
            _rodadaRepository = rodadaRepository;
            _mapper = mapper;
        }

        public async Task<List<Models.Rodada>> ObterPorCampeonatoIdAsync(int campeonatoId)
        {
            var rodadas = await _rodadaRepository.ObterPorCampeonatoIdAsync(campeonatoId);
            return _mapper.Map<List<Models.Rodada>>(rodadas);
        }

        public async Task<Models.Rodada?> ObterPorIdAsync(int id)
        {
            var rodada = await _rodadaRepository.ObterPorIdAsync(id);
            return rodada == null ? null : _mapper.Map<Models.Rodada>(rodada);
        }

        public async Task InserirAsync(Models.Rodada rodada)
        {
            await _rodadaRepository.InserirAsync(_mapper.Map<Rodada>(rodada));
        }

        public async Task AtualizarAsync(Models.Rodada rodada)
        {
            await _rodadaRepository.AtualizarAsync(_mapper.Map<Rodada>(rodada));
        }

        public async Task RemoverAsync(int id)
        {
            await _rodadaRepository.RemoverAsync(id);
        }
    }
}
