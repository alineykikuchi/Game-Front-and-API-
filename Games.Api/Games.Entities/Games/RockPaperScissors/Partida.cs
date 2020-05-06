using System;
using System.Collections.Generic;

namespace Games.Entities.Games.RockPaperScissors
{
    public class Partida
    {
        public int Id { get; set; }

        public List<Jogada> ListaJogadas { get; set; }

        public int Ordem { get; set; }
    }
}
