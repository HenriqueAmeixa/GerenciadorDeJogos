using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;
using GerenciadorDeJogos.Views.Pages;
using System.Collections.ObjectModel;


namespace GerenciadorDeJogos.ViewModels
{
    public partial class GerenciarPartidaViewModel : ObservableObject, IQueryAttributable
    {
        private readonly JogadorService _jogadorService;
        private readonly PartidaService _partidaService;

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresDisponiveis = new();

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresSelecionados = new();

        [ObservableProperty]
        private ObservableCollection<Partida> partidasAnteriores = new();

        public IRelayCommand CriarPartidaCommand { get; }

        public GerenciarPartidaViewModel(JogadorService jogadorService, PartidaService partidaService)
        {
            CriarPartidaCommand = new RelayCommand(async () => await Shell.Current.GoToAsync(nameof(SelecaoJogadoresPage)));
            _jogadorService = jogadorService;
            _partidaService = partidaService;

            CarregarJogadores();
            CarregarPartidas();
        }

        [RelayCommand]
        private async void CarregarJogadores()
        {
            var lista = await _jogadorService.GetJogadoresAsync();
            JogadoresDisponiveis.Clear();
            JogadoresSelecionados.Clear();
            foreach (var jogador in lista)
            {
                JogadoresDisponiveis.Add(jogador);
            }
        }

        [RelayCommand]
        private async void CarregarPartidas()
        {
            var lista = await _partidaService.GetPartidasAsync();
            PartidasAnteriores.Clear();
            foreach (var partida in lista)
            {
                PartidasAnteriores.Add(partida);
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            CarregarJogadores();
            CarregarPartidas();
        }

        [RelayCommand]
        private void SelecionarJogador(Jogador jogador)
        {
            if (jogador != null && !JogadoresSelecionados.Contains(jogador) && JogadoresSelecionados.Count < 6)
            {
                JogadoresDisponiveis.Remove(jogador);
                JogadoresSelecionados.Add(jogador);
            }
        }

        [RelayCommand]
        private void RemoverJogador(Jogador jogador)
        {
            if (jogador != null && JogadoresSelecionados.Contains(jogador))
            {
                JogadoresSelecionados.Remove(jogador);
                JogadoresDisponiveis.Add(jogador);
            }
        }

        [RelayCommand]
        private async void AvancarParaSorteio()
        {
            if (JogadoresSelecionados.Count < 2)
            {
                await Shell.Current.DisplayAlert("Aviso", "Selecione pelo menos 2 jogadores para continuar.", "OK");
                return;
            }

            var parametros = new Dictionary<string, object>
            {
                { "JogadoresSelecionados", JogadoresSelecionados.ToList() }
            };

            await Shell.Current.GoToAsync(nameof(SorteioTimesPage), parametros);
        }
    }
}
