using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Views.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class SorteioTimesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresSelecionados = new();

        [ObservableProperty]
        private Time time1 = new() { Jogadores = new ObservableCollection<Jogador>() };

        [ObservableProperty]
        private Time time2 = new() { Jogadores = new ObservableCollection<Jogador>() };

        public SorteioTimesViewModel()
        {
        }

        public void SetJogadoresSelecionados(List<Jogador> jogadores)
        {
            JogadoresSelecionados.Clear();
            foreach (var jogador in jogadores)
            {
                JogadoresSelecionados.Add(jogador);
            }
        }


        [RelayCommand]
        public void SortearTimes()
        {
            var random = new Random();
            var jogadores = JogadoresSelecionados?.ToList() ?? new List<Jogador>();

            if (jogadores.Count < 2)
                return;

            var totalJogadores = jogadores.Count;
            var metadeJogadores = totalJogadores / 2;

            var time1Temp = new List<Jogador>();
            var time2Temp = new List<Jogador>();

            for (int i = 0; i < metadeJogadores; i++)
            {
                var index = random.Next(jogadores.Count);
                time1Temp.Add(jogadores[index]);
                jogadores.RemoveAt(index);
            }

            time2Temp.AddRange(jogadores);

            // Criar novas instâncias para forçar atualização da UI
            Time1 = new Time { Jogadores = new ObservableCollection<Jogador>(time1Temp) };
            Time2 = new Time { Jogadores = new ObservableCollection<Jogador>(time2Temp) };
        }
        [RelayCommand]
        public async void IrParaPartida()
        {
            var parametros = new Dictionary<string, object>
            {
                { "Time1", Time1 },
                { "Time2", Time2 }
            };
            await Shell.Current.GoToAsync(nameof(PartidaPage), parametros);
        }
    }
}
