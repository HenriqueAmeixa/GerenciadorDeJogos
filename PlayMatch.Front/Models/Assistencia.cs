
namespace PlayMatch.Front.Models
{
    public class Assistencia
    {

        public int Id { get; set; }
        public int PartidaId { get; set; }
        public int JogadorId { get; set; }
        public Partida Partida { get; set; }
        public Jogador Jogador { get; set; }
    }
}
