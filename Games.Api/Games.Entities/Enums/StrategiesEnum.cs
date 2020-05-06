using Games.Tools.Extensions;
using System.ComponentModel;

namespace Games.Entities.Enums
{
    public enum StrategiesEnum
    {
        [DataValue("R"), Description("Pedra")]
        Rock = 1,

        [DataValue("P"), Description("Papel")]
        Paper = 2,

        [DataValue("S"), Description("Tesoura")]
        Scissors = 3
    }
}
