using System.Collections.ObjectModel;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class PartidaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Partida partidaAtual;

        [ObservableProperty]
        private Time time1 = new() { Jogadores = new ObservableCollection<Jogador>() };

        [ObservableProperty]
        private Time time2 = new() { Jogadores = new ObservableCollection<Jogador>() };

        [ObservableProperty]
        private TimeSpan tempoRestante = TimeSpan.FromMinutes(7);
        [ObservableProperty]
        private bool timerRodando = false;

        private System.Timers.Timer _timer;

        private bool _timerEmExecucao;

        public PartidaViewModel()
        {
            PartidaAtual = new Partida
            {
                TempoDeJogo = TimeSpan.FromMinutes(7),
                Gols = new List<Gol>(),
                Assistencias = new List<Assistencia>()
            };
        }

        public void SetTimesSelecionados(Time timeaux1, Time timeaux2)
        {
            Time1.Jogadores.Clear();
            Time2.Jogadores.Clear();

            if (timeaux1 != null)
            {
                foreach (var jogador in timeaux1.Jogadores)
                {
                    Time1.Jogadores.Add(jogador);
                }
            }

            if (timeaux2 != null)
            {
                foreach (var jogador in timeaux2.Jogadores)
                {
                    Time2.Jogadores.Add(jogador);
                }
            }
        }

        [RelayCommand]
        public void IniciarOuPausarTimer()
        {
            if (_timer == null)
            {
                _timer = new System.Timers.Timer(1000);
                _timer.Elapsed += TimerElapsed;
                _timer.AutoReset = true;
            }

            if (_timerEmExecucao)
            {
                _timer.Stop();
                TimerRodando = false;
            }
            else
            {
                _timer.Start();
                TimerRodando = true;
            }

            _timerEmExecucao = !_timerEmExecucao;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (TempoRestante.TotalSeconds > 0)
            {
                TempoRestante = TempoRestante.Subtract(TimeSpan.FromSeconds(1));
                OnPropertyChanged(nameof(TempoRestante));
            }
            else
            {
                _timer.Stop();
                _timerEmExecucao = false;
            }
        }

        [RelayCommand]
        public async Task AdicionarGol(Jogador jogador)
        {
            if (PartidaAtual == null) return;

            var novoGol = new Gol
            {
                PartidaId = PartidaAtual.Id,
                JogadorId = jogador.Id,
                MomentoGol = PartidaAtual.TempoDeJogo - TempoRestante
            };

            PartidaAtual.Gols.Add(novoGol);

            jogador.PartidaAtual = PartidaAtual;
            jogador.OnPropertyChanged(nameof(Jogador.Gols));

            OnPropertyChanged(nameof(PartidaAtual));
        }

        [RelayCommand]
        public async Task RemoverGol(Jogador jogador)
        {
            if (PartidaAtual == null) return;

            var ultimoGol = PartidaAtual.Gols.LastOrDefault(g => g.JogadorId == jogador.Id);
            if (ultimoGol != null)
            {
                PartidaAtual.Gols.Remove(ultimoGol);

                jogador.PartidaAtual = PartidaAtual;
                jogador.OnPropertyChanged(nameof(Jogador.Gols));
                OnPropertyChanged(nameof(PartidaAtual));
            }
        }

        [RelayCommand]
        public async Task AdicionarAssistencia(Jogador jogador)
        {
            if (PartidaAtual == null) return;

            var novaAssistencia = new Assistencia
            {
                PartidaId = PartidaAtual.Id,
                JogadorId = jogador.Id
            };

            PartidaAtual.Assistencias.Add(novaAssistencia);
            jogador.PartidaAtual = PartidaAtual;
            jogador.OnPropertyChanged(nameof(Jogador.Assistencias));
            OnPropertyChanged(nameof(PartidaAtual));
        }

        [RelayCommand]
        public async Task RemoverAssistencia(Jogador jogador)
        {
            if (PartidaAtual == null) return;

            var ultimaAssistencia = PartidaAtual.Assistencias.LastOrDefault(a => a.JogadorId == jogador.Id);

            if (ultimaAssistencia != null)
            {
                PartidaAtual.Assistencias.Remove(ultimaAssistencia);
                jogador.PartidaAtual = PartidaAtual;
                jogador.OnPropertyChanged(nameof(Jogador.Assistencias));
                OnPropertyChanged(nameof(PartidaAtual));
            }
        }
    }
}
