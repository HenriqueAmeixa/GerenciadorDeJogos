using PlayMatch.Core.Data;
using PlayMatch.Core.Data.Interfaces;
using GerenciadorDeJogos.Models;
using AutoMapper;
using System.Collections.ObjectModel;

namespace GerenciadorDeJogos.Services
{
    public class TimeService
    {
        private readonly IGenericRepository<Time> _timeRepository;
        private readonly ITimeJogadorRepository _timeJogadorRepository;
        private readonly IMapper _mapper;

        public TimeService(IGenericRepository<Time> timeRepository, ITimeJogadorRepository timeJogadorRepository, IMapper mapper)
        {
            _timeRepository = timeRepository;
            _timeJogadorRepository = timeJogadorRepository;
            _mapper = mapper;
        }

        public async Task<Time> GetTimeByIdAsync(int timeId)
        {
            var time = await _timeRepository.GetByIdAsync(timeId);
            if (time != null)
            {
                var jogadores = await _timeJogadorRepository.GetJogadoresPorTimeAsync(time.Id);
                time.Jogadores = _mapper.Map<ObservableCollection<Jogador>>(jogadores);
            }
            return time;
        }

        public async Task<List<Time>> GetTimesAsync()
        {
            var times = await _timeRepository.GetAllAsync();
            foreach (var time in times)
            {
                var jogadores = await _timeJogadorRepository.GetJogadoresPorTimeAsync(time.Id);
                time.Jogadores = _mapper.Map<ObservableCollection<Jogador>>(jogadores);
            }
            return times;
        }

        public async Task AddTimeAsync(Time time)
        {
            await _timeRepository.InsertAsync(time);
        }

        public async Task RemoveTimeAsync(Time time)
        {
            await _timeRepository.DeleteAsync(time);
        }

        public async Task AdicionarJogadorAoTimeAsync(int timeId, int jogadorId)
        {
            await _timeJogadorRepository.InserirRelacionamentoAsync(timeId, jogadorId);
        }

        public async Task RemoverJogadorDoTimeAsync(int timeId, int jogadorId)
        {
            await _timeJogadorRepository.RemoverRelacionamentoAsync(timeId, jogadorId);
        }
    }
}
