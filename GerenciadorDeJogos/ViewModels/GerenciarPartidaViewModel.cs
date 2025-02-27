using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;
using GerenciadorDeJogos.Views.Pages;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class GerenciarPartidaViewModel : ObservableObject, IQueryAttributable
    {
        public IRelayCommand CriarPartidaCommand { get; }
        private readonly JogadorService _jogadorService;

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresDisponiveis = new();

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresSelecionados = new();

        public GerenciarPartidaViewModel(JogadorService jogadorService)
        {
            CriarPartidaCommand = new RelayCommand(async () => await Shell.Current.GoToAsync(nameof(SelecaoJogadoresPage)));
            _jogadorService = jogadorService;
            CarregarJogadores();
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            CarregarJogadores();
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
                await Shell.Current.DisplayAlert("Erro", "Selecione pelo menos 2 jogadores para continuar.", "OK");
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
