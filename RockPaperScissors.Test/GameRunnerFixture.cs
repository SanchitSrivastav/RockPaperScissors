using NUnit.Framework;
using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Interface;
using RockPaperScissors.Services.Utility;
using System;
using System.IO;

namespace RockPaperScissors.Test
{
    class GameRunnerFixture
    {
        private StringWriter output;
        private StringReader inputPlayerName;
        private const string humanPlayerName = "Sanchit";
        private const int gameCount = 3;
        private readonly string[] selectionInput = new string[gameCount] {"r","p","s" };        
        private IGameRunner game;

        [SetUp]
        public void Setup()
        {
            output = new StringWriter();
            inputPlayerName = new StringReader(string.Format(@"{0}
{1}
{2}
{3}",humanPlayerName, selectionInput[0], selectionInput[1], selectionInput[2]));
            game = new GameRunner(gameCount);
        }

        [Test]
        public void Constructor_HappyPath()
        {
            IGameRunner game1 = new GameRunner(gameCount);
        }
        [Test]
        public void MaxWinCount()
        {
            Console.SetOut(output);
            Console.SetIn(inputPlayerName);

            game.Start();

            Assert.That(game.MaxWinCount, Is.EqualTo(gameCount / 2 + 1));
        }

            [Test]
        public void Start()
        {

            Console.SetOut(output);
            Console.SetIn(inputPlayerName);

            game.Start();

            string finalOutputMessage = DisplayMessages.WelcomeMessage+
                string.Format(DisplayMessages.WelcomeMessageForUser, humanPlayerName);

            for (int i = 0; i < gameCount;i++)
            {
                int gameNumber=i+1;

                string startGameMessage = string.Format(DisplayMessages.StartGameMessage, humanPlayerName, gameNumber);

                string winnerName = game.Gmaes[i].WinnerPlayer?.Name;

                string winnerMessage = string.IsNullOrEmpty(winnerName) ?
                    string.Format(DisplayMessages.WinnerMessageDraw, gameNumber) :
                    string.Format(DisplayMessages.WinnerMessagePlayer, winnerName, gameNumber);

                finalOutputMessage += startGameMessage + DisplayMessages.ChooseHandSignMessage + winnerMessage;

            }
            
            string overallWinnerName = game.WinnerPlayer?.Name;

            string overallWinnerMessage = string.IsNullOrEmpty(overallWinnerName) ?
                    string.Format(DisplayMessages.OverallWinnerMessageDraw, game.MaxWinCount) :
                    string.Format(DisplayMessages.OverallWinnerMessagePlayer, overallWinnerName, game.MaxWinCount);

            finalOutputMessage += overallWinnerMessage;

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
    }
}
