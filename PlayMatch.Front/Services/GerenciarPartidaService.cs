using System.Timers;
using System.Text.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using PlayMatch.Front.Models;

namespace PlayMatch.Front.Services
{
    public class GerenciarPartidaService 
    {
        private readonly IJSRuntime _js;
        private readonly NavigationManager _navigation;

        public Time Time1 { get; private set; } = new Time { Jogadores = new List<Jogador>() };
        public Time Time2 { get; private set; } = new Time { Jogadores = new List<Jogador>() };
        public TimeSpan TempoRestante { get;  set; } = TimeSpan.FromMinutes(7);


        public GerenciarPartidaService(IJSRuntime js, NavigationManager navigation)
        {
            _js = js;
            _navigation = navigation;
        }

        public async Task CarregarTimesAsync()
        {
            var jsonTime1 = await _js.InvokeAsync<string>("sessionStorage.getItem", "Time1");
            var jsonTime2 = await _js.InvokeAsync<string>("sessionStorage.getItem", "Time2");

            if (!string.IsNullOrEmpty(jsonTime1))
                Time1 = JsonSerializer.Deserialize<Time>(jsonTime1);

            if (!string.IsNullOrEmpty(jsonTime2))
                Time2 = JsonSerializer.Deserialize<Time>(jsonTime2);
        }

        public void AdicionarGol(Jogador jogador) => jogador.Gols++;
        public void RemoverGol(Jogador jogador) => jogador.Gols = Math.Max(0, jogador.Gols - 1);
        public void AdicionarAssistencia(Jogador jogador) => jogador.Assistencias++;
        public void RemoverAssistencia(Jogador jogador) => jogador.Assistencias = Math.Max(0, jogador.Assistencias - 1);

        public void FinalizarPartida() => _navigation.NavigateTo("/finalizar");

    }
}
