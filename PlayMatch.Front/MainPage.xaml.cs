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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Dispara o evento quando a página é carregada
            BlazorCarregado?.Invoke();
        }
    }
}
