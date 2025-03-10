
namespace PlayMatch.Front.Models
{
    public class Configuracao
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; } = String.Empty;
        public string Tipo { get; set; } = String.Empty;
    }
}
