using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class RodadaService
    {
        private readonly IRodadaRepository _rodadaRepository;
        private readonly IPartidaRepository _partidaRepository;
        private readonly IMapper _mapper;

        public RodadaService(IRodadaRepository rodadaRepository, IMapper mapper, IPartidaRepository partidaRepository)
        {
            _rodadaRepository = rodadaRepository;
            _mapper = mapper;
            _partidaRepository = partidaRepository;
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
        public async Task<List<Models.RodadaResumo>> ObterResumosPorCampeonatoAsync(int campeonatoId)
        {
            var rodadas = await _rodadaRepository.ObterPorCampeonatoIdAsync(campeonatoId);
            var partidas = await _partidaRepository.GetByRodadasAsync(rodadas.Select(r => r.Id).ToList());

            return rodadas.Select(r =>
            {
                var totalPartidas = partidas.Count(p => p.RodadaId == r.Id);

                return new Models.RodadaResumo
                {
                    Id = r.Id,
                    Numero = r.Numero,
                    Data = r.Data,
                    TotalPartidas = totalPartidas
                };
            }).OrderBy(r => r.Numero).ToList();
        }
        public async Task<Models.Rodada> CriarRodadaAutomaticaAsync(int campeonatoId)
        {
            var rodadas = await _rodadaRepository.ObterPorCampeonatoIdAsync(campeonatoId);

            int proximoNumero = rodadas.Any()
                ? rodadas.Max(r => r.Numero) + 1
                : 1;

            var novaRodada = new Models.Rodada
            {
                CampeonatoId = campeonatoId,
                Numero = proximoNumero,
                Data = DateTime.Now
            };

            await _rodadaRepository.InserirAsync(_mapper.Map<Rodada>(novaRodada));
            return novaRodada;
        }
    }
}
