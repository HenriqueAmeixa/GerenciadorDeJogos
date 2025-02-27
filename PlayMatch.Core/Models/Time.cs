using SQLite;

namespace PlayMatch.Core.Models
{
    public class Time
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<Jogador> Jogadores { get; set; }
    }
}
