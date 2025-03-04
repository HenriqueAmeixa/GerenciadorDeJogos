
namespace PlayMatch.Front.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public Partida PartidaAtual { get; set; }
        public int Gols { get; set; }
        public int Assistencias { get; set; }
        public Jogador() { }
    }
}
