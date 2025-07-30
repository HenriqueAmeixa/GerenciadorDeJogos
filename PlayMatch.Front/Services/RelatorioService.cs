using AutoMapper;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Front.Models.Relatorios;

namespace PlayMatch.Front.Services
{
    public class RelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IMapper _mapper;
        public RelatorioService(IRelatorioRepository relatorioRepository, IMapper mapper)
        {
            _relatorioRepository = relatorioRepository;
            _mapper = mapper;
        }

        public async Task<List<CampeonatoRelatorioJogador>> GerarRelatorioCampeonatoAsync(int campeonatoId, CancellationToken ct)
        {
            var relatorio = await _relatorioRepository.GerarRelatorioCampeonatoAsync(campeonatoId, ct);
            return _mapper.Map<List<CampeonatoRelatorioJogador>>(relatorio);
        }
        public async Task<List<RodadaRelatorioJogador>> GerarRelatorioRodadaAsync(int rodadaId, CancellationToken ct)
        {
            var relatorio = await _relatorioRepository.GerarRelatorioRodadaAsync(rodadaId, ct);
            return _mapper.Map<List<RodadaRelatorioJogador>>(relatorio);
        }

    }
}
