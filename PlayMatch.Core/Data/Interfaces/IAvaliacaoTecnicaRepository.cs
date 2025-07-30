using PlayMatch.Core.Models.Jogadores;

namespace PlayMatch.Core.Data.Interfaces
{
    public interface IAvaliacaoTecnicaRepository
    {
        Task InserirAsync(AvaliacaoTecnica avaliacao);
        Task<List<AvaliacaoTecnica>> ObterPorJogadorAsync(int jogadorId);
        Task<AvaliacaoTecnica?> ObterUltimaPorJogadorAsync(int jogadorId);
        Task<List<AvaliacaoTecnica>> ObterPorCampeonatoAsync(int campeonatoId);
        Task DeletarAsync(int avaliacaoId);
    }
}
