using System;
using Xamarin.Forms;
namespace SnookerMate
{
    public class GamePage : ContentPage
    {

        readonly CLabel player1Label, player1Score, player2Label, player2Score;

        public GamePage()
        {
            BindingContext = new GameViewModel();
            BackgroundColor = ColorTheme.BackgroundGreen;

            #region Players and Scores
            player1Label = new CLabel
            {
                FontSize = 24
            };
            player1Label.SetBinding(Label.TextProperty, nameof(GameViewModel.Player1Name));

            player1Score = new CLabel
            {
                FontSize = 72
            };
            player1Score.SetBinding(Label.TextProperty, nameof(GameViewModel.Player1Score));

            player2Label = new CLabel
            {
                FontSize = 24
            };
            player2Label.SetBinding(Label.TextProperty, nameof(GameViewModel.Player2Name));

            player2Score = new CLabel
            {
                FontSize = 72
            };
            player2Score.SetBinding(Label.TextProperty, nameof(GameViewModel.Player2Score));

            var playersAndScoresGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                Margin = new Thickness(0, 50, 0, 0)
            };
            playersAndScoresGrid.Children.Add(player1Label, 0, 0);
            playersAndScoresGrid.Children.Add(player1Score, 0, 1);
            playersAndScoresGrid.Children.Add(player2Label, 1, 0);
            playersAndScoresGrid.Children.Add(player2Score, 1, 1);

            #endregion

            #region End Turn Button
            var endTurnButton = new CButton
            {
                Text = "End Turn",
                FontSize = 24,
                HeightRequest = 60
            };
            endTurnButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.EndTurnCommand));

            #endregion

            #region Ball Buttons
            var whiteButton = new CButton
            {
                BackgroundColor = ColorTheme.White
            };
            whiteButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.WhiteBallCommand));

            var foulButton = new CButton
            {
                BackgroundColor = ColorTheme.FoulButton
            };

            var redButton = new CButton
            {
                BackgroundColor = ColorTheme.Red
            };
            redButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.RedBallCommand));

            var yellowButton = new CButton
            {
                BackgroundColor = ColorTheme.Yellow
            };
            yellowButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.YellowBallCommand));

            var greenButton = new CButton
            {
                BackgroundColor = ColorTheme.Green
            };
            greenButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.GreenBallCommand));

            var brownButton = new CButton
            {
                BackgroundColor = ColorTheme.Brown
            };
            brownButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BrownBallCommand));

            var blueButton = new CButton
            {
                BackgroundColor = ColorTheme.Blue
            };
            blueButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BlueBallCommand));

            var pinkButton = new CButton
            {
                BackgroundColor = ColorTheme.Pink
            };
            pinkButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.PinkBallCommand));

            var blackButton = new CButton
            {
                BackgroundColor = ColorTheme.Black
            };
            blackButton.SetBinding(Button.CommandProperty, nameof(GameViewModel.BlackBallCommand));

            #endregion

            #region bottomBarButtons
            var undoButton = new CButton
            {
                Text = "Undo"
            };

            var endFrameButton = new CButton
            {
                Text = "End Frame"
            };
            endFrameButton.Clicked += EndFrameButton_Clicked;

            var settingsButton = new CButton
            {
                Text = "Settings"
            };

            #endregion

            var buttonGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength(125) },
                    new RowDefinition { Height = new GridLength(125) },
                    new RowDefinition { Height = new GridLength(125) },
                    new RowDefinition { Height = new GridLength(60) }
                },
                RowSpacing = 0,
                ColumnSpacing = 0
            };
            buttonGrid.Children.Add(whiteButton, 0, 0);
            buttonGrid.Children.Add(foulButton, 1, 0);
            buttonGrid.Children.Add(redButton, 2, 0);
            buttonGrid.Children.Add(yellowButton, 0, 1);
            buttonGrid.Children.Add(greenButton, 1, 1);
            buttonGrid.Children.Add(brownButton, 2, 1);
            buttonGrid.Children.Add(blueButton, 0, 2);
            buttonGrid.Children.Add(pinkButton, 1, 2);
            buttonGrid.Children.Add(blackButton, 2, 2);
            buttonGrid.Children.Add(undoButton, 0, 3);
            buttonGrid.Children.Add(endFrameButton, 1, 3);
            buttonGrid.Children.Add(settingsButton, 2, 3);

            var contentGrid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0
            };
            contentGrid.Children.Add(playersAndScoresGrid, 0, 0);
            contentGrid.Children.Add(endTurnButton, 0, 2);
            contentGrid.Children.Add(buttonGrid, 0, 3);

            Content = contentGrid;
        }

        void EndFrameButton_Clicked(object sender, EventArgs e)
        {
            var endFrame = DisplayAlert("End Frame", "Are you sure you want to end the current frame?", "End Frame", "Cancel");

            if (endFrame.Equals(true))
            {
                System.Diagnostics.Debug.WriteLine("Frame Ended");
            }
        }

    }
}
