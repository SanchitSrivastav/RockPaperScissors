using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Interface;
using System;

namespace RockPaperScissors.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            IGameRunner game = new GameRunner(3);

            game.Start();

            Console.ReadKey();
        }
    }
}
