using System.Collections.ObjectModel;
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
        private ObservableCollection<Jogador> jogadores = new();

        [ObservableProperty]
        private string novoNome;

        [ObservableProperty]
        private string novoApelido;

        [ObservableProperty]
        private int id;

        public GerenciarJogadoresViewModel(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
            CarregarJogadores();
        }

        [RelayCommand]
        private async void CarregarJogadores()
        {
            var lista = await _jogadorService.GetJogadoresAsync();
            jogadores.Clear();
            foreach (var jogador in lista)
            {
                jogadores.Add(jogador);
            }
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

        [RelayCommand]
        private async Task EditarJogador()
        {
            var jogador = await _jogadorService.GetJogadorByIdAsync(Id);
            if (jogador != null && !string.IsNullOrWhiteSpace(NovoNome))
            {
                jogador.Nome = NovoNome;
                jogador.Apelido = NovoApelido;
                await _jogadorService.UpdateJogadorAsync(jogador);

                var index = jogadores.IndexOf(jogador);
                if (index != -1)
                {
                    jogadores[index] = jogador;
                }
            }
        }
    }
}
