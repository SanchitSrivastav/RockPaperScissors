namespace RockPaperScissors.Services.Interface
{
    public interface IGameRunner
    {
        void Start();
        IGame[] Gmaes { get;}
        IPlayer WinnerPlayer { get; }
        int MaxWinCount { get; }
    }
}
