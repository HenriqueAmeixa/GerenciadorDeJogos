
using System.Collections.ObjectModel;

namespace PlayMatch.Front.Models
{
    public class Time
    {
        public int Id { get; set; }
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();
    }
}
