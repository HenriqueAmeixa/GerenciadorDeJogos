using PlayMatch.Core.Data;
using PlayMatch.Core.Models;
using PlayMatch.Core.Data.Interfaces;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class PartidaService
    {
        //private readonly IGenericRepository<Partida> _partidaRepository;
        private readonly IGolRepository _golRepository;
        private readonly IGenericRepository<Jogador> _jogadorRepository;
        private readonly IAssistenciaRepository _assistenciaRepository;
        private readonly IPartidaRepository _partidaRepository;
        private readonly TimeService _timeService;
        private readonly IMapper _mapper;

        public PartidaService(
            IPartidaRepository partidaRepository,
            IGolRepository golRepository,
            IAssistenciaRepository assistenciaRepository,
            IGenericRepository<Jogador> jogadorRepository,
            TimeService timeService,
            IMapper mapper
        )
        {
            _partidaRepository = partidaRepository;
            _jogadorRepository = jogadorRepository;
            _golRepository = golRepository;
            _assistenciaRepository = assistenciaRepository;
            _timeService = timeService;
            _mapper = mapper;

        }
        public async Task<List<Models.Partida>> GetPartidasPorRodadaIdAsync(int rodadaId)
        {
            var partidasCore = await _partidaRepository.ObterPorRodadaIdAsync(rodadaId);
            var partidas = _mapper.Map<List<Models.Partida>>(partidasCore);
            foreach (var partida in _mapper.Map<List<Models.Partida>>(partidas))
            {
                await PreencherTimesAsync(partida);
                await PreencherGolsAsync(partida);
                await PreencherAssistenciasAsync(partida);
            }

            return partidas;
        }

        public async Task<List<Models.Partida>> GetPartidasAsync()
        {
            var partidasCore = await _partidaRepository.GetAllAsync();

            var partidas = _mapper.Map<List<Models.Partida>>(partidasCore);
            foreach (var partida in _mapper.Map<List<Models.Partida>>(partidas))
            {
                await PreencherTimesAsync(partida);
                await PreencherGolsAsync(partida);
                await PreencherAssistenciasAsync(partida);
            }

            return partidas;
        }

        private async Task PreencherTimesAsync(Models.Partida partida)
        {
            partida.Time1 = _mapper.Map<Models.Time>(await _timeService.GetTimeByIdAsync(partida.Time1Id));
            partida.Time2 = _mapper.Map<Models.Time>(await _timeService.GetTimeByIdAsync(partida.Time2Id));
        }

        private async Task PreencherGolsAsync(Models.Partida partida)
        {
            var gols = await _golRepository.GetByPartidaIdAsync(partida.Id);
            foreach (var gol in gols)
            {
                var jogador = EncontrarJogadorNoTime(partida, gol.JogadorId);
                if (jogador != null)
                {
                    jogador.Gols++;
                }
            }
            partida.Gols = _mapper.Map<List<Models.Gol>>(gols);
        }

        private async Task PreencherAssistenciasAsync(Models.Partida partida)
        {
            var assistencias = await _assistenciaRepository.GetByPartidaIdAsync(partida.Id);
            foreach (var assistencia in assistencias)
            {
                var jogador = EncontrarJogadorNoTime(partida, assistencia.JogadorId);
                if (jogador != null)
                {
                    jogador.Assistencias++;
                }
            }
            partida.Assistencias = _mapper.Map<List<Models.Assistencia>>(assistencias);
        }

        private Models.Jogador EncontrarJogadorNoTime(Models.Partida partida, int jogadorId)
        {
            return partida.Time1.Jogadores.FirstOrDefault(j => j.Id == jogadorId) ??
                   partida.Time2.Jogadores.FirstOrDefault(j => j.Id == jogadorId);
        }


        public async Task AddPartidaAsync(Models.Partida partida)
        {
            try
            {

                if (partida.Time1 != null)
                {
                    await _timeService.AddTimeAsync(partida.Time1);
                }

                if (partida.Time2 != null)
                {
                    await _timeService.AddTimeAsync(partida.Time2);
                }


                partida.Time1Id = partida.Time1.Id;
                partida.Time2Id = partida.Time2.Id;

                await _partidaRepository.InsertAsync(_mapper.Map<Partida>(partida));

                if (partida.Gols != null && partida.Gols.Any())
                {
                    foreach (var gol in partida.Gols)
                    {
                        gol.PartidaId = partida.Id;
                        await _golRepository.InsertAsync(new PlayMatch.Core.Models.Gol
                        {
                            Id = gol.Id,
                            PartidaId = gol.PartidaId,
                            JogadorId = gol.JogadorId,
                            MomentoGol = gol.MomentoGol
                        });
                    }
                }

                if (partida.Assistencias != null && partida.Assistencias.Any())
                {
                    foreach (var assistencia in partida.Assistencias)
                    {
                        assistencia.PartidaId = partida.Id;
                        await _assistenciaRepository.InsertAsync(new PlayMatch.Core.Models.Assistencia
                        {
                            Id = assistencia.Id,
                            PartidaId = assistencia.PartidaId,
                            JogadorId = assistencia.JogadorId
                        });
                    }
                }

                if (partida.Time1?.Jogadores != null)
                {
                    foreach (var jogador in partida.Time1.Jogadores)
                    {
                        await _timeService.AdicionarJogadorAoTimeAsync(partida.Time1.Id, jogador.Id);
                    }
                }

                if (partida.Time2?.Jogadores != null)
                {
                    foreach (var jogador in partida.Time2.Jogadores)
                    {
                        await _timeService.AdicionarJogadorAoTimeAsync(partida.Time2.Id, jogador.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar a partida: {ex.Message}");
            }
        }

        public async Task ExcluirPartidaAsync(int partidaId)
        {
            var partida = await _partidaRepository.GetByIdAsync(partidaId);
            if (partida == null) return;

            // Excluir gols e assistências
            var gols = await _golRepository.GetByPartidaIdAsync(partidaId);
            var assistencias = await _assistenciaRepository.GetByPartidaIdAsync(partidaId);

            await Task.WhenAll(
                Task.WhenAll(gols.Select(g => _golRepository.DeleteAsync<Gol>(g.Id))),
                Task.WhenAll(assistencias.Select(a => _assistenciaRepository.DeleteAsync<Assistencia>(a.Id)))
            );

            // Remover jogadores dos times
            var jogadoresTime1 = await _timeService.GetJogadoresDoTimeAsync(partida.Time1Id);
            var jogadoresTime2 = await _timeService.GetJogadoresDoTimeAsync(partida.Time2Id);

            await Task.WhenAll(
                Task.WhenAll(jogadoresTime1.Select(j => _timeService.RemoverJogadorDoTimeAsync(partida.Time1Id, j.Id))),
                Task.WhenAll(jogadoresTime2.Select(j => _timeService.RemoverJogadorDoTimeAsync(partida.Time2Id, j.Id)))
            );

            // Excluir times
            await Task.WhenAll(
                _timeService.RemoveTimeAsync(partida.Time1Id),
                _timeService.RemoveTimeAsync(partida.Time2Id)
            );

            // Excluir a partida
            await _partidaRepository.DeleteAsync<Partida>(partida.Id);
        }
        public async Task<List<Models.Jogador>> GetVencedoresUltimaPartidaAsync()
        {
            // Busca o ID do último time vencedor
            var timeVencedorId = await GetUltimoTimeVencedorAsync();

            // Se não houver vencedor, retorna lista vazia
            if (timeVencedorId == null)
                return new List<Models.Jogador>();

            // Usa o TimeService para buscar os jogadores do time vencedor
            return await _timeService.GetJogadoresDoTimeAsync(timeVencedorId.Value);
        }



        public async Task<int?> GetUltimoTimeVencedorAsync()
        {
            var partidas = await GetPartidasAsync();

            var ultimaPartida = partidas
                .OrderByDescending(p => p.DataHora)
                .FirstOrDefault();

            if (ultimaPartida == null)
                return null;

            if (ultimaPartida.PlacarTime1 > ultimaPartida.PlacarTime2)
                return ultimaPartida.Time1Id;
            else if (ultimaPartida.PlacarTime2 > ultimaPartida.PlacarTime1)
                return ultimaPartida.Time2Id;
            return null;
        }



    }
}
