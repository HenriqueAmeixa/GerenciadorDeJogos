using SQLite;

namespace GerenciadorDeJogos.Models
{
    public class Time
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<Jogador> Jogadores { get; set; }
    }
}
