using Xamarin.Forms;

namespace SnookerMate
{
    public class GameViewModel : BaseViewModel
    {
        readonly int WhitePot = 4;
        readonly int RedPot = 1;
        readonly int YellowPot = 2;
        readonly int GreenPot = 3;
        readonly int BrownPot = 4;
        readonly int BluePot = 5;
        readonly int PinkPot = 6;
        readonly int BlackPot = 7;

        bool isRedToPot = true;

        int numberOfRedBalls = 15;
        public int NumberOfRedBalls
        {
            get => numberOfRedBalls;
            set => SetProperty(ref numberOfRedBalls, value);
        }

        #region Properties
        bool isPlayer1Turn = true;
        public bool IsPlayer1Turn
        {
            get => isPlayer1Turn;
            set => SetProperty(ref isPlayer1Turn, value);
        }

        int pointsLeft = 147;
        public int PointsLeft
        {
            get => pointsLeft;
            set => SetProperty(ref pointsLeft, value);
        }

        string player1Name = "Player 1";
        public string Player1Name
        {
            get => player1Name;
            set => SetProperty(ref player1Name, value);
        }

        int player1Score;
        public int Player1Score
        {
            get => player1Score;
            set => SetProperty(ref player1Score, value);
        }

        string player2Name = "Player 2";
        public string Player2Name
        {
            get => player2Name;
            set => SetProperty(ref player2Name, value);
        }

        int player2Score;
        public int Player2Score
        {
            get => player2Score;
            set => SetProperty(ref player2Score, value);
        }

        #endregion

        #region White ball command
        Command whiteBallCommand;
        public Command WhiteBallCommand
        {
            get
            {
                return whiteBallCommand ??
                    (whiteBallCommand = new Command(ExecuteWhiteBallCommand));
            }
        }

        void ExecuteWhiteBallCommand(object obj)
        {
            if (IsPlayer1Turn)
                Player2Score += WhitePot;
            else
                Player1Score += WhitePot;
        }
        #endregion

        #region Red ball command
        Command redBallCommand;
        public Command RedBallCommand
        {
            get
            {
                return redBallCommand ??
                    (redBallCommand = new Command(ExecuteRedBallCommandAsync));
            }
        }

        void ExecuteRedBallCommandAsync(object obj)
        {
            if (NumberOfRedBalls > 0)
                EvaluateShot(RedPot, true);
            else
                Application.Current.MainPage.DisplayAlert("No red balls available!", "All red balls have been potted.", "Ok");
        }
        #endregion

        #region Yellow ball command
        Command yellowBallCommand;
        public Command YellowBallCommand
        {
            get
            {
                return yellowBallCommand ??
                    (yellowBallCommand = new Command(ExecuteYellowBallCommand));
            }
        }

        void ExecuteYellowBallCommand(object obj)
        {
            EvaluateShot(YellowPot, false);
        }
        #endregion

        #region Green ball command
        Command greenBallCommand;
        public Command GreenBallCommand
        {
            get
            {
                return greenBallCommand ??
                    (greenBallCommand = new Command(ExecuteGreenBallCommand));
            }
        }

        void ExecuteGreenBallCommand(object obj)
        {
            EvaluateShot(GreenPot, false);
        }
        #endregion

        #region Brown ball command
        Command brownBallCommand;
        public Command BrownBallCommand
        {
            get
            {
                return brownBallCommand ??
                    (brownBallCommand = new Command(ExecuteBrownBallCommand));
            }
        }

        void ExecuteBrownBallCommand(object obj)
        {
            EvaluateShot(BrownPot, false);
        }
        #endregion

        #region Blue ball command
        Command blueBallCommand;
        public Command BlueBallCommand
        {
            get
            {
                return blueBallCommand ??
                    (blueBallCommand = new Command(ExecuteBlueBallCommand));
            }
        }

        void ExecuteBlueBallCommand(object obj)
        {
            EvaluateShot(BluePot, false);
        }
        #endregion

        #region Pink ball command
        Command pinkBallCommand;
        public Command PinkBallCommand
        {
            get
            {
                return pinkBallCommand ??
                    (pinkBallCommand = new Command(ExecutePinkBallCommand));
            }
        }

        void ExecutePinkBallCommand(object obj)
        {
            EvaluateShot(PinkPot, false);
        }
        #endregion

        #region Black ball command
        Command blackBallCommand;
        public Command BlackBallCommand
        {
            get
            {
                return blackBallCommand ??
                    (blackBallCommand = new Command(ExecuteBlackBallCommand));
            }
        }

        void ExecuteBlackBallCommand(object obj)
        {
            EvaluateShot(BlackPot, false);
        }
        #endregion

        #region End turn command
        Command endTurnCommand;
        public Command EndTurnCommand
        {
            get
            {
                return endTurnCommand ??
                    (endTurnCommand = new Command(ExecuteEndTurnCommand));
            }
        }

        void ExecuteEndTurnCommand(object obj)
        {
            IsPlayer1Turn = !IsPlayer1Turn;
            isRedToPot = true;

            CalculatePointsRemaining();
        }
        #endregion

        #region End frame Command
        Command endFrameCommand;
        public Command EndFrameCommand
        {
            get
            {
                return endFrameCommand ??
                    (endFrameCommand = new Command(ExecuteEndFrameCommand));
            }
        }

        async void ExecuteEndFrameCommand(object obj)
        {
            var endFrame = await Application.Current.MainPage.DisplayAlert("End Frame", "Are you sure you want to end the current frame?", "End Frame", "Cancel");

            if (endFrame.Equals(true))
            {
                Player1Score = 0;
                Player2Score = 0;

                numberOfRedBalls = 15;
                CalculatePointsRemaining();
            }
        }
        #endregion

        #region Settings command
        Command settingsCommand;
        public Command SettingsCommand
        {
            get
            {
                return settingsCommand ??
                    (settingsCommand = new Command(ExecuteSettingsCommand));
            }
        }

        async void ExecuteSettingsCommand(object obj) => await Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage());
        #endregion

        #region Calculate points remaining
        void CalculatePointsRemaining()
        {
            PointsLeft = (NumberOfRedBalls * 8) + 27;
        }
        #endregion

        async void EvaluateShot(int shotValue, bool isRed)
        {
            if (isRedToPot && isRed)
            {
                NumberOfRedBalls -= 1;
                isRedToPot = false;

                if (IsPlayer1Turn)
                    Player1Score += shotValue;
                else
                    Player2Score += shotValue;
            }
            else if (!isRedToPot && isRed)
            {
                NumberOfRedBalls -= 1;
                var foul = await Application.Current.MainPage.DisplayAlert("Are you sure?", "A red ball is already potted. Mark as foul?", "Yes", "No");

                if (foul)
                {
                    if (shotValue < 4) shotValue = 4;

                    if (IsPlayer1Turn)
                        Player2Score += shotValue;
                    else
                        Player1Score += shotValue;
                }
            }
            else if (isRedToPot && !isRed)
            {
                if (NumberOfRedBalls == 0)
                {
                    if (IsPlayer1Turn)
                        Player1Score += shotValue;
                    else
                        Player2Score += shotValue;
                }
                else
                {
                    var foul = await Application.Current.MainPage.DisplayAlert("Are you sure?", "No red ball potted. Mark as foul?", "Yes", "No");

                    if (foul)
                    {
                        if (shotValue < 4) shotValue = 4;

                        if (IsPlayer1Turn)
                            Player2Score += shotValue;
                        else
                            Player1Score += shotValue;
                    }
                }

            }
            else
            {
                if (IsPlayer1Turn)
                    Player1Score += shotValue;
                else
                    Player2Score += shotValue;

                isRedToPot = true;
            }
        }
    }
}
