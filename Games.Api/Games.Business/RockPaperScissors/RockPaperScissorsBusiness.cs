using AutoMapper;
using System.Linq;
using Games.Api.Models.Models;
using Games.Entities.Enums;
using Games.Entities.Games.RockPaperScissors;
using System.Collections.Generic;
using Games.Tools.Extensions;

namespace Games.Business.RockPaperScissors
{
    public class RockPaperScissorsBusiness
    {
        public List<EstrategiaModel> ConsultaEstrategias()
        {
            var listStrategiesEnum = EnumDataExtension.GetDataValues<StrategiesEnum>(typeof(StrategiesEnum));

            var listValues = new List<EstrategiaModel>();

            foreach (var estrategy in listStrategiesEnum)
            {
                var item = new EstrategiaModel();
                item.Chave = char.Parse(estrategy.GetDatavalue());
                item.Estrategia = estrategy.Description();

                listValues.Add(item);
            }

            return listValues;

        }

        public JogadaModel ReturnPlayWinner(TorneioModel torneioModel)
        {
            if(torneioModel.ListaPartidas.Any(x => x.ListaJogadas.Count != 2))
                return null;
            
            var jogadas = torneioModel.ListaPartidas.SelectMany(x => x.ListaJogadas);

            jogadas = jogadas.Where(x => !(x.Strategy.Equals("S") || x.Strategy.Contains("P") || x.Strategy.Contains("R")));

            if(jogadas.Count() > 0)
            {
                string returnString = "Partidas inválidas! Verifiquem as partidas: ";

                jogadas.ToList().ForEach(x =>
                    returnString += string.Format("\n jogador {0}, partida {1}", x.NamePlayer, x.PartidaModel.Ordem)
                );
            }
            
            var torneio = Mapper.Map<Torneio>(torneioModel);

            var winner = RetornaVencedorTorneio(torneio);

            return Mapper.Map<JogadaModel>(winner);
        }

        private Jogada RetornaVencedorTorneio(Torneio torneio)
        {
            while (torneio.ListaPartidas.Count() >= 1)
            {
                var novoTorneio = new Torneio();
                novoTorneio.ListaPartidas = new List<Partida>();
                var novaPartida = new Partida();
                novaPartida.ListaJogadas = new List<Jogada>();
                int ordemJogada = 0;

                foreach (var partida in torneio.ListaPartidas.OrderByDescending(x => x.Ordem))
                {
                    if (partida.ListaJogadas.Count() == 2)
                        novaPartida.ListaJogadas.Add(CheckPlayWinner(partida.ListaJogadas));

                    else
                        novaPartida.ListaJogadas.Add(partida.ListaJogadas.First());

                    novaPartida.Ordem = ordemJogada;

                    if (novaPartida.ListaJogadas.Count() == 2)
                    {
                        novaPartida = new Partida();
                        novaPartida.ListaJogadas = new List<Jogada>();
                        ordemJogada += 1;
                    }
                    else
                        novoTorneio.ListaPartidas.Add(novaPartida);
                }
                torneio = novoTorneio;

                if (torneio.ListaPartidas.Count() == 1 && torneio.ListaPartidas.First().ListaJogadas.Count() == 1)
                    break;
            }
            return torneio.ListaPartidas.First().ListaJogadas.First();
        }

        private Jogada CheckPlayWinner(List<Jogada> listPlay)
        {
            if (listPlay.First().Strategy == listPlay.Last().Strategy)
                return listPlay.First();

            else if (listPlay.Any(x => x.Strategy == StrategiesEnum.Rock) && listPlay.Any(x => x.Strategy == StrategiesEnum.Scissors))
                return listPlay.FirstOrDefault(x => x.Strategy == StrategiesEnum.Rock);

            else if (listPlay.Any(x => x.Strategy == StrategiesEnum.Scissors) && listPlay.Any(x => x.Strategy == StrategiesEnum.Paper))
                return listPlay.FirstOrDefault(x => x.Strategy == StrategiesEnum.Scissors);

            else
                return listPlay.FirstOrDefault(x => x.Strategy == StrategiesEnum.Paper);
        }
    }
}
