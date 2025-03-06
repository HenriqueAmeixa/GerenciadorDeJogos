using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace PlayMatch.Front.Pages
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            StartLoading();
        }

        private async void StartLoading()
        {
            // Inicia a animação de rotação infinita
            _ = AnimateRotation();

            // Simula um carregamento de 3 segundos
            await Task.Delay(3000);

            // Muda para a tela principal com Blazor WebView
            Application.Current.MainPage = new MainPage();
        }

        private async Task AnimateRotation()
        {
            while (true) // Roda infinitamente até a página ser trocada
            {
                await LoadingImage.RotateTo(360, 1000); // Roda 360° em 1s
                LoadingImage.Rotation = 0; // Reseta a rotação para 0° e continua
            }
        }
    }
}
