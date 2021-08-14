using RockPaperScissors.Services.Enum;
using RockPaperScissors.Services.Interface;

namespace RockPaperScissors.Services.Concrete
{
    public class Player : IPlayer
    {
        private readonly string name;
        private HandSign handSign;

        public Player(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }

        public HandSign HandSign { get => handSign; set => handSign = value; }
        public PlayerType PlayerType => name.ToUpper() == "CPU" ? PlayerType.Cpu : PlayerType.Human;
    }
}
