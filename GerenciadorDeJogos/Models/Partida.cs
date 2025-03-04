using SQLite;

namespace GerenciadorDeJogos.Models
{
    public class Partida
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public int Time1Id { get; set; }
        [Ignore]
        public Time Time1 { get; set; }

        public int Time2Id { get; set; }
        [Ignore]
        public Time Time2 { get; set; }

        public bool Finalizada { get; set; }
        public TimeSpan TempoDeJogo { get; set; }

        [Ignore]
        public List<Gol> Gols { get; set; } = new List<Gol>();

        [Ignore]
        public List<Assistencia> Assistencias { get; set; } = new List<Assistencia>();

        [Ignore]
        public List<Jogador> JogadoresSelecionados { get; set; } = new List<Jogador>();


        public string DataFormatada => DataHora.ToString("dd/MM/yyyy HH:mm");

        public string TempoDeJogoFormatado => $"{TempoDeJogo.Minutes:D2}:{TempoDeJogo.Seconds:D2}";

        public int PlacarTime1 => Gols.Count(g => Time1?.Jogadores?.Any(j => j.Id == g.JogadorId) == true);

        public int PlacarTime2 => Gols.Count(g => Time2?.Jogadores?.Any(j => j.Id == g.JogadorId) == true);

        public List<string?> Goleadores => Gols
            .GroupBy(g => g.JogadorId)
            .Select(grupo =>
            {
                var jogador = Time1?.Jogadores?.FirstOrDefault(j => j.Id == grupo.Key)
                           ?? Time2?.Jogadores?.FirstOrDefault(j => j.Id == grupo.Key);

                return jogador != null ? $"{jogador.Apelido} - G({grupo.Count()})" : null;
            })
            .Where(g => g != null)
            .ToList();
    }
}
