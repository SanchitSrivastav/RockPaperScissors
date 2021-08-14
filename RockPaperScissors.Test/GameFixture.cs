using NUnit.Framework;
using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Enum;
using RockPaperScissors.Services.Interface;
using RockPaperScissors.Services.Utility;
using System;
using System.IO;

namespace RockPaperScissors.Test
{
    class GameFixture
    {
        private StringWriter output;
        private StringReader inputPlayerName;
        private const string humanPlayerName = "Sanchit";
        private readonly string[] selectionInput = new string[3] { "r", "p", "s" };
        private const int gameNumber = 0;
        private IGame game;
        private readonly InputUtility _inputUtility = new InputUtility();

        [SetUp]
        public void Setup()
        {
            output = new StringWriter();
            inputPlayerName = new StringReader(string.Format(@"{0}", selectionInput[0]));

            game = new Game(
                    new Player(humanPlayerName),
                    new Player("CPU"),
                    _inputUtility);
        }
        

            [Test]
        public void StartGame()
        {
            Console.SetOut(output);
            Console.SetIn(inputPlayerName);

            game.StartGame(gameNumber);

            int gameShowNumber = gameNumber + 1;

            string finalOutputMessage = string.Format(DisplayMessages.StartGameMessage, humanPlayerName, gameShowNumber);

            string winnerName = game.WinnerPlayer?.Name;

            string winnerMessage = string.IsNullOrEmpty(winnerName) ?
                string.Format(DisplayMessages.WinnerMessageDraw, gameShowNumber) :
                string.Format(DisplayMessages.WinnerMessagePlayer, winnerName, gameShowNumber);

            finalOutputMessage +=  DisplayMessages.ChooseHandSignMessage + winnerMessage;

            IPlayer winnerPlayer = string.IsNullOrEmpty(winnerName) ? null :
                game.WinnerPlayer.PlayerType == PlayerType.Human ? game.HumanPlayer : game.CpuPlayer;

            Assert.That(game.WinnerPlayer, Is.EqualTo(winnerPlayer));
            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }

        [Test]
        public void Constructor_HappyPath()
        {
            IGame game1 = new Game(
                    new Player(humanPlayerName),
                    new Player("CPU"),
                    _inputUtility);
        }
    }
}
