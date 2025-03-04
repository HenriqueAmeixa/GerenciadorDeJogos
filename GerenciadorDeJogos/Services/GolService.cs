using PlayMatch.Core.Data;
using GerenciadorDeJogos.Models;

namespace GerenciadorDeJogos.Services
{
    public class GolService
    {
        private readonly IGenericRepository<Gol> _golRepository;

        public GolService(IGenericRepository<Gol> golRepository)
        {
            _golRepository = golRepository;
        }

        public async Task<List<Gol>> GetGolsAsync()
        {
            return await _golRepository.GetAllAsync();
        }

        public async Task AddGolAsync(Gol gol)
        {
            await _golRepository.InsertAsync(gol);
        }

        public async Task RemoveGolAsync(Gol gol)
        {
            await _golRepository.DeleteAsync(gol);
        }
    }
}
