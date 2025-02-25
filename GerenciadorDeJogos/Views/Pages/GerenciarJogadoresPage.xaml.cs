using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.ViewModels;
namespace GerenciadorDeJogos.Views.Pages;

public partial class GerenciarJogadoresPage : ContentPage
{
    public GerenciarJogadoresPage(GerenciarJogadoresViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
