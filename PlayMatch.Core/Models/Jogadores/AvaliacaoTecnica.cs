using SQLite;

namespace PlayMatch.Core.Models.Jogadores
{
    public class AvaliacaoTecnica
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int JogadorId { get; set; }
        public int? CampeonatoId { get; set; }

        public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;

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

        // Métodos com validação de regra de negócio (use apenas esses para alteração programática)
        public void SetCurvas(int valor) => Curvas = ValidarNota(valor, nameof(Curvas));
        public void SetEstamina(int valor) => Estamina = ValidarNota(valor, nameof(Estamina));
        public void SetAceleracao(int valor) => Aceleracao = ValidarNota(valor, nameof(Aceleracao));
        public void SetFrenagem(int valor) => Frenagem = ValidarNota(valor, nameof(Frenagem));
        public void SetTransicao(int valor) => Transicao = ValidarNota(valor, nameof(Transicao));

        public void SetChute(int valor) => Chute = ValidarNota(valor, nameof(Chute));
        public void SetStickHandle(int valor) => StickHandle = ValidarNota(valor, nameof(StickHandle));
        public void SetProtecao(int valor) => Protecao = ValidarNota(valor, nameof(Protecao));
        public void SetConducao(int valor) => Conducao = ValidarNota(valor, nameof(Conducao));
        public void SetFinalizacao(int valor) => Finalizacao = ValidarNota(valor, nameof(Finalizacao));

        public void SetMarcacao(int valor) => Marcacao = ValidarNota(valor, nameof(Marcacao));
        public void SetDefesaGol(int valor) => DefesaGol = ValidarNota(valor, nameof(DefesaGol));
        public void SetAntecipacao(int valor) => Antecipacao = ValidarNota(valor, nameof(Antecipacao));
        public void SetDesarme(int valor) => Desarme = ValidarNota(valor, nameof(Desarme));
        public void SetRecuperacao(int valor) => Recuperacao = ValidarNota(valor, nameof(Recuperacao));

        public void SetPasse(int valor) => Passe = ValidarNota(valor, nameof(Passe));
        public void SetEstrategia(int valor) => Estrategia = ValidarNota(valor, nameof(Estrategia));
        public void SetFatorDecisivo(int valor) => FatorDecisivo = ValidarNota(valor, nameof(FatorDecisivo));
        public void SetComunicacao(int valor) => Comunicacao = ValidarNota(valor, nameof(Comunicacao));
        public void SetPosicionamento(int valor) => Posicionamento = ValidarNota(valor, nameof(Posicionamento));

        private int ValidarNota(int valor, string campo)
        {
            if (valor < 0 || valor > 10)
                throw new ArgumentOutOfRangeException(campo, "A nota deve estar entre 0 e 10.");
            return valor;
        }
    }
}
