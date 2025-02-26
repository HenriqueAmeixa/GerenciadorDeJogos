﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMatch.Core.Models
{
    public class Gol
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int PartidaId { get; set; }  
        public int JogadorId { get; set; }  
        public int? AssistenteId { get; set; }  
        public TimeSpan MomentoGol { get; set; }

        [Ignore]
        public Partida Partida { get; set; }

        [Ignore]
        public Jogador Jogador { get; set; }

        [Ignore]
        public Jogador? Assistente { get; set; }
    }

}
