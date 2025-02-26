using PlayMatch.Core.Data;
using GerenciadorDeJogos.Models;

namespace GerenciadorDeJogos.Services
{
    public class PartidaService
    {
        private readonly IGenericRepository<Partida> _partidaRepository;

        public PartidaService(IGenericRepository<Partida> partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }

        public async Task<List<Partida>> GetPartidasAsync()
        {
            return await _partidaRepository.GetAllAsync();
        }

        public async Task AddPartidaAsync(Partida partida)
        {
            await _partidaRepository.InsertAsync(partida);
        }

        public async Task RemovePartidaAsync(Partida partida)
        {
            await _partidaRepository.DeleteAsync(partida);
        }
    }
}
