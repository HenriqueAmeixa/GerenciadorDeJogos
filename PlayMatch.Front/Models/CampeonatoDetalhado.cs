namespace PlayMatch.Front.Models
{
    public class CampeonatoDetalhado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public int TotalPartidas { get; set; }
        public int TotalGols { get; set; }
        public int TotalAssistencias { get; set; }
        public string Artilheiro { get; set; }
        public string LiderAssistencias { get; set; }
        public string MaisVitorias { get; set; }
        public List<RodadaResumo> Rodadas { get; set; }
    }
}
