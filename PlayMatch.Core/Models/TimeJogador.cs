using SQLite;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlayMatch.Core.Models
{
    public class TimeJogador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TimeId { get; set; }
        public int JogadorId { get; set; }
    }
}
