namespace RockPaperScissors.Services.Utility
{
    public class DisplayMessages
    {
        public const string WelcomeMessage = "Welcome to Rock, Paper, Scissors! It's you against the Random Computer Player.\nPlease enter your name..\n";
        public const string WelcomeMessageForUser = "{0} indicate that you are ready by hitting the enter key\n";

        public const string StartGameMessage = "{0} ,let's Play Rock, Paper, Scissors! Game: {1}\n";

        public const string ChooseHandSignMessage = "R-Rock\nP-Paper\nS-Scissors\nMake your selection:\n";

        public const string WinnerMessageDraw = "Sorry, It's a Draw of Game: {0}\n";
        public const string WinnerMessagePlayer = "Congrats {0} is the winner of Game: {1}\n";

        public const string OverallWinnerMessageDraw = "Sorry, It's a Draw overall winner being the first player to win {0} games\n";
        public const string OverallWinnerMessagePlayer = "Congrats {0} is overall winner being the first player to win {1} games\n";

        public const string InvalidHandSignMessage = "Sorry Invalid Input. Please choose again";
    }
}
