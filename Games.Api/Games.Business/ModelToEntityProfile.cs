using AutoMapper;
using Games.Api.Models.Models;
using Games.Entities.Enums;
using Games.Entities.Games.RockPaperScissors;
using Games.Tools.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace Games.Business
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            var listStrategiesEnum = EnumDataExtension.GetDataValues<StrategiesEnum>(typeof(StrategiesEnum));

            CreateMap<TorneioModel, Torneio>();

            CreateMap<PartidaModel, Partida>()
                .ForMember(x => x.ListaJogadas, opt => opt.MapFrom(x => Mapper.Map<List<JogadaModel>>(x.ListaJogadas)));

            CreateMap<JogadaModel, Jogada>()
                .ForMember(x => x.Strategy, opt => opt.MapFrom(x => listStrategiesEnum.FirstOrDefault(y => y.GetDatavalue().Equals(x.Strategy))));
        }
    }
}
