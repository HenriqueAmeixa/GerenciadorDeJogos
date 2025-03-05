using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.ViewModels;

namespace GerenciadorDeJogos.Views.Pages;

[QueryProperty(nameof(Time1), "Time1")]
[QueryProperty(nameof(Time2), "Time2")]

public partial class PartidaPage : ContentPage
{
    private Time _time1;
    private Time _time2;
    public Time Time1
    {
        get => _time1;
        set
        {
            _time1 = value;
            OnPropertyChanged();
            if (BindingContext is PartidaViewModel viewModel)
            {
                viewModel.SetTimesSelecionados(_time1, _time2);
            }
        }
    }
    public Time Time2
    {
        get => _time2;
        set
        {
            _time2 = value;
            OnPropertyChanged();
            if (BindingContext is PartidaViewModel viewModel)
            {
                viewModel.SetTimesSelecionados(_time1, _time2);
            }
        }
    }
    public PartidaPage(PartidaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
