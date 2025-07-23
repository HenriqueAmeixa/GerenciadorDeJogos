using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class CampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly IMapper _mapper;
        private readonly RodadaService _rodadaService;
        private readonly PartidaService _partidaService;
        private readonly JogadorService _jogadorService;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository, IMapper mapper, RodadaService rodadaService, PartidaService partidaService, JogadorService jogadorService)
        {
            _campeonatoRepository = campeonatoRepository;
            _mapper = mapper;
            _rodadaService = rodadaService;
            _partidaService = partidaService;
            _jogadorService = jogadorService;
        }
        public async Task<List<Models.Campeonato>> ObterTodosAsync()
        {
            var campeonatos = await _campeonatoRepository.GetAllAsync();
            return _mapper.Map<List<Models.Campeonato>>(campeonatos);
        }

        public async Task<Models.Campeonato?> ObterPorIdAsync(int id)
        {
            var campeonato = await _campeonatoRepository.ObterPorIdAsync(id);
            return campeonato == null ? null : _mapper.Map<Models.Campeonato>(campeonato);
        }

        public async Task<Models.Campeonato> InserirAsync(Models.Campeonato campeonato)
        {
            var campeonatoModel = await _campeonatoRepository.InserirAsync(_mapper.Map<Campeonato>(campeonato));
            return  _mapper.Map<Models.Campeonato>(campeonatoModel);
        }

        public async Task AtualizarAsync(Campeonato campeonato)
        {
            await _campeonatoRepository.AtualizarAsync(_mapper.Map<Campeonato>(campeonato));
        }

        public async Task RemoverAsync(int id)
        {
            await _campeonatoRepository.RemoverAsync(id);
        }
        public async Task<List<Models.CampeonatoResumo>> ObterCampeonatosResumoAsync()
        {
            var campeonatos = await _campeonatoRepository.GetAllAsync();
            var lista = new List<Models.CampeonatoResumo>();

            foreach (var campeonato in campeonatos)
            {
                var rodadas = await _rodadaService.ObterPorCampeonatoIdAsync(campeonato.Id);
                var partidas = await _partidaService.GetPartidasPorRodadaIdAsync(rodadas.Select(r => r.Id).ToList());

                var totalRodadas = rodadas.Count;
                var totalPartidas = partidas.Count;
                var dataUltimaRodada = rodadas.OrderByDescending(r => r.Data).FirstOrDefault()?.Data;

                lista.Add(new Models.CampeonatoResumo
                {
                    Id = campeonato.Id,
                    Nome = campeonato.Nome,
                    TotalRodadas = totalRodadas,
                    TotalPartidas = totalPartidas,
                    DataUltimaRodada = dataUltimaRodada
                });
            }

            return lista;
        }

        public async Task<Models.CampeonatoDetalhado> ObterDetalhesCampeonatoAsync(int campeonatoId)
        {
            var campeonato = _mapper.Map<Models.Campeonato>(await _campeonatoRepository.GetByIdAsync(campeonatoId));
            var rodadas = await _rodadaService.ObterPorCampeonatoIdAsync(campeonatoId);
            var partidas = await _partidaService.GetPartidasPorRodadaIdAsync(rodadas.Select(r => r.Id).ToList());
            foreach (var partida in partidas)
            {
                await _partidaService.PreencherTimesAsync(partida);
                await _partidaService.PreencherGolsAsync(partida);
                await _partidaService.PreencherAssistenciasAsync(partida);
            }

            var gols = partidas.SelectMany(p => p.Gols).ToList();
            var assistencias = partidas.SelectMany(p => p.Assistencias).ToList();



            var artilheiro = gols
                .GroupBy(g => g.JogadorId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var liderAssistencias = assistencias
                .GroupBy(a => a.JogadorId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var vitPorJogador = new Dictionary<string, int>();

            foreach (var partida in partidas)
            {
                var golsTime1 = partida.Gols.Count(g => partida.Time1.Jogadores.Any(j => j.Id == g.JogadorId));
                var golsTime2 = partida.Gols.Count(g => partida.Time2.Jogadores.Any(j => j.Id == g.JogadorId));

                if (golsTime1 == golsTime2 || !partida.Finalizada)
                    continue; // empate ou não finalizada

                var vencedores = golsTime1 > golsTime2 ? partida.Time1.Jogadores : partida.Time2.Jogadores;

                foreach (var jogador in vencedores)
                {
                    if (!vitPorJogador.ContainsKey(jogador.Apelido))
                        vitPorJogador[jogador.Apelido] = 0;

                    vitPorJogador[jogador.Apelido]++;
                }
            }

            var maisVitorias = vitPorJogador
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .FirstOrDefault() ?? "N/A";

            return new Models.CampeonatoDetalhado
            {
                Id = campeonato.Id,
                Nome = campeonato.Nome,
                Periodo = campeonato.Periodo,
                TotalPartidas = partidas.Count,
                TotalGols = gols.Count,
                TotalAssistencias = assistencias.Count,
                Artilheiro = await ObterApelidoJogadorAsync(artilheiro),
                LiderAssistencias = await ObterApelidoJogadorAsync(liderAssistencias),
                MaisVitorias = await ObterJogadorComMaisVitoriasAsync(campeonatoId),
                Rodadas = rodadas.Select(r => new Models.RodadaResumo
                {
                    Id = r.Id,
                    Numero = r.Numero,
                    Data = r.Data,
                    TotalPartidas = partidas.Count(p => p.RodadaId == r.Id)
                }).OrderBy(r => r.Numero).ToList()
            };
        }
        private async Task<string> ObterApelidoJogadorAsync(int jogadorId)
        {
            var jogador = await _jogadorService.GetJogadorByIdAsync(jogadorId);
            return jogador?.Apelido ?? "N/A";
        }

        public async Task<string> ObterJogadorComMaisVitoriasAsync(int campeonatoId)
        {
            var rodadas = await _rodadaService.ObterPorCampeonatoIdAsync(campeonatoId);
            var partidas = await _partidaService.GetPartidasPorRodadaIdAsync(rodadas.Select(r => r.Id).ToList());

            // Preenche times e gols das partidas
            foreach (var partida in partidas)
            {
                await _partidaService.PreencherTimesAsync(partida);
                await _partidaService.PreencherGolsAsync(partida);
            }

            var vitPorJogador = new Dictionary<string, int>();

            foreach (var partida in partidas)
            {
                int golsTime1 = partida.Gols.Count(g => partida.Time1.Jogadores.Any(j => j.Id == g.JogadorId));
                int golsTime2 = partida.Gols.Count(g => partida.Time2.Jogadores.Any(j => j.Id == g.JogadorId));

                if (golsTime1 == golsTime2)
                    continue;

                var vencedores = golsTime1 > golsTime2 ? partida.Time1.Jogadores : partida.Time2.Jogadores;

                foreach (var jogador in vencedores)
                {
                    if (!vitPorJogador.ContainsKey(jogador.Apelido))
                        vitPorJogador[jogador.Apelido] = 0;

                    vitPorJogador[jogador.Apelido]++;
                }
            }

            return vitPorJogador
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .FirstOrDefault() ?? "N/A";
        }


    }
}
