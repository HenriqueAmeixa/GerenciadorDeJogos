using GerenciadorDeJogos.ViewModels;

namespace GerenciadorDeJogos.Views.Pages;

public partial class SelecaoJogadoresPage : ContentPage
{
	public SelecaoJogadoresPage(SelecaoJogadoresViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}