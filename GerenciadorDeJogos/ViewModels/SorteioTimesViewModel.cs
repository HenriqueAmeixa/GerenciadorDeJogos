using CommunityToolkit.Mvvm.ComponentModel;
using GerenciadorDeJogos.Models;
using System.Collections.ObjectModel;

namespace GerenciadorDeJogos.ViewModels
{
    public partial class SorteioTimesViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private ObservableCollection<Jogador> jogadoresParaSortear = new();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("JogadoresSelecionados"))
            {
                var jogadores = query["JogadoresSelecionados"] as List<Jogador>;
                if (jogadores != null)
                {
                    JogadoresParaSortear = new ObservableCollection<Jogador>(jogadores);
                }
            }
        }
    }
}
