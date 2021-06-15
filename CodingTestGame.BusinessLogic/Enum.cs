using System.ComponentModel;

namespace CodingTestGame.Models
{
    public enum RockPaperScissorsEnum
    {
        [Description("Unknown")]
        Unknown = -1,
        [Description("Rock")]
        Rock = 0,
        [Description("Paper")]
        Paper = 1,
        [Description("Scissors")]
        Scissors = 2
    }
}
