
namespace PlayMatch.Front.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public Partida PartidaAtual { get; set; }
        public int Gols => PartidaAtual?.Gols.Count(g => g.JogadorId == Id) ?? 0;
        public int Assistencias => PartidaAtual?.Assistencias.Count(a => a.JogadorId == Id) ?? 0;
        public Jogador() { }
    }
}
