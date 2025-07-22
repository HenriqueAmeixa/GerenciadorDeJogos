using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using AutoMapper;

namespace PlayMatch.Front.Services
{
    public class CampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly IMapper _mapper;
        public CampeonatoService(ICampeonatoRepository campeonatoRepository, IMapper mapper)
        {
            _campeonatoRepository = campeonatoRepository;
            _mapper = mapper;
        }
        public async Task<List<Models.Campeonato>> ObterTodosAsync()
        {
            var campeonatos = await _campeonatoRepository.ObterTodosAsync();
            return _mapper.Map<List<Models.Campeonato>>(campeonatos);
        }

        public async Task<Models.Campeonato?> ObterPorIdAsync(int id)
        {
            var campeonato = await _campeonatoRepository.ObterPorIdAsync(id);
            return campeonato == null ? null : _mapper.Map<Models.Campeonato>(campeonato);
        }

        public async Task InserirAsync(Models.Campeonato campeonato)
        {
            await _campeonatoRepository.InserirAsync(_mapper.Map<Campeonato>(campeonato));
        }

        public async Task AtualizarAsync(Campeonato campeonato)
        {
            await _campeonatoRepository.AtualizarAsync(_mapper.Map<Campeonato>(campeonato));
        }

        public async Task RemoverAsync(int id)
        {
            await _campeonatoRepository.RemoverAsync(id);
        }
    }
}
