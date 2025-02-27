using SQLite;
using System.Collections.ObjectModel;

namespace GerenciadorDeJogos.Models
{
    public class Time
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public ObservableCollection<Jogador> Jogadores { get; set; } = new ObservableCollection<Jogador>();
    }
}
