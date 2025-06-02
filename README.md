# 📱 PlayMatch

**PlayMatch** é um aplicativo desenvolvido em .NET MAUI com foco na gestão de partidas esportivas recreativas, como futsal entre amigos. Ele permite o controle completo de partidas, desde a seleção dos jogadores até o registro de estatísticas individuais, funcionando localmente com banco SQLite.

---

## 🎯 Objetivo

O objetivo do PlayMatch é oferecer uma forma rápida e intuitiva de organizar partidas casuais, registrar eventos do jogo (como gols e assistências) e acompanhar o desempenho dos jogadores ao longo do tempo.

---

## ⚙️ Funcionalidades principais

- Cadastro de jogadores com nome e informações básicas.
- Criação de partidas com sorteio automático dos times.
- Controle de tempo de partida com temporizador configurável (ex: 7 minutos).
- Registro de gols e assistências para cada jogador durante a partida.
- Exibição de estatísticas individuais e da partida.
- Geração de relatórios por rodada e jogador.
- Armazenamento local em SQLite com datas em UTC e consideração do fuso de São Paulo para exibição.

---

## 🧱 Arquitetura

O PlayMatch está estruturado com:

- **Entidades principais**: `Jogador`, `Partida`, `Time`, `Gol`, `Assistencia`, `Rodada`, `Torneio`.
- **Relacionamentos**:
  - Uma `Partida` tem dois `Times`.
  - Cada `Time` tem até 3 `Jogadores`.
  - `Gols` e `Assistencias` estão associados à `Partida` e a um `Jogador`.
- **Persistência**: SQLite com EF Core (ou abstração própria) para acesso local.
- **Interface**: Blazor MAUI com atualização em tempo real dos dados da partida.

---

## 🕹️ Modo de uso

1. Abra o app e cadastre os jogadores.
2. Inicie uma nova partida e selecione os 6 jogadores.
3. Sorteie os times automaticamente.
4. Durante a partida, registre gols e assistências com os botões (+ / -).
5. Ao final, visualize as estatísticas e salve a partida.

---

## 🔄 Futuras melhorias

- Modo torneio com gestão completa de rodadas.
- Rankings individuais por performance.
- Exportação de relatórios em PDF.
- Integração com serviços online para sincronização dos dados.
- Interface para visualização de histórico completo por jogador.

---

## 👨‍💻 Tecnologias utilizadas

- .NET MAUI + Blazor para interface multiplataforma.
- SQLite para armazenamento local.
- C# como linguagem principal.
- Timezone convertido entre UTC (persistência) e São Paulo (exibição).

---

## 📄 Licença

Este projeto é de uso pessoal/educacional. O código pode ser adaptado e redistribuído livremente com os devidos créditos ao autor.
