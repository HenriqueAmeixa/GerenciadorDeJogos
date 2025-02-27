using GerenciadorDeJogos.ViewModels;

namespace GerenciadorDeJogos.Views.Pages;

public partial class SelecaoJogadoresPage : ContentPage
{
	public SelecaoJogadoresPage(GerenciarPartidaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}