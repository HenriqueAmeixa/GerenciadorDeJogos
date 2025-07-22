namespace PlayMatch.Front.Models
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public List<Rodada> Rodadas { get; set; } = new();
    }
}
