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
        private readonly IAssistenciaRepository _assistenciaRepository;
        private readonly TimeService _timeService;
        private readonly IMapper _mapper;

        public PartidaService(
            IGenericRepository<Partida> partidaRepository,
            IGolRepository golRepository,
            IAssistenciaRepository assistenciaRepository,
            TimeService timeService,
            IMapper mapper
        )
        {
            _partidaRepository = partidaRepository;
            _golRepository = golRepository;
            _assistenciaRepository = assistenciaRepository;
            _timeService = timeService;
            _mapper = mapper;

        }

        public async Task<List<Partida>> GetPartidasAsync()
        {
            try
            {
                var partidas = await _partidaRepository.GetAllAsync();

                foreach (var partida in partidas)
                {
                    var gols = await _golRepository.GetByPartidaIdAsync(partida.Id);
                    partida.Gols = _mapper.Map<List<Gol>>(gols);

                    var assistenciasCore = await _assistenciaRepository.GetByPartidaIdAsync(partida.Id);
                    partida.Assistencias = _mapper.Map<List<Assistencia>>(assistenciasCore);

                    var time1 = await _timeService.GetTimeByIdAsync(partida.Time1Id);
                    var time2 = await _timeService.GetTimeByIdAsync(partida.Time2Id);
                    partida.Time1 = _mapper.Map<Time>(time1);
                    partida.Time2 = _mapper.Map<Time>(time2);

                }

                return partidas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar partidas: {ex.Message}");
                return new List<Partida>();
            }
        }

        public async Task AddPartidaAsync(Partida partida)
        {
            try
            {

                if (partida.Time1 != null)
                {
                    await _timeService.AddTimeAsync(partida.Time1);
                }

                // Inserir Time2 e obter o ID
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
