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

        public async void FinalizarPartida()
        {
            if (PartidaAtual == null) return;
            PartidaAtual.TempoDeJogo = PartidaAtual.TempoDeJogo - TempoRestante;

            PartidaAtual.Time1 = await _timeService.AddTimeAsync(Time1);
            PartidaAtual.Time2 = await _timeService.AddTimeAsync(Time2);

            PartidaAtual.Time1Id = PartidaAtual.Time1.Id;
            PartidaAtual.Time2Id = PartidaAtual.Time2.Id;

            var entity = await _partidaRepository.InsertAsync(_mapper.Map<Partida>(PartidaAtual));
            foreach (var gol in PartidaAtual.Gols)
            {
                gol.PartidaId = entity.Id;
                await _golRepository.InsertAsync(_mapper.Map<Gol>(gol));
            }
            foreach (var assist in PartidaAtual.Assistencias)
            {
                assist.PartidaId = entity.Id;
                await _assistenciaRepository.InsertAsync(_mapper.Map<Assistencia>(assist));
            }

            foreach (var jogador in Time1.Jogadores)
            {
                await _timeService.AdicionarJogadorAoTimeAsync(PartidaAtual.Time1.Id, jogador.Id);
            }
            foreach (var jogador in Time2.Jogadores)
            {
                await _timeService.AdicionarJogadorAoTimeAsync(PartidaAtual.Time2.Id, jogador.Id);
            }

            PartidaAtual = new Models.Partida
            {
                TempoDeJogo = TimeSpan.FromMinutes(7),
                Gols = new List<Models.Gol>(),
                Assistencias = new List<Models.Assistencia>()
            };

            Time1.Jogadores.Clear();
            Time2.Jogadores.Clear();
            TempoRestante = TimeSpan.FromMinutes(7);
            _navigation.NavigateTo("/partidas");
        }

    }
}
