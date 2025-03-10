
using SQLite;

namespace PlayMatch.Core.Models
{
    public class Configuracao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed, NotNull]
        public string Chave { get; set; }
        [NotNull]
        public string Valor { get; set; } = String.Empty;
        [NotNull]
        public string Tipo { get; set; } = String.Empty;
    }
}
