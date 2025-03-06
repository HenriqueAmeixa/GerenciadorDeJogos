using PlayMatch.Front.Pages;

namespace PlayMatch.Front
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashPage();
        }
    }
}
