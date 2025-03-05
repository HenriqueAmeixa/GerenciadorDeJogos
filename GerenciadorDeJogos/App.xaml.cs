using GerenciadorDeJogos.Views.Navigation;

namespace GerenciadorDeJogos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
