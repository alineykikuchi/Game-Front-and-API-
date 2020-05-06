using Games.Api.Models.Models;
using Games.Models;
using Games.Servicos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Games.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        protected RockPaperScissors rockPaperScissors;
        protected List<PartidaModel> listaPartidas;

        public RockPaperScissorsController()
        {
            rockPaperScissors = new RockPaperScissors();
            listaPartidas = new List<PartidaModel>();
        }

        // GET: RockPaperScissors
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult ConsultaEstrategias()
        {
            var retorno = rockPaperScissors.ConsultaEstrategias();

            var teste = Json(JsonConvert.SerializeObject(retorno.Dados));
            return teste;
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult InserirPartida(PartidaModelPresentation cadastroPartida)
        {
            var partida = new PartidaModel();

            var jogada1 = new JogadaModel();
            var jogada2 = new JogadaModel();

            jogada1.NamePlayer = cadastroPartida.NamePlayer1;
            jogada1.Strategy = cadastroPartida.Strategy1;
            jogada1.NameStrategy = cadastroPartida.NameStrategy1;

            jogada2.NamePlayer = cadastroPartida.NamePlayer2;
            jogada2.Strategy = cadastroPartida.Strategy2;
            jogada2.NameStrategy = cadastroPartida.NameStrategy2;

            partida.Ordem = cadastroPartida.Ordem;
            partida.ListaJogadas = new List<JogadaModel>();

            partida.ListaJogadas.Add(jogada1);
            partida.ListaJogadas.Add(jogada2);

            if(Session["listaPartidas"] != null)
                listaPartidas = (List<PartidaModel>)Session["listaPartidas"];

            listaPartidas.Add(partida);
            Session["listaPartidas"] = listaPartidas;
            var teste = Json(JsonConvert.SerializeObject(listaPartidas));
            return teste;
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult VerificaVencedor()
        {
            if (Session["listaPartidas"] != null)
                listaPartidas = (List<PartidaModel>)Session["listaPartidas"];


            var torneio = new TorneioModel();
            torneio.ListaPartidas = listaPartidas;

            var winner = rockPaperScissors.RetornaVencedorTorneio(torneio);

            string mensagem = string.Format("Parabéns {0} com sua jogada mestre {1}!", winner.Dados.NamePlayer, winner.Dados.NameStrategy);
            
            return Json(JsonConvert.SerializeObject(mensagem));
        }
    }
}