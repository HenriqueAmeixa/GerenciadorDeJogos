using AutoMapper;
using PlayMatch.Core.Models;

namespace PlayMatch.Front.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Gol, Models.Gol>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());
            CreateMap<Models.Gol, Gol>();

    
            CreateMap<Assistencia, Models.Assistencia>()
                .ForMember(dest => dest.Partida, opt => opt.Ignore());
            CreateMap<Models.Assistencia, Assistencia>();

 
            CreateMap<Partida, Models.Partida>()
                .ForMember(dest => dest.Gols, opt => opt.Ignore())
                .ForMember(dest => dest.Assistencias, opt => opt.Ignore())
                .ForMember(dest => dest.Time1, opt => opt.Ignore())
                .ForMember(dest => dest.Time2, opt => opt.Ignore());
            CreateMap<Models.Partida, Partida>();

            CreateMap<Jogador, Models.Jogador>();
            CreateMap<Models.Jogador, Jogador>();

            CreateMap<Time, Models.Time>();
            CreateMap<Models.Time, Time>();

            CreateMap<Configuracao, Models.Configuracao>();
            CreateMap<Models.Configuracao, Configuracao>();

            CreateMap<Rodada, Models.Rodada>();
            CreateMap<Models.Rodada, Rodada>();

            CreateMap<Campeonato, Models.Campeonato>()
                .ForMember(dest => dest.Rodadas, opt => opt.Ignore());
            CreateMap<Models.Campeonato, Campeonato>();
        }
    }
}
