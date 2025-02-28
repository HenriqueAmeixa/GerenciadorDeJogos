using SQLite;

namespace PlayMatch.Core.Models
{
    public class Partida
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public int Time1Id { get; set; }
        [Ignore]
        public Time Time1 { get; set; }

        public int Time2Id { get; set; }
        [Ignore]
        public Time Time2 { get; set; }

        [Ignore]
        public List<Jogador> JogadoresSelecionados { get; set; }

        public bool Finalizada { get; set; }

        public TimeSpan TempoDeJogo { get; set; }

        [Ignore]
        public List<Gol> Gols { get; set; } = new List<Gol>();
        [Ignore]
        public List<Assistencia> Assistencias { get; set; } = new List<Assistencia>();
    }
}
