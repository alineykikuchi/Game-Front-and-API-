using Games.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Tools.GenericClientApi
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Mensagens = new List<string>();
        }

        private TiposErro _status;

        public TiposErro StatusRetorno
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public List<string> Mensagens { get; set; }
    }

    public class ResponseModelDados<T> : ResponseModel
    {
        public ResponseModelDados() : base()
        {

        }
        public T Dados { get; set; }
    }
}
