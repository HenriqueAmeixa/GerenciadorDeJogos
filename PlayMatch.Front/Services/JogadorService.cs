using PlayMatch.Core.Data;
using PlayMatch.Front.Models;

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

        public async Task UpdateJogadorAsync(Jogador jogador)
        {
            await _jogadorRepository.UpdateAsync(jogador);
        }
        public async Task<Jogador> GetJogadorByIdAsync(int id)
        {
            return await _jogadorRepository.GetByIdAsync(id);
        }
        
    }
}
