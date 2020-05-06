using Games.Api.Models.Models;
using Games.Tools.GenericClientApi;
using RestSharp;
using System.Collections.Generic;

namespace Games.Servicos
{
    public class RockPaperScissors
    {
        private GenericRestApi teste = new GenericRestApi();

        public ResponseModelDados<List<EstrategiaModel>> ConsultaEstrategias()
        {
            var estrategias = new RestRequest("http://localhost:55737/api/RockPaperScissors/ConsultaEstrategias");

            var te =  teste.Executar<List<EstrategiaModel>>(null, estrategias);

            return te;



        }

        public ResponseModelDados<JogadaModel> RetornaVencedorTorneio(TorneioModel torneio)
        {

            var request = new RestRequest();
            
            var estrategias = new RestRequest("http://localhost:55737/api/RockPaperScissors/ReturnWinner");


            estrategias.Method = Method.POST;
            estrategias.AddHeader("Accept", "application/json");
            estrategias.AddJsonBody(torneio);

            return teste.Executar<JogadaModel>(torneio, estrategias);

        }
    }
}