using PlayMatch.Core.Data;
using PlayMatch.Front.Models;
using PlayMatch.Core.Data.Interfaces;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class PartidaService
    {
        private readonly IGenericRepository<Partida> _partidaRepository;
        private readonly IGolRepository _golRepository;
        private readonly IGenericRepository<Jogador> _jogadorRepository;
        private readonly IAssistenciaRepository _assistenciaRepository;
        private readonly TimeService _timeService;
        private readonly IMapper _mapper;

        public PartidaService(
            IGenericRepository<Partida> partidaRepository,
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

        public async Task<List<Partida>> GetPartidasAsync()
        {
            var partidas = await _partidaRepository.GetAllAsync();

            foreach (var partida in partidas)
            {
                await PreencherTimesAsync(partida);
                await PreencherGolsAsync(partida);
                await PreencherAssistenciasAsync(partida);
            }

            return partidas;
        }

        private async Task PreencherTimesAsync(Partida partida)
        {
            partida.Time1 = _mapper.Map<Time>(await _timeService.GetTimeByIdAsync(partida.Time1Id));
            partida.Time2 = _mapper.Map<Time>(await _timeService.GetTimeByIdAsync(partida.Time2Id));
        }

        private async Task PreencherGolsAsync(Partida partida)
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
            partida.Gols = _mapper.Map<List<Gol>>(gols);
        }

        private async Task PreencherAssistenciasAsync(Partida partida)
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
            partida.Assistencias = _mapper.Map<List<Assistencia>>(assistencias);
        }

        private Jogador EncontrarJogadorNoTime(Partida partida, int jogadorId)
        {
            return partida.Time1.Jogadores.FirstOrDefault(j => j.Id == jogadorId) ??
                   partida.Time2.Jogadores.FirstOrDefault(j => j.Id == jogadorId);
        }


        public async Task AddPartidaAsync(Partida partida)
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

                await _partidaRepository.InsertAsync(partida);

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

        public async Task RemovePartidaAsync(Partida partida)
        {
            try
            {
                if (partida.Gols?.Any() == true)
                {
                    foreach (var gol in partida.Gols)
                    {
                        await _golRepository.DeleteAsync(new PlayMatch.Core.Models.Gol
                        {
                            Id = gol.Id,
                            PartidaId = gol.PartidaId,
                            JogadorId = gol.JogadorId,
                            MomentoGol = gol.MomentoGol,
                            Partida = new PlayMatch.Core.Models.Partida { Id = partida.Id }
                        });
                    }
                }

                if (partida.Assistencias?.Any() == true)
                {
                    foreach (var assistencia in partida.Assistencias)
                    {
                        await _assistenciaRepository.DeleteAsync(new PlayMatch.Core.Models.Assistencia
                        {
                            Id = assistencia.Id,
                            PartidaId = assistencia.PartidaId,
                            JogadorId = assistencia.JogadorId,
                            Partida = new PlayMatch.Core.Models.Partida { Id = partida.Id }
                        });
                    }
                }

                if (partida.Time1 != null)
                {
                    await _timeService.RemoveTimeAsync(partida.Time1);
                }

                if (partida.Time2 != null)
                {
                    await _timeService.RemoveTimeAsync(partida.Time2);
                }

                await _partidaRepository.DeleteAsync(partida);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover a partida: {ex.Message}");
            }
        }
    }
}
