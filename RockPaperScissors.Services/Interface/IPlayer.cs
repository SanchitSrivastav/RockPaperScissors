using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Enum;

namespace RockPaperScissors.Services.Interface
{
    public interface IPlayer
    {
        string Name { get; }
        HandSign HandSign { get; set; }
        PlayerType PlayerType { get; }
    }
}
