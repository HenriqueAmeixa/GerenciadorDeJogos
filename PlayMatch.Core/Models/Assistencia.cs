using SQLite;

namespace PlayMatch.Core.Models
{
    public class Assistencia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PartidaId { get; set; }
        public int JogadorId { get; set; }

        [Ignore]
        public Partida Partida { get; set; }

        [Ignore]
        public Jogador Jogador { get; set; }
    }
}
