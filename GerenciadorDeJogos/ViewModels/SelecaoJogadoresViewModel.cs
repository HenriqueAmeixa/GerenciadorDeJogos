using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;
using GerenciadorDeJogos.Views.Pages;
using System.Collections.ObjectModel;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class SelecaoJogadoresViewModel : ObservableObject
    {
        private readonly JogadorService _jogadorService;
        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresDisponiveis = new();

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresSelecionados = new();
        public SelecaoJogadoresViewModel(JogadorService jogadorService)
        {
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
