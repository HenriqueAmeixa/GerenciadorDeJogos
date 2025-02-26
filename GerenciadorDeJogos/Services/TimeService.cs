using PlayMatch.Core.Data;
using GerenciadorDeJogos.Models;

namespace GerenciadorDeJogos.Services
{
    public class TimeService
    {
        private readonly IGenericRepository<Time> _timeRepository;

        public TimeService(IGenericRepository<Time> timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<List<Time>> GetTimesAsync()
        {
            return await _timeRepository.GetAllAsync();
        }

        public async Task AddTimeAsync(Time time)
        {
            await _timeRepository.InsertAsync(time);
        }

        public async Task RemoveTimeAsync(Time time)
        {
            await _timeRepository.DeleteAsync(time);
        }
    }
}
