using PlayMatch.Core.Models.Relatórios;
using PlayMatch.Core.Models.Relatorios;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IRelatorioRepository : IGenericRepository<CampeonatoRelatorioJogador>
    {
        Task<List<CampeonatoRelatorioJogador>> GerarRelatorioCampeonatoAsync(int campeonatoId, CancellationToken ct);
        Task<List<RodadaRelatorioJogador>> GerarRelatorioRodadaAsync(int rodadaId, CancellationToken ct);

    }
}
