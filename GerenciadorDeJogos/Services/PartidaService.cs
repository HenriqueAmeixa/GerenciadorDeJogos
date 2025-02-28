using AutoMapper;
using GerenciadorDeJogos.Models;
using PlayMatch.Core.Data;
using PlayMatch.Core.Data.Interfaces;

namespace GerenciadorDeJogos.Services
{
    public class PartidaService
    {
        private readonly IGenericRepository<Partida> _partidaRepository;
        private readonly IGolRepository _golRepository;
        private readonly IAssistenciaRepository _assistenciaRepository;
        private readonly IGenericRepository<Time> _timeRepository;
        private readonly IMapper _mapper;

        public PartidaService(
            IGenericRepository<Partida> partidaRepository,
            IGolRepository golRepository,
            IAssistenciaRepository assistenciaRepository,
            IGenericRepository<Time> timeRepository,
            IMapper mapper
        )
        {
            _partidaRepository = partidaRepository;
            _golRepository = golRepository;
            _assistenciaRepository = assistenciaRepository;
            _timeRepository = timeRepository;
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

                    partida.Time1 = await _timeRepository.GetByIdAsync(partida.Time1Id);
                    partida.Time2 = await _timeRepository.GetByIdAsync(partida.Time2Id);
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

                if (partida.Time1 != null)
                {
                    partida.Time1.PartidaId = partida.Id;
                    await _timeRepository.InsertAsync(partida.Time1);
                }

                if (partida.Time2 != null)
                {
                    partida.Time2.PartidaId = partida.Id;
                    await _timeRepository.InsertAsync(partida.Time2);
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
                    await _timeRepository.DeleteAsync(partida.Time1);
                }

                if (partida.Time2 != null)
                {
                    await _timeRepository.DeleteAsync(partida.Time2);
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
