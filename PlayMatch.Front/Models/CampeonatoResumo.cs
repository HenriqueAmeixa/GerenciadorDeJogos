namespace PlayMatch.Front.Models
{
    public class CampeonatoResumo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TotalRodadas { get; set; }
        public int TotalPartidas { get; set; }
        public DateTime? DataUltimaRodada { get; set; }
    }
}
