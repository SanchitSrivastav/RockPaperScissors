using RockPaperScissors.Services.Enum;
using RockPaperScissors.Services.Interface;
using RockPaperScissors.Services.Utility;

namespace RockPaperScissors.Services.Concrete
{
    public class GameRunner : IGameRunner
    {
        private readonly int _gameCount;
        private readonly int _maxWinCount;
        private readonly IGame[] _gmaes;
        private readonly InputUtility _inputUtility;
        private IPlayer _winnerPlayer;
        private int _humanWinCount;
        private int _cpuWinCount;
        public GameRunner(int gameCount)
        {
            _gameCount = gameCount;
            _gmaes = new Game[_gameCount];
            _inputUtility = new InputUtility();
            _maxWinCount = _gameCount / 2 + 1;
        }

        public IGame[] Gmaes => _gmaes;

        public IPlayer WinnerPlayer => _winnerPlayer;

        public int MaxWinCount => _maxWinCount;

        public void Start()
        {
            string _humanPlayerName = _inputUtility.GetUserName();

            // initializiting game object
            for (int i = 0; i < _gameCount; i++)
            {
                _gmaes[i] = new Game(
                    new Player(_humanPlayerName),
                    new Player("CPU"),
                    _inputUtility);

                _gmaes[i].StartGame(i);

                var playerType = _gmaes[i].WinnerPlayer?.PlayerType;

                switch (playerType)
                {
                    case PlayerType.Cpu:
                        _cpuWinCount++;
                        break;
                    case PlayerType.Human:
                        _humanWinCount++;
                        break;
                }

                SetOverallWinnerPlayer(_gmaes[i].WinnerPlayer);
            }

            _inputUtility.OverallWinnerMessage(WinnerPlayer, MaxWinCount);
        }

        private void SetOverallWinnerPlayer(IPlayer player)
        {
            if(player==null)
            {
                return;
            }

            if (_humanWinCount >= MaxWinCount && player.PlayerType == PlayerType.Human)
            {
                _winnerPlayer = player;
            }
            else if (_cpuWinCount >= MaxWinCount && player.PlayerType == PlayerType.Cpu)
            {
                _winnerPlayer = player;
            }
        }
    }
}
