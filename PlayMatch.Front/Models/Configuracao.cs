
namespace PlayMatch.Front.Models
{
    public class Configuracao
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; } = String.Empty;
        public string Tipo { get; set; } = String.Empty;

        public bool ValorBool
        {
            get => bool.TryParse(Valor, out var result) && result;
            set => Valor = value.ToString();
        }
    }
}
