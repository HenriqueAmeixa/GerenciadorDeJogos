using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models.Relatórios;
using PlayMatch.Core.Models;
using SQLite;


namespace PlayMatch.Core.Data.Repositories
{
    public class RelatorioRepository : SQLiteRepository<CampeonatoRelatorioJogador>, IRelatorioRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public RelatorioRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task<List<CampeonatoRelatorioJogador>> GerarRelatorioCampeonatoAsync(int campeonatoId, CancellationToken ct)
        {
            try
            {
                var rodadas = await _database.Table<Rodada>()
                    .Where(r => r.CampeonatoId == campeonatoId)
                    .ToListAsync();

                var rodadaIds = rodadas.Select(r => r.Id).ToList();

                var partidas = await _database.Table<Partida>()
                    .Where(p => rodadaIds.Contains(p.RodadaId))
                    .ToListAsync();

                var partidaIds = partidas.Select(p => p.Id).ToList();

                var gols = await _database.Table<Gol>()
                    .Where(g => partidaIds.Contains(g.PartidaId))
                    .ToListAsync();

                var assistencias = await _database.Table<Assistencia>()
                    .Where(a => partidaIds.Contains(a.PartidaId))
                    .ToListAsync();

                var jogadores = await _database.Table<Jogador>().ToListAsync();
                var times = await _database.Table<Time>().ToListAsync();
                var timeJogadores = await _database.Table<TimeJogador>().ToListAsync();

                var relatorio = new List<CampeonatoRelatorioJogador>();

                foreach (var jogador in jogadores)
                {
                    int vitorias = 0;
                    int golsFeitos = gols.Count(g => g.JogadorId == jogador.Id);
                    int assistenciasFeitas = assistencias.Count(a => a.JogadorId == jogador.Id);

                    var jogadorTimes = timeJogadores
                        .Where(tj => tj.JogadorId == jogador.Id)
                        .Select(tj => tj.TimeId)
                        .ToList();

                    foreach (var partida in partidas)
                    {
                        var golsTime1 = gols.Count(g => g.PartidaId == partida.Id && timeJogadores.Any(tj => tj.JogadorId == g.JogadorId && tj.TimeId == partida.Time1Id));
                        var golsTime2 = gols.Count(g => g.PartidaId == partida.Id && timeJogadores.Any(tj => tj.JogadorId == g.JogadorId && tj.TimeId == partida.Time2Id));

                        int? timeVencedorId = null;
                        if (golsTime1 > golsTime2)
                            timeVencedorId = partida.Time1Id;
                        else if (golsTime2 > golsTime1)
                            timeVencedorId = partida.Time2Id;

                        if (timeVencedorId != null && jogadorTimes.Contains(timeVencedorId.Value))
                        {
                            vitorias++;
                        }
                    }

                    if (vitorias > 0 || golsFeitos > 0 || assistenciasFeitas > 0)
                    {
                        relatorio.Add(new CampeonatoRelatorioJogador
                        {
                            JogadorId = jogador.Id,
                            Apelido = jogador.Apelido,
                            Vitorias = vitorias,
                            Gols = golsFeitos,
                            Assistencias = assistenciasFeitas
                        });
                    }
                }

                return relatorio
                    .OrderByDescending(j => j.Vitorias)
                    .ThenByDescending(j => j.Gols)
                    .ThenByDescending(j => j.Assistencias)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório do campeonato {campeonatoId}: {ex.Message}");
                return new List<CampeonatoRelatorioJogador>();
            }
        }
    }
}
