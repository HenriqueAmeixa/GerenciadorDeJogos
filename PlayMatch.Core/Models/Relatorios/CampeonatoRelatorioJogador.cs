namespace PlayMatch.Core.Models.Relatorios
{
    public class CampeonatoRelatorioJogador
    {
        public int JogadorId { get; set; }
        public string Apelido { get; set; } = string.Empty;
        public int Vitorias { get; set; }
        public int Gols { get; set; }
        public int Assistencias { get; set; }
    }
}
