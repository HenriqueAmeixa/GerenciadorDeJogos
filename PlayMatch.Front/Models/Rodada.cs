namespace PlayMatch.Front.Models
{
    public class Rodada
    {
        public int Id { get; set; }
        public int CampeonatoId { get; set; }
        public int Numero { get; set; }
        public Campeonato Campeonato { get; set; }
        public List<Partida> Partidas { get; set; } = new();
    }
}
