using SQLite;

namespace PlayMatch.Core.Models
{
    public class Rodada
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CampeonatoId { get; set; }      
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        [Ignore]
        public Campeonato Campeonato { get; set; }
        [Ignore]
        public List<Partida> Partidas { get; set; } = new();
    }
}
