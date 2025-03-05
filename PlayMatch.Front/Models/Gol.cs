
namespace PlayMatch.Front.Models
{
    public class Gol
    {
        public int Id { get; set; }

        public int PartidaId { get; set; }
        public int JogadorId { get; set; }
        public TimeSpan MomentoGol { get; set; }

        public Partida Partida { get; set; }

        public Jogador Jogador { get; set; }
    }
}
