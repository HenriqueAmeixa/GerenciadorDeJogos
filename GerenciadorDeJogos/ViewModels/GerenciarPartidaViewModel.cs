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

        private readonly PartidaService _partidaService;

        [ObservableProperty]
        private ObservableCollection<Partida> partidasAnteriores = new();

        public IRelayCommand CriarPartidaCommand { get; }

        public GerenciarPartidaViewModel(PartidaService partidaService)
        {
            CriarPartidaCommand = new RelayCommand(async () => await Shell.Current.GoToAsync(nameof(SelecaoJogadoresPage)));
            _partidaService = partidaService;


            CarregarPartidas();
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
            CarregarPartidas();
        }
     
    }
}
