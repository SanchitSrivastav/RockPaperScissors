using RockPaperScissors.Services.Enum;
using System;

namespace RockPaperScissors.Services.Concrete
{
    public class HandSign
    {
        private readonly Move _move;        

        public HandSign(Move move)
        {
            _move = move;
        }
        public Move Move => _move;

        public static HandSign MapStringToMove(string userChoice)
        {
            switch (userChoice.ToUpper())
            {
                case "P":
                    return new HandSign(Move.Paper);
                case "S":
                    return new HandSign(Move.Scissors);
                case "R":
                    return new HandSign(Move.Rock);
                default:
                    return null;
            }
        }

        public static HandSign MapRandomToMove()
        {
            Random random = new Random();

            switch (random.Next(0, 2))
            {
                case 0:
                    return new HandSign(Move.Rock);
                case 1:
                    return new HandSign(Move.Paper);
                case 2:
                    return new HandSign(Move.Scissors);
                default:
                    return null;
            }
        }
        public static Move GetWinningMove(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return Move.Paper;
                case Move.Paper:
                    return Move.Scissors;
                default:
                    return Move.Rock;
            }
        }
    }
}
