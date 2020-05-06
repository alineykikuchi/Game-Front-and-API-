using Games.Api.Models.Enums;
using Games.Tools.GenericClientApi;
using System.Collections.Generic;
using System.Web.Http;

namespace Games.Api.Controllers
{
    public abstract class BaseController<T> : ApiController
    {
        protected IHttpActionResult Response<W>(W content, List<string> mensagens)
        {
            var response = new ResponseModelDados<W>
            {
                Mensagens = mensagens,
                StatusRetorno = !Equals(content, default(W)) ? TiposErro.Success : TiposErro.Inesperado,
                Dados = content
            };
            return Ok(response);
        }

        protected IHttpActionResult Response<W>(W content)
        {
            return Response(content, null as List<string>);
        }
    }
}
