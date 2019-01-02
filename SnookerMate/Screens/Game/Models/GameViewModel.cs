using System.Collections.Generic;
using System.Linq;
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

        public bool IsRedToPot { get; set; } = true;

        bool isEndGame;
        public bool IsEndGame
        {
            get => isEndGame;

            set
            {
                isEndGame = value;
                colorSequence = new List<int> { YellowPot, GreenPot, BrownPot, BluePot, PinkPot, BlackPot };
            }
        }

        List<int> colorSequence;

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
            set
            {
                SetProperty(ref isPlayer1Turn, value);
                if (value == true)
                {
                    Player1Font = "Montserrat-SemiBold";
                    Player2Font = "Montserrat-Thin";
                }
                else
                {
                    Player1Font = "Montserrat-Thin";
                    Player2Font = "Montserrat-SemiBold";
                }
            }
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

        string player1Font = "Montserrat-SemiBold";
        public string Player1Font
        {
            get => player1Font;
            set => SetProperty(ref player1Font, value);
        }

        string player2Font = "Montserrat-Thin";
        public string Player2Font
        {
            get => player2Font;
            set => SetProperty(ref player2Font, value);
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

        async void ExecuteWhiteBallCommand(object obj)
        {
            var foul = await Application.Current.MainPage.DisplayAlert("White potted!", "Mark as foul?", "Yes", "No");

            if (foul)
                Foul(WhitePot);
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
            ChangeTurn();
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

                NumberOfRedBalls = 15;
                IsPlayer1Turn = true;
                IsEndGame = false;

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
            if (IsEndGame)
                PointsLeft = colorSequence.Sum();
            else
                PointsLeft = (NumberOfRedBalls * 8) + 27;
        }
        #endregion

        void Score(int score)
        {
            if (IsPlayer1Turn)
                Player1Score += score;
            else
                Player2Score += score;
        }

        void Foul(int points)
        {
            if (points < 4) points = 4;

            if (IsPlayer1Turn)
                Player2Score += points;
            else
                Player1Score += points;

            ChangeTurn();
        }

        void ChangeTurn()
        {
            IsPlayer1Turn = !IsPlayer1Turn;
            IsRedToPot = true;

            CalculatePointsRemaining();
        }

        async void EvaluateShot(int shotValue, bool isRed)
        {
            if (IsEndGame)
            {
                if (colorSequence.Count > 0)
                {
                    if (shotValue == colorSequence[0])
                    {
                        Score(shotValue);
                        colorSequence.RemoveAt(0);

                        if (colorSequence.Count == 0)
                            await Application.Current.MainPage.DisplayAlert("Game Over!", "All balls have been potted! The game is over.", "Ok!");

                    }
                    else
                    {
                        var foul = await Application.Current.MainPage.DisplayAlert("Are you sure?", "A wrong color ball was potted. Mark as foul?", "Yes", "No");

                        if (foul)
                        {
                            Foul(shotValue);
                            //TODO: Does the fouled ball return?
                            //colorSequence.Remove(shotValue);
                        }
                    }
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Game Over!", "All balls have been potted! The game is over.", "Ok!");

            }
            else
            {
                if (IsRedToPot && isRed)
                {
                    NumberOfRedBalls -= 1;
                    IsRedToPot = false;

                    Score(shotValue);
                }
                else if (!IsRedToPot && isRed)
                {
                    var foul = await Application.Current.MainPage.DisplayAlert("Are you sure?", "A red ball is already potted. Mark as foul?", "Yes", "No");

                    if (foul)
                    {
                        Foul(shotValue);
                    }
                }
                else if (IsRedToPot && !isRed)
                {
                    var foul = await Application.Current.MainPage.DisplayAlert("Are you sure?", "No red ball potted. Mark as foul?", "Yes", "No");

                    if (foul)
                    {
                        Foul(shotValue);
                    }
                }
                else
                {
                    if (NumberOfRedBalls == 0)
                    {
                        Score(shotValue);
                        IsEndGame = true;
                    }
                    else
                        Score(shotValue);

                    IsRedToPot = true;
                }
            }
            CalculatePointsRemaining();
        }
    }
}
