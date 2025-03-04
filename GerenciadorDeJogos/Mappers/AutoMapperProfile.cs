using AutoMapper;
using PlayMatch.Core.Models;

namespace GerenciadorDeJogos.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeia Gol para Models.Gol e vice-versa
            CreateMap<Gol, Models.Gol>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());
            CreateMap<Models.Gol, Gol>();

            // Mapeia Assistencia para Models.Assistencia e vice-versa
            CreateMap<Assistencia, Models.Assistencia>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());
            CreateMap<Models.Assistencia, Assistencia>();

            // Mapeia Partida para Models.Partida e vice-versa
            CreateMap<Partida, Models.Partida>()
                .ForMember(dest => dest.Gols, opt => opt.Ignore())
                .ForMember(dest => dest.Assistencias, opt => opt.Ignore())
                .ForMember(dest => dest.Time1, opt => opt.Ignore())
                .ForMember(dest => dest.Time2, opt => opt.Ignore());
            CreateMap<Models.Partida, Partida>();

            // Mapeia Jogador para Models.Jogador e vice-versa
            CreateMap<Jogador, Models.Jogador>();
            CreateMap<Models.Jogador, Jogador>();
        }
    }
}
