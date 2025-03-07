using System.Text.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Data;
using PlayMatch.Core.Models;

namespace PlayMatch.Front.Services
{
    public class GerenciarPartidaService 
    {
        private readonly IJSRuntime _js;
        private readonly NavigationManager _navigation;

        public Models.Time Time1 { get; private set; } = new Models.Time { Jogadores = new List<Models.Jogador>() };
        public Models.Time Time2 { get; private set; } = new Models.Time { Jogadores = new List<Models.Jogador>() };
        public TimeSpan TempoRestante { get;  set; } = TimeSpan.FromMinutes(7);
        private Models.Partida PartidaAtual;
        private readonly IMapper _mapper;
        private readonly IGolRepository _golRepository;
        private readonly IAssistenciaRepository _assistenciaRepository;
        private readonly IGenericRepository<Partida> _partidaRepository;
        private readonly TimeService _timeService;


        public GerenciarPartidaService(
            IJSRuntime js,
            NavigationManager navigation,
            IMapper mapper,
            IGolRepository golRepository,
            IAssistenciaRepository assistenciaRepository,
            IGenericRepository<Partida> partidaRepository,
            TimeService timeService

            )
        {
            PartidaAtual = new Models.Partida
            {
                TempoDeJogo = TimeSpan.FromMinutes(7),
                Gols = new List<Models.Gol>(),
                Assistencias = new List<Models.Assistencia>()
            };

            _js = js;
            _navigation = navigation;
            _mapper = mapper;
            _golRepository = golRepository;
            _assistenciaRepository = assistenciaRepository;
            _partidaRepository = partidaRepository;
            _timeService = timeService;
        }

        public async Task CarregarTimesAsync()
        {
            var jsonTime1 = await _js.InvokeAsync<string>("sessionStorage.getItem", "Time1");
            var jsonTime2 = await _js.InvokeAsync<string>("sessionStorage.getItem", "Time2");

            if (!string.IsNullOrEmpty(jsonTime1))
                Time1 = JsonSerializer.Deserialize<Models.Time>(jsonTime1);

            if (!string.IsNullOrEmpty(jsonTime2))
                Time2 = JsonSerializer.Deserialize<Models.Time>(jsonTime2);
        }

        public void AdicionarGol(Models.Jogador jogador)
        {
            var tempoDecorrido = TimeSpan.FromMinutes(7) - TempoRestante; 

            var gol = new Models.Gol
            {
                PartidaId = PartidaAtual.Id,
                JogadorId = jogador.Id,
                MomentoGol = tempoDecorrido,
                Partida = PartidaAtual,
                Jogador = jogador
            };

            PartidaAtual.Gols.Add(gol);

            jogador.Gols++;
        }
        public void RemoverGol(Models.Jogador jogador)
        {
            var ultimoGol = PartidaAtual.Gols.LastOrDefault(g => g.JogadorId == jogador.Id);

            if (ultimoGol != null)
            {
                PartidaAtual.Gols.Remove(ultimoGol);
                jogador.Gols = Math.Max(0, jogador.Gols - 1);
            }
        }
        public void AdicionarAssistencia(Models.Jogador jogador)
        {
            var assistencia = new Models.Assistencia
            {
                PartidaId = PartidaAtual.Id,
                JogadorId = jogador.Id,
                Partida = PartidaAtual,
                Jogador = jogador
            };
            PartidaAtual.Assistencias.Add(assistencia);
            jogador.Assistencias++;
        }
        public void RemoverAssistencia(Models.Jogador jogador)
        {
            var ultimaAssistencia = PartidaAtual.Assistencias.LastOrDefault(g => g.JogadorId == jogador.Id);

            if (ultimaAssistencia != null)
            {
                PartidaAtual.Assistencias.Remove(ultimaAssistencia);
                jogador.Assistencias = Math.Max(0, jogador.Assistencias - 1);
            }
        }

        public async Task FinalizarPartidaAsync()
        {
            if (PartidaAtual == null) return;

            await SalvarTimesAsync();
            await SalvarPartidaAsync();
            await SalvarGolsEAssistenciasAsync();
            await AdicionarJogadoresAosTimesAsync();

            ResetarEstadoDaPartida();
            _navigation.NavigateTo("/partidas");
        }
        private async Task SalvarTimesAsync()
        {
            PartidaAtual.Time1 = await _timeService.AddTimeAsync(Time1);
            PartidaAtual.Time2 = await _timeService.AddTimeAsync(Time2);

            PartidaAtual.Time1Id = PartidaAtual.Time1.Id;
            PartidaAtual.Time2Id = PartidaAtual.Time2.Id;
        }
        private async Task SalvarPartidaAsync()
        {
            var entity = await _partidaRepository.InsertAsync(_mapper.Map<Partida>(PartidaAtual));
            PartidaAtual.Id = entity.Id;
        }
        private async Task SalvarGolsEAssistenciasAsync()
        {
            var partidaId = PartidaAtual.Id;

            var gols = PartidaAtual.Gols.Select(g =>
            {
                g.PartidaId = partidaId;
                return _mapper.Map<Gol>(g);
            });

            var assistencias = PartidaAtual.Assistencias.Select(a =>
            {
                a.PartidaId = partidaId;
                return _mapper.Map<Assistencia>(a);
            });

            await Task.WhenAll(
                Task.WhenAll(gols.Select(g => _golRepository.InsertAsync(g))),
                Task.WhenAll(assistencias.Select(a => _assistenciaRepository.InsertAsync(a)))
            );
        }
        private async Task AdicionarJogadoresAosTimesAsync()
        {
            var tasks = new List<Task>();

            tasks.AddRange(Time1.Jogadores.Select(j => _timeService.AdicionarJogadorAoTimeAsync(PartidaAtual.Time1.Id, j.Id)));
            tasks.AddRange(Time2.Jogadores.Select(j => _timeService.AdicionarJogadorAoTimeAsync(PartidaAtual.Time2.Id, j.Id)));

            await Task.WhenAll(tasks);
        }
        private void ResetarEstadoDaPartida()
        {
            PartidaAtual = new Models.Partida
            {
                TempoDeJogo = TimeSpan.FromMinutes(7),
                Gols = new List<Models.Gol>(),
                Assistencias = new List<Models.Assistencia>()
            };

            Time1.Jogadores.Clear();
            Time2.Jogadores.Clear();
            TempoRestante = TimeSpan.FromMinutes(7);
        }
    }
}
