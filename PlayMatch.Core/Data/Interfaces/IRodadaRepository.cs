using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IRodadaRepository : IGenericRepository<Rodada>
    {
        Task<List<Rodada>> ObterPorCampeonatoIdAsync(int campeonatoId);
        Task<Rodada?> ObterPorIdAsync(int id);
        Task<Rodada> InserirAsync(Rodada rodada);
        Task AtualizarAsync(Rodada rodada);
        Task RemoverAsync(int id);
    }
}
