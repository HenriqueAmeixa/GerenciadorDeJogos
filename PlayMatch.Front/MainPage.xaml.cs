using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls;
using System;

namespace PlayMatch.Front
{
    public partial class MainPage : ContentPage
    {
        public static event Action? BlazorCarregado; // Evento para indicar que o Blazor foi carregado

        public MainPage()
        {
            InitializeComponent();
            SetBannerId();
        }

        private void SetBannerId()
        {
#if __ANDROID__
            AdView.AdsId = "ca-app-pub-9624517469952283/9810019717";
            //AdView.AdsId = "ca-app-pub-3940256099942544/6300978111";

#endif
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BlazorCarregado?.Invoke();
        }
    }
}
