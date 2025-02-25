using GerenciadorDeJogos.Models;
using GerenciadorDeJogos.ViewModels;
namespace GerenciadorDeJogos.Views.Pages;

public partial class GerenciarJogadoresPage : ContentPage
{
    public GerenciarJogadoresPage()
    {
        InitializeComponent();
    }

    private void RemoverJogador()
    {

    }
    private void AdicionarJogador_Clicked(object sender, EventArgs e)
    {
        string nome = NomeEntry.Text;
        string apelido = ApelidoEntry.Text;

        // Lógica para criar um novo jogador com os dados fornecidos
        Jogador novoJogador = new Jogador(nome, apelido);

        // Adicionar o novo jogador à lista de jogadores
        (BindingContext as GerenciarJogadoresViewModel)?.AdicionarJogador(novoJogador);

        // Limpar os campos de entrada
        NomeEntry.Text = string.Empty;
        ApelidoEntry.Text = string.Empty;
    }
}
