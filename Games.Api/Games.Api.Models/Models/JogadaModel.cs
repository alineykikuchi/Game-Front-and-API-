using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Api.Models.Models
{
    public class JogadaModel
    {
        public string NamePlayer { get; set; }
        public string Strategy { get; set; }
        public string NameStrategy { get; set; }

        public int IdPartida { get; set; }
        public PartidaModel PartidaModel { get; set; }
    }
}
