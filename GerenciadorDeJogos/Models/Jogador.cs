using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeJogos.Models
{
    public class Jogador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }

        // Adicionando um construtor público sem parâmetros
        public Jogador() { }
    }
}
