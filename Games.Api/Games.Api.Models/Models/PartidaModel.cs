using System;
using System.Collections.Generic;

namespace Games.Api.Models.Models
{
    public class PartidaModel
    {
        public int Id { get; set; }

        public List<JogadaModel> ListaJogadas { get; set; }

        public int Ordem { get; set; }
    }
}
