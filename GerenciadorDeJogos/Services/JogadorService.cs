using PlayMatch.Core.Data;
using GerenciadorDeJogos.Models;

namespace GerenciadorDeJogos.Services
{
    public class JogadorService
    {
        private readonly IGenericRepository<Jogador> _jogadorRepository;

        public JogadorService(IGenericRepository<Jogador> jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public async Task<List<Jogador>> GetJogadoresAsync()
        {
            return await _jogadorRepository.GetAllAsync();
        }

        public async Task AddJogadorAsync(Jogador jogador)
        {
            await _jogadorRepository.InsertAsync(jogador);
        }

        public async Task RemoveJogadorAsync(Jogador jogador)
        {
            await _jogadorRepository.DeleteAsync(jogador);
        }
    }
}
