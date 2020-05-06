using Games.Api.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Games.Entities.Games.RockPaperScissors;
using Games.Entities.Enums;
using Games.Api.Models.Models;
using Games.Business.RockPaperScissors;

namespace Games.Api.Games.RockPaperScissors
{
    [RoutePrefix("api/RockPaperScissors")]
    public class RockPaperScissorsController : BaseController<RockPaperScissorsController>
    {
        protected RockPaperScissorsBusiness rockPaperScissorsBusiness;

        public RockPaperScissorsController()
        {
            rockPaperScissorsBusiness = new RockPaperScissorsBusiness();
        }

        [HttpGet]
        [Route("ConsultaEstrategias")]
        public IHttpActionResult ConsultaEstrategias()
        {
            var listEstrategias = rockPaperScissorsBusiness.ConsultaEstrategias();
            return Response(listEstrategias);
        }

        [HttpPost]
        [Route("ReturnWinner")]
        public IHttpActionResult ReturnWinner(TorneioModel torneio)
        {
            var rockPaperScissorsBusiness = new RockPaperScissorsBusiness();
            return Response(rockPaperScissorsBusiness.ReturnPlayWinner(torneio));
            
        }

        
    }
}
