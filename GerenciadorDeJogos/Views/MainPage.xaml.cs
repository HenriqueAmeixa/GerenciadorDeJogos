namespace GerenciadorDeJogos;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private void OnNovaRodadaClicked(object sender, EventArgs e)
    {
        // Implementação futura para criar nova rodada
    }
    private void OnMenuClicked(object sender, EventArgs e)
    {
        var parent = this.Parent as FlyoutPage;
        if (parent != null)
        {
            parent.IsPresented = true; 
        }
    }

}