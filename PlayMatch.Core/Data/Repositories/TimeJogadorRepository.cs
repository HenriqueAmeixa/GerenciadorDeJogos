using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;

namespace PlayMatch.Core.Data.Repositories
{
    public class TimeJogadorRepository : SQLiteRepository<TimeJogador>, ITimeJogadorRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public TimeJogadorRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task InserirRelacionamentoAsync(int timeId, int jogadorId)
        {
            var relacao = new TimeJogador { TimeId = timeId, JogadorId = jogadorId };
            await _database.InsertAsync(relacao);
        }

        public async Task<List<Jogador>> GetJogadoresPorTimeAsync(int timeId)
        {
            var relacoes = await _database.Table<TimeJogador>().Where(tj => tj.TimeId == timeId).ToListAsync();
            var jogadores = new List<Jogador>();

            foreach (var relacao in relacoes)
            {
                var jogador = await _database.Table<Jogador>().Where(j => j.Id == relacao.JogadorId).FirstOrDefaultAsync();
                if (jogador != null)
                {
                    jogadores.Add(jogador);
                }
            }

            return jogadores;
        }

        public async Task RemoverRelacionamentoAsync(int timeId, int jogadorId)
        {
            var relacao = await _database.Table<TimeJogador>()
                .Where(tj => tj.TimeId == timeId && tj.JogadorId == jogadorId)
                .FirstOrDefaultAsync();

            if (relacao != null)
            {
                await _database.DeleteAsync(relacao);
            }
        }
    }
}
