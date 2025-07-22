using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface ICampeonatoRepository : IGenericRepository<Campeonato>
    {
        Task<List<Campeonato>> ObterTodosAsync();
        Task<Campeonato?> ObterPorIdAsync(int id);
        Task InserirAsync(Campeonato campeonato);
        Task AtualizarAsync(Campeonato campeonato);
        Task RemoverAsync(int id);
    }
}
