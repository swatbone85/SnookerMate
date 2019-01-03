
using Xamarin.Forms;

namespace SnookerMate
{
    public class GameView : ContentView
    {
        readonly AdMobView adMobView;
        readonly CLabel player1Label, player1Score, player2Label, player2Score, pointsLeft;
        readonly CButton endTurnButton;
        readonly BallButton whiteButton, foulButton, redButton, yellowButton, greenButton, brownButton, blueButton, pinkButton, blackButton;
        readonly ToolBarButton restartButton, endFrameButton, settingsButton;

        public GameView()
        {
            BackgroundColor = ColorTheme.BackgroundGreen;

            #region AdMob
            adMobView = new AdMobView();
            #endregion

            #region Players and Scores
            player1Label = new CLabelName();
            player1Label.SetBinding(Label.TextProperty, nameof(GameViewModel.Player1Name));
            player1Label.SetBinding(Label.FontFamilyProperty, nameof(GameViewModel.Player1Font));

            player1Score = new CLabelScore();
            player1Score.SetBinding(Label.TextProperty, nameof(GameViewModel.Player1Score));
            player1Score.SetBinding(Label.FontFamilyProperty, nameof(GameViewModel.Player1Font));

            player2Label = new CLabelName();
            player2Label.SetBinding(Label.TextProperty, nameof(GameViewModel.Player2Name));
            player2Label.SetBinding(Label.FontFamilyProperty, nameof(GameViewModel.Player2Font));

            player2Score = new CLabelScore();
            player2Score.SetBinding(Label.TextProperty, nameof(GameViewModel.Player2Score));
            player2Score.SetBinding(Label.FontFamilyProperty, nameof(GameViewModel.Player2Font));

            pointsLeft = new CLabel();
            pointsLeft.SetBinding(Label.TextProperty, nameof(GameViewModel.PointsLeft));

            var playersAndScoresGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                Margin = new Thickness(0, 40, 0, 0)
            };
            playersAndScoresGrid.Children.Add(player1Label, 0, 0);
            playersAndScoresGrid.Children.Add(player1Score, 0, 1);
            playersAndScoresGrid.Children.Add(player2Label, 1, 0);
            playersAndScoresGrid.Children.Add(player2Score, 1, 1);
            playersAndScoresGrid.Children.Add(pointsLeft, 0, 2, 2, 3);
            #endregion

            #region End Turn Button
            endTurnButton = new CButton
            {
                Text = "End Turn"
            };
            endTurnButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.EndTurnCommand));
            #endregion

            #region Ball Buttons
            whiteButton = new BallButton
            {
                BackgroundColor = ColorTheme.White
            };
            whiteButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.WhiteBallCommand));

            foulButton = new BallButton
            {
                BackgroundColor = ColorTheme.FoulButton
            };

            redButton = new BallButton
            {
                BackgroundColor = ColorTheme.Red,
                TextColor = ColorTheme.White
            };
            redButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.RedBallCommand));
            redButton.SetBinding(Button.TextProperty, nameof(GameViewModel.NumberOfRedBalls));

            yellowButton = new BallButton
            {
                BackgroundColor = ColorTheme.Yellow
            };
            yellowButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.YellowBallCommand));

            greenButton = new BallButton
            {
                BackgroundColor = ColorTheme.Green
            };
            greenButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.GreenBallCommand));

            brownButton = new BallButton
            {
                BackgroundColor = ColorTheme.Brown
            };
            brownButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BrownBallCommand));

            blueButton = new BallButton
            {
                BackgroundColor = ColorTheme.Blue
            };
            blueButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BlueBallCommand));

            pinkButton = new BallButton
            {
                BackgroundColor = ColorTheme.Pink
            };
            pinkButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.PinkBallCommand));

            blackButton = new BallButton
            {
                BackgroundColor = ColorTheme.Black
            };
            blackButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BlackBallCommand));
            #endregion

            #region bottomBarButtons
            restartButton = new ToolBarButton
            {
                Text = "Restart"
            };
            restartButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.RestartFrameCommand));

            endFrameButton = new ToolBarButton
            {
                Text = "End Frame"
            };
            endFrameButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.EndFrameCommand));

            settingsButton = new ToolBarButton
            {
                Text = "Settings"
            };
            settingsButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.SettingsCommand));
            #endregion

            var buttonGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0,
                Margin = new Thickness(0, 0, 0, 10)
            };
            buttonGrid.Children.Add(whiteButton, 0, 0);
            buttonGrid.Children.Add(redButton, 1, 3, 0, 1);
            buttonGrid.Children.Add(yellowButton, 0, 1);
            buttonGrid.Children.Add(greenButton, 1, 1);
            buttonGrid.Children.Add(brownButton, 2, 1);
            buttonGrid.Children.Add(blueButton, 0, 2);
            buttonGrid.Children.Add(pinkButton, 1, 2);
            buttonGrid.Children.Add(blackButton, 2, 2);
            buttonGrid.Children.Add(restartButton, 0, 3);
            buttonGrid.Children.Add(endFrameButton, 1, 3);
            buttonGrid.Children.Add(settingsButton, 2, 3);

            var contentGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0
            };
            contentGrid.Children.Add(playersAndScoresGrid, 0, 0);
            contentGrid.Children.Add(endTurnButton, 0, 2);
            contentGrid.Children.Add(buttonGrid, 0, 3);
            contentGrid.Children.Add(adMobView, 0, 4);

            Content = contentGrid;
        }
    }
}
