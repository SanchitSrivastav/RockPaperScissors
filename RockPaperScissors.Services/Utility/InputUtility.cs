using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Interface;
using System;

namespace RockPaperScissors.Services.Utility
{
    public class InputUtility
    {
        public string GetUserName()
        {
            Console.Write(DisplayMessages.WelcomeMessage);
            string name = Console.ReadLine();
            Console.Write(DisplayMessages.WelcomeMessageForUser, name);
            return name;
        }

        public void StartGameMessage(IPlayer player, int gameNumber)
        {
            Console.Write(DisplayMessages.StartGameMessage, player.Name, ++gameNumber);
        }

        public HandSign ChooseHandSign()
        {
            Console.Write(DisplayMessages.ChooseHandSignMessage);
            string input = Console.ReadLine();
            var handSign = HandSign.MapStringToMove(input);

            if (handSign == null)
            {
                Console.Write(DisplayMessages.InvalidHandSignMessage);
                return ChooseHandSign();
            }
            return handSign;
        }
        public void WinnerMessage(IPlayer player, int gameNumber)
        {
            if (player == null)
            {
                Console.Write(DisplayMessages.WinnerMessageDraw, ++gameNumber);
            }
            else
            {
                Console.Write(DisplayMessages.WinnerMessagePlayer, player.Name, ++gameNumber);
            }
        }

        public void OverallWinnerMessage(IPlayer player, int maxWinCount)
        {
            if (player == null)
            {
                Console.Write(DisplayMessages.OverallWinnerMessageDraw, maxWinCount);
            }
            else
            {
                Console.Write(DisplayMessages.OverallWinnerMessagePlayer, player.Name, maxWinCount);
            }
        }

    }
}
