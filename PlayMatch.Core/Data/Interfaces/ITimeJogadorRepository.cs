using PlayMatch.Core.Models;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface ITimeJogadorRepository : IGenericRepository<TimeJogador>
    {
        Task InserirRelacionamentoAsync(int timeId, int jogadorId);
        Task<List<Jogador>> GetJogadoresPorTimeAsync(int timeId);
        Task RemoverRelacionamentoAsync(int timeId, int jogadorId);
    }
}
