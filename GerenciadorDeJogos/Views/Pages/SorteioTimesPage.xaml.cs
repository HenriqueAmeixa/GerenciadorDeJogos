using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.ViewModels;

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
            if (BindingContext is SorteioTimesViewModel viewModel)
            {
                viewModel.SetJogadoresSelecionados(_jogadoresSelecionados);
            }
        }
    }

    public SorteioTimesPage(SorteioTimesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
