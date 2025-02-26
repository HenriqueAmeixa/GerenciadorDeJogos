using SQLite;

namespace GerenciadorDeJogos.Models
{
    public class Partida
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DataHora { get; set; }

        public int TimeAId { get; set; }
        [Ignore]
        public Time TimeA { get; set; }

        public int TimeBId { get; set; }
        [Ignore]
        public Time TimeB { get; set; }
        [Ignore]
        public List<Jogador> JogadoresSelecionados { get; set; }

        public bool Finalizada { get; set; }
        public TimeSpan TempoDeJogo { get; set; }
    }
}
