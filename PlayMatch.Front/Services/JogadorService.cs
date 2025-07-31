using AutoMapper;
using PlayMatch.Core.Data;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using PlayMatch.Front.Models.Jogadores;

namespace PlayMatch.Front.Services
{
    public class JogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IMapper _mapper;

        public JogadorService(IJogadorRepository jogadorRepository, IMapper mapper)
        {
            _jogadorRepository = jogadorRepository;
            _mapper = mapper;
        }

        public async Task<List<Models.Jogador>> GetJogadoresAsync()
        {
            var jogadores = await _jogadorRepository.GetAllAsync();
            return jogadores.Select(j => _mapper.Map<Models.Jogador>(j)).ToList();
        }

        public async Task AddJogadorAsync(Models.Jogador jogador)
        {
            await _jogadorRepository.InsertAsync(_mapper.Map<Jogador>(jogador));
        }

        public async Task RemoveJogadorAsync(Models.Jogador jogador)
        {
            await _jogadorRepository.DeleteAsync<Jogador>(jogador.Id);
        }

        public async Task UpdateJogadorAsync(Models.Jogador jogador)
        {
            await _jogadorRepository.UpdateAsync(_mapper.Map<Jogador>(jogador));
        }
        public async Task<Models.Jogador> GetJogadorByIdAsync(int id)
        {
            var jogador = await _jogadorRepository.GetByIdAsync(id);
            return _mapper.Map<Models.Jogador>(jogador);
        }
        public async Task<List<JogadorResumoDto>> ObterJogadoresPorCampeonatoAsync(int campeonatoId)
        {
            var jogadores = await _jogadorRepository.GetByCampeonatoAsync(campeonatoId);
            return _mapper.Map<List<JogadorResumoDto>>(jogadores);
        }
        public async Task<List<JogadorResumoDto>> ObterJogadoresPorCampeonatoAsync()
        {
            var jogadores = await _jogadorRepository.GetAllAsync();
            return _mapper.Map<List<JogadorResumoDto>>(jogadores);
        }
    }
}
