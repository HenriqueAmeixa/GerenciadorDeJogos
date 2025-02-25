using SQLite;

namespace PlayMatch.Core.Models
{
    public class Jogador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
    }
}
