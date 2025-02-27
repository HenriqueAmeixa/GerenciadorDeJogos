using GerenciadorDeJogos.Views.Pages;

namespace GerenciadorDeJogos.Views.Navigation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SelecaoJogadoresPage), typeof(SelecaoJogadoresPage));
        Routing.RegisterRoute(nameof(SorteioTimesPage), typeof(SorteioTimesPage));
    }
}
