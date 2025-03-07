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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartLoading();
        }

        private async void StartLoading()
        {
            // Inicia a rota��o enquanto aguarda o Blazor carregar
            _ = AnimateRotation();

            // Aguarda o Blazor carregar antes de sair da Splash Screen
            await WaitForBlazorToLoad();

            // Muda para a p�gina principal
            Application.Current.MainPage = new MainPage();
        }

        private async Task WaitForBlazorToLoad()
        {
            var tcs = new TaskCompletionSource<bool>();

            // Inscreve-se no evento para saber quando o Blazor carregou
            MainPage.BlazorCarregado += () => tcs.TrySetResult(true);

            // Espera at� o evento ser disparado (tempo limite de 10s para seguran�a)
            await Task.WhenAny(tcs.Task, Task.Delay(10000));
        }

        private async Task AnimateRotation()
        {
            while (true) // Mant�m a rota��o at� o Blazor carregar
            {
                await LoadingImage.RotateTo(360, 2000);
                LoadingImage.Rotation = 0;
                await Task.Delay(100);
            }
        }
    }
}
