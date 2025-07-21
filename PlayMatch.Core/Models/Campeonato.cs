using SQLite;

namespace PlayMatch.Core.Models
{
    public class Campeonato
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        [Ignore]
        public List<Rodada> Rodadas { get; set; } = new();
    }
}
