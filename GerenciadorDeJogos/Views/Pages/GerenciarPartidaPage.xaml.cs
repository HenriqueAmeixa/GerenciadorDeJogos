using GerenciadorDeJogos.ViewModels;

namespace GerenciadorDeJogos.Views.Pages;

public partial class GerenciarPartidaPage : ContentPage
{
	public GerenciarPartidaPage(GerenciarPartidaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}