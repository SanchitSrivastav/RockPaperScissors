using NUnit.Framework;
using RockPaperScissors.Services.Concrete;
using RockPaperScissors.Services.Interface;
using RockPaperScissors.Services.Utility;
using System;
using System.IO;

namespace RockPaperScissors.Test
{
    class InputUtilityFixture
    {
        private StringWriter output;
        private StringReader input;
        private const string humanPlayerName = "Sanchit";
        private readonly string[] selectionInput = new string[3] { "r", "p", "s" };
        private const int gameNumber = 0;
        private readonly InputUtility _inputUtility = new();
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
            output = new StringWriter();
            _player = new Player(humanPlayerName);
        }

        [Test]
        public void GetUserName_HappyPath()
        {
            input = new StringReader(string.Format(@"{0}", humanPlayerName));

            Console.SetOut(output);
            Console.SetIn(input);

            _inputUtility.GetUserName();

            string finalOutputMessage = DisplayMessages.WelcomeMessage +
                string.Format(DisplayMessages.WelcomeMessageForUser, humanPlayerName);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void StartGameMessage_HappyPath()
        {
            Console.SetOut(output);
            _inputUtility.StartGameMessage(_player, gameNumber);

            string finalOutputMessage = string.Format(DisplayMessages.StartGameMessage, _player.Name, gameNumber+1);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void ChooseHandSign_ValidInput()
        {
            input = new StringReader(string.Format(@"{0}", selectionInput[0]));

            Console.SetOut(output);
            Console.SetIn(input);

            _inputUtility.ChooseHandSign();

            string finalOutputMessage = DisplayMessages.ChooseHandSignMessage;

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void ChooseHandSign_InvaalidInput()
        {
            input = new StringReader(string.Format(@"{0}
{1}","o" ,selectionInput[0]));

            Console.SetOut(output);
            Console.SetIn(input);

            _inputUtility.ChooseHandSign();

            string finalOutputMessage = DisplayMessages.ChooseHandSignMessage +
                DisplayMessages.InvalidHandSignMessage +
                DisplayMessages.ChooseHandSignMessage;

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void WinnerMessage_Draw()
        {
            Console.SetOut(output);
            _inputUtility.WinnerMessage(null, gameNumber);

            string finalOutputMessage = string.Format(DisplayMessages.WinnerMessageDraw, gameNumber+1);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void WinnerMessage_PlayerWin()
        {
            Console.SetOut(output);
            _inputUtility.WinnerMessage(_player, gameNumber);

            string finalOutputMessage = string.Format(DisplayMessages.WinnerMessagePlayer, _player.Name, gameNumber+1);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void OverallWinnerMessage_Draw()
        {
            Console.SetOut(output);
            _inputUtility.OverallWinnerMessage(null, gameNumber);

            string finalOutputMessage = string.Format(DisplayMessages.OverallWinnerMessageDraw, gameNumber);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
        [Test]
        public void OverallWinnerMessage_PlayerWin()
        {
            Console.SetOut(output);
            _inputUtility.OverallWinnerMessage(_player, gameNumber);

            string finalOutputMessage = string.Format(DisplayMessages.OverallWinnerMessagePlayer, _player.Name, gameNumber);

            Assert.That(output.ToString(), Is.EqualTo(finalOutputMessage));
        }
    }
}
