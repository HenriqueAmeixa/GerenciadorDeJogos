namespace PlayMatch.Front.Models.Jogadores
{
    public class AvaliacaoTecnicaDto
    {
        public int? Id { get; set; } // pode ser null em criação
        public int JogadorId { get; set; }
        public int? CampeonatoId { get; set; }

        // Patinação
        public int Curvas { get; set; }
        public int Estamina { get; set; }
        public int Aceleracao { get; set; }
        public int Frenagem { get; set; }
        public int Transicao { get; set; }

        // Ataque
        public int Chute { get; set; }
        public int StickHandle { get; set; }
        public int Protecao { get; set; }
        public int Conducao { get; set; }
        public int Finalizacao { get; set; }

        // Defesa
        public int Marcacao { get; set; }
        public int DefesaGol { get; set; }
        public int Antecipacao { get; set; }
        public int Desarme { get; set; }
        public int Recuperacao { get; set; }

        // Articulação
        public int Passe { get; set; }
        public int Estrategia { get; set; }
        public int FatorDecisivo { get; set; }
        public int Comunicacao { get; set; }
        public int Posicionamento { get; set; }
    }
}
