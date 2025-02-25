using System.Collections.ObjectModel;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GerenciadorDeJogos.ViewModels
{
    public class PartidaViewModel : ObservableObject
    {
        private readonly PartidaService _partidaService;
        private readonly JogadorService _jogadorService;

        public ObservableCollection<Jogador> JogadoresDisponiveis { get; set; }
        public ObservableCollection<Jogador> JogadoresSelecionados { get; set; }
        public ObservableCollection<Jogador> TimeA { get; set; }
        public ObservableCollection<Jogador> TimeB { get; set; }

        public IRelayCommand SortearTimesCommand { get; }
        public IRelayCommand IniciarPartidaCommand { get; }

        public PartidaViewModel(PartidaService partidaService, JogadorService jogadorService)
        {
            _partidaService = partidaService;
            _jogadorService = jogadorService;

            JogadoresDisponiveis = new ObservableCollection<Jogador>();
            JogadoresSelecionados = new ObservableCollection<Jogador>();
            TimeA = new ObservableCollection<Jogador>();
            TimeB = new ObservableCollection<Jogador>();

            SortearTimesCommand = new RelayCommand(SortearTimes);
            IniciarPartidaCommand = new RelayCommand(IniciarPartida);

            CarregarJogadoresDisponiveis();
        }

        private async void CarregarJogadoresDisponiveis()
        {
            var jogadores = await _jogadorService.GetJogadoresAsync();
            foreach (var jogador in jogadores)
            {
                JogadoresDisponiveis.Add(jogador);
            }
        }

        public void SelecionarJogador(Jogador jogador)
        {
            if (!JogadoresSelecionados.Contains(jogador))
            {
                JogadoresSelecionados.Add(jogador);
            }
        }

        public void SortearTimes()
        {
            var random = new Random();
            var jogadoresEmbaralhados = JogadoresSelecionados.OrderBy(j => random.Next()).ToList();

            TimeA.Clear();
            TimeB.Clear();

            for (int i = 0; i < jogadoresEmbaralhados.Count; i++)
            {
                if (i % 2 == 0)
                {
                    TimeA.Add(jogadoresEmbaralhados[i]);
                }
                else
                {
                    TimeB.Add(jogadoresEmbaralhados[i]);
                }
            }
        }

        public async void IniciarPartida()
        {
            var partida = new Partida
            {
                DataHora = DateTime.Now,
                TimeA = new Time { Jogadores = TimeA.ToList() },
                TimeB = new Time { Jogadores = TimeB.ToList() },
                JogadoresSelecionados = JogadoresSelecionados.ToList(),
                Finalizada = false,
                TempoDeJogo = TimeSpan.Zero
            };

            await _partidaService.AddPartidaAsync(partida);
        }
    }
}
