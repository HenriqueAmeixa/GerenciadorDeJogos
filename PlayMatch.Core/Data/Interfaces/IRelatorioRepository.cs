using PlayMatch.Core.Models.Relatórios;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IRelatorioRepository : IGenericRepository<CampeonatoRelatorioJogador>
    {
        Task<List<CampeonatoRelatorioJogador>> GerarRelatorioCampeonatoAsync(int campeonatoId, CancellationToken ct);
    }
}
