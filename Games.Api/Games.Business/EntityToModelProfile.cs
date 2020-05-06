using Games.Api.Models.Models;
using AutoMapper;
using System.Collections.Generic;
using Games.Entities.Games.RockPaperScissors;
using Games.Tools.Extensions;

namespace Games.Business
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Torneio, TorneioModel>();

            CreateMap<Partida, PartidaModel>()
                .ForMember(x => x.ListaJogadas, opt => opt.MapFrom(x => Mapper.Map<List<Jogada>>(x.ListaJogadas)));

            CreateMap<Jogada, JogadaModel>()
                .ForMember(x => x.Strategy, opt => opt.MapFrom(x => x.Strategy.GetDatavalue()))
                .ForMember(x => x.NameStrategy, opt => opt.MapFrom(x => x.Strategy.Description()));
        }
    }
}
