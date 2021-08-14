namespace RockPaperScissors.Services.Interface
{
    public interface IGame
    {
        void StartGame(int gameNumber);
        IPlayer WinnerPlayer { get; }
        IPlayer HumanPlayer { get; }
        IPlayer CpuPlayer { get; }
    }
}
