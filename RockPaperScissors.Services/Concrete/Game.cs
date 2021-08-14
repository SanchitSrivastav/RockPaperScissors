using RockPaperScissors.Services.Interface;
using RockPaperScissors.Services.Utility;

namespace RockPaperScissors.Services.Concrete
{
    public class Game : IGame
    {

        private readonly IPlayer _humanPlayer;
        private readonly IPlayer _cpuPlayer;
        private readonly InputUtility _inputUtility;
        private IPlayer _winnerPlayer;
        public Game(IPlayer humanPlayer, IPlayer cpuPlayer, InputUtility inputUtility)
        {
            _humanPlayer = humanPlayer;
            _cpuPlayer = cpuPlayer;
            _inputUtility = inputUtility;
        }

        public IPlayer WinnerPlayer  => _winnerPlayer;

        public IPlayer HumanPlayer => _humanPlayer;

        public IPlayer CpuPlayer => _cpuPlayer;

        public void StartGame(int gameNumber)
        {
            //start game message
            _inputUtility.StartGameMessage(_humanPlayer, gameNumber);
            //Get users hand, Note check for valid entry
            _humanPlayer.HandSign = _inputUtility.ChooseHandSign();
            //Generate a random hand for computer
            _cpuPlayer.HandSign = HandSign.MapRandomToMove();
            //compare choices
            //Declare winner
            SetWinner(HumanPlayer, CpuPlayer);

            _inputUtility.WinnerMessage(WinnerPlayer, gameNumber);
            //Give option to play again, do while loop run as long as true, 
        }
        private void SetWinner(IPlayer player1, IPlayer player2)
        {
            if (HandSign.GetWinningMove(player1.HandSign.Move).Equals(player2.HandSign.Move))
            {
                _winnerPlayer = player2;
            }
            else if (HandSign.GetWinningMove(player2.HandSign.Move).Equals(player1.HandSign.Move))
            {
                _winnerPlayer = player1;
            }
        }
    }
}
