using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IJogadorRepository: IGenericRepository<Jogador>
    {
        Task<List<Jogador>> GetByCampeonatoAsync(int campeonatoId);
    }
}
