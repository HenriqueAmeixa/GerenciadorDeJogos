
using System.Collections.ObjectModel;

namespace PlayMatch.Front.Models
{
    public class Time
    {
        public int Id { get; set; }
        public ObservableCollection<Jogador> Jogadores { get; set; } = new ObservableCollection<Jogador>();
    }
}
