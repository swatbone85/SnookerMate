using Xamarin.Forms;

namespace SnookerMate
{
    public class GameViewModel : BaseViewModel
    {
        int WhitePot = 4;
        int RedPot = 1;
        int YellowPot = 2;
        int GreenPot = 3;
        int BrownPot = 4;
        int BluePot = 5;
        int PinkPot = 6;
        int BlackPot = 7;

        #region Properties
        public bool IsPlayer1Turn { get; set; } = true;

        string player1Name = "Player 1";
        public string Player1Name
        {
            get { return player1Name; }
            set => SetProperty(ref player1Name, value);
        }

        int player1Score;
        public int Player1Score
        {
            get { return player1Score; }
            set => SetProperty(ref player1Score, value);
        }

        string player2Name = "Player 2";
        public string Player2Name
        {
            get { return player2Name; }
            set => SetProperty(ref player2Name, value);
        }

        int player2Score;
        public int Player2Score
        {
            get { return player2Score; }
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
                    (redBallCommand = new Command(ExecuteRedBallCommand));
            }
        }

        void ExecuteRedBallCommand(object obj)
        {
            if (IsPlayer1Turn)
                Player1Score += RedPot;
            else
                Player2Score += RedPot;
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
            if (IsPlayer1Turn)
                Player1Score += YellowPot;
            else
                Player2Score += YellowPot;
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
            if (IsPlayer1Turn)
                Player1Score += GreenPot;
            else
                Player2Score += GreenPot;
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
            if (IsPlayer1Turn)
                Player1Score += BrownPot;
            else
                Player2Score += BrownPot;
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
            if (IsPlayer1Turn)
                Player1Score += BluePot;
            else
                Player2Score += BluePot;
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
            if (IsPlayer1Turn)
                Player1Score += PinkPot;
            else
                Player2Score += PinkPot;
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
            if (IsPlayer1Turn)
                Player1Score += BlackPot;
            else
                Player2Score += BlackPot;
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
            if (IsPlayer1Turn)
                IsPlayer1Turn = false;
            else
                IsPlayer1Turn = true;
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

        // TODO
        void ExecuteEndFrameCommand(object obj)
        {

        }

        #endregion

    }
}
