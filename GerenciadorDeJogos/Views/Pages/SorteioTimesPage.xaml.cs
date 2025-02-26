using GerenciadorDeJogos.Models;

namespace GerenciadorDeJogos.Views.Pages;

[QueryProperty(nameof(JogadoresSelecionados), "JogadoresSelecionados")]
public partial class SorteioTimesPage : ContentPage
{
    private List<Jogador> _jogadoresSelecionados;
    public List<Jogador> JogadoresSelecionados
    {
        get => _jogadoresSelecionados;
        set
        {
            _jogadoresSelecionados = value;
            OnPropertyChanged();
        }
    }

    public SorteioTimesPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
