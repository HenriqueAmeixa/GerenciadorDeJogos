namespace PlayMatch.Front.Models.Relatorios
{
    public class RodadaRelatorioJogador
    {
        public int JogadorId { get; set; }
        public string Apelido { get; set; } = string.Empty;
        public int Gols { get; set; }
        public int Assistencias { get; set; }
    }
}
