using SQLite;
using System.ComponentModel;

namespace GerenciadorDeJogos.Models
{
    public class Jogador: INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        [Ignore]
        public Partida PartidaAtual { get; set; }
        [Ignore]
        public int Gols => PartidaAtual?.Gols.Count(g => g.JogadorId == Id) ?? 0;
        [Ignore]
        public int Assistencias => PartidaAtual?.Assistencias.Count(a => a.JogadorId == Id) ?? 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Jogador() { }
    }
}
