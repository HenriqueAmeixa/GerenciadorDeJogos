using AutoMapper;
using PlayMatch.Core.Models;

namespace GerenciadorDeJogos.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeia Gol para GolModel
            CreateMap<Gol, Models.Gol>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());

            // Mapeia Assistencia para AssistenciaModel
            CreateMap<Assistencia, Models.Assistencia>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());

            CreateMap<Partida, Models.Partida>()
                .ForMember(dest => dest.Gols, opt => opt.Ignore())
                .ForMember(dest => dest.Assistencias, opt => opt.Ignore())
                .ForMember(dest => dest.Time1, opt => opt.Ignore())
                .ForMember(dest => dest.Time2, opt => opt.Ignore());

            CreateMap<Models.Jogador, Jogador>();
        }
    }
}
