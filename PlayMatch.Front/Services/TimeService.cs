using PlayMatch.Core.Data;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using AutoMapper;

namespace PlayMatch.Front.Services
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

        public async Task<Models.Time> GetTimeByIdAsync(int timeId)
        {
            var time = await _timeRepository.GetByIdAsync(timeId);
            if (time != null)
            {
                var jogadores = await _timeJogadorRepository.GetJogadoresPorTimeAsync(time.Id);
                time.Jogadores = _mapper.Map<List<Jogador>>(jogadores);
            }
            return _mapper.Map<Models.Time>(time);
        }

        public async Task<List<Models.Time>> GetTimesAsync()
        {
            var times = await _timeRepository.GetAllAsync();
            foreach (var time in times)
            {
                var jogadores = await _timeJogadorRepository.GetJogadoresPorTimeAsync(time.Id);
                time.Jogadores = _mapper.Map<List<Jogador>>(jogadores);
            }
            return _mapper.Map<List<Models.Time>>(times);
        }

        public async Task<Models.Time> AddTimeAsync(Models.Time time)
        {
            var entity = await _timeRepository.InsertAsync(_mapper.Map<Time>(time));
            return _mapper.Map<Models.Time>(entity);  
        }

        public async Task RemoveTimeAsync(Models.Time time)
        {
            await _timeRepository.DeleteAsync(_mapper.Map<Time>(time));
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
