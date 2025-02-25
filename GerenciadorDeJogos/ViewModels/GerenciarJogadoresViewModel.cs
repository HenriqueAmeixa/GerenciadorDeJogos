using System.Collections.ObjectModel;
using System.Windows.Input;
using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class GerenciarJogadoresViewModel : ObservableObject
    {
        private readonly JogadorService _jogadorService;

        [ObservableProperty]
        private ObservableCollection<Jogador> jogadores;

        [ObservableProperty]
        private string novoNome;

        [ObservableProperty]
        private string novoApelido;

        public GerenciarJogadoresViewModel(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
            jogadores = new ObservableCollection<Jogador>();
            CarregarJogadores();
        }

        private async void CarregarJogadores()
        {
            var lista = await _jogadorService.GetJogadoresAsync();
            jogadores = new ObservableCollection<Jogador>(lista);
        }

        [RelayCommand]
        private async Task AdicionarJogador()
        {
            if (!string.IsNullOrWhiteSpace(NovoNome))
            {
                var jogador = new Jogador { Nome = NovoNome, Apelido = NovoApelido };
                await _jogadorService.AddJogadorAsync(jogador);
                jogadores.Add(jogador);

                NovoNome = string.Empty;
                NovoApelido = string.Empty;
            }
        }

        [RelayCommand]
        private async Task RemoverJogador(Jogador jogador)
        {
            await _jogadorService.RemoveJogadorAsync(jogador);
            jogadores.Remove(jogador);
        }
    }
}
