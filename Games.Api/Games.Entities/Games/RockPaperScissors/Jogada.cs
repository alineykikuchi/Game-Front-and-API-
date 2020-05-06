using Games.Entities.Enums;

namespace Games.Entities.Games.RockPaperScissors
{
    public class Jogada
    {
        public string NamePlayer { get; set; }

        public StrategiesEnum Strategy { get; set; }

        public int IdPartida { get; set; }

        public Partida Partida { get; set; }
    }
}
