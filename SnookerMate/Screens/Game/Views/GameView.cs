//using Xamarin.Forms;

//namespace SnookerMate
//{
//    public class GameView : ContentView
//    {
//        bool isPlayer1Turn;
//        Player Player1, Player2;
//        CLabel player1Label, player1Score, player2Label, player2Score;

//        public GameView()
//        {
//            BindingContext = new GameViewModel();
//            BackgroundColor = ColorTheme.BackgroundGreen;

//            isPlayer1Turn = true;

//            Player1 = new Player
//            {
//                Name = "Player 1",
//                Score = 0
//            };

//            Player2 = new Player
//            {
//                Name = "Player 2",
//                Score = 0
//            };

//            #region Players and Scores
//            player1Label = new CLabel
//            {
//                Text = Player1.Name,
//                FontSize = 24
//            };
//            player1Label.SetBinding(Label.TextProperty, nameof(GameViewModel.Player1.Name));

//            player1Score = new CLabel
//            {
//                Text = Player1.Score.ToString(),
//                FontSize = 72
//            };

//            player2Label = new CLabel
//            {
//                Text = Player2.Name,
//                FontSize = 24
//            };

//            player2Score = new CLabel
//            {
//                Text = Player2.Score.ToString(),
//                FontSize = 72
//            };

//            var playersAndScoresGrid = new Grid
//            {
//                RowDefinitions = {
//                    new RowDefinition { Height = GridLength.Auto },
//                    new RowDefinition { Height = GridLength.Auto }
//                },
//                Margin = new Thickness(0, 50, 0, 0)
//            };
//            playersAndScoresGrid.Children.Add(player1Label, 0, 0);
//            playersAndScoresGrid.Children.Add(player1Score, 0, 1);
//            playersAndScoresGrid.Children.Add(player2Label, 1, 0);
//            playersAndScoresGrid.Children.Add(player2Score, 1, 1);

//            #endregion

//            #region End Turn Button
//            var endTurnButton = new CButton
//            {
//                Text = "End Turn",
//                FontSize = 24,
//                HeightRequest = 60
//            };

//            #endregion

//            #region Ball Buttons
//            var whiteButton = new CButton
//            {
//                BackgroundColor = ColorTheme.White
//            };
//            whiteButton.Clicked += WhiteButton_Clicked;

//            var foulButton = new CButton
//            {
//                BackgroundColor = ColorTheme.FoulButton
//            };

//            var redButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Red
//            };

//            var yellowButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Yellow
//            };

//            var greenButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Green
//            };

//            var brownButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Brown
//            };

//            var blueButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Blue
//            };

//            var pinkButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Pink
//            };

//            var blackButton = new CButton
//            {
//                BackgroundColor = ColorTheme.Black
//            };

//            #endregion

//            #region bottomBarButtons
//            var undoButton = new CButton
//            {
//                Text = "Undo"
//            };

//            var endFrameButton = new CButton
//            {
//                Text = "End Frame"
//            };

//            var settingsButton = new CButton
//            {
//                Text = "Settings"
//            };

//            #endregion

//            var buttonGrid = new Grid
//            {
//                RowDefinitions = {
//                    new RowDefinition { Height = new GridLength(125) },
//                    new RowDefinition { Height = new GridLength(125) },
//                    new RowDefinition { Height = new GridLength(125) },
//                    new RowDefinition { Height = new GridLength(60) }
//                },
//                RowSpacing = 0,
//                ColumnSpacing = 0
//            };
//            buttonGrid.Children.Add(whiteButton, 0, 0);
//            buttonGrid.Children.Add(foulButton, 1, 0);
//            buttonGrid.Children.Add(redButton, 2, 0);
//            buttonGrid.Children.Add(yellowButton, 0, 1);
//            buttonGrid.Children.Add(greenButton, 1, 1);
//            buttonGrid.Children.Add(brownButton, 2, 1);
//            buttonGrid.Children.Add(blueButton, 0, 2);
//            buttonGrid.Children.Add(pinkButton, 1, 2);
//            buttonGrid.Children.Add(blackButton, 2, 2);
//            buttonGrid.Children.Add(undoButton, 0, 3);
//            buttonGrid.Children.Add(endFrameButton, 1, 3);
//            buttonGrid.Children.Add(settingsButton, 2, 3);

//            var contentGrid = new Grid
//            {
//                RowDefinitions = {
//                    new RowDefinition { Height = GridLength.Auto },
//                    new RowDefinition { Height = GridLength.Star },
//                    new RowDefinition { Height = GridLength.Auto },
//                    new RowDefinition { Height = GridLength.Auto }
//                },
//                RowSpacing = 0,
//                ColumnSpacing = 0
//            };
//            contentGrid.Children.Add(playersAndScoresGrid, 0, 0);
//            contentGrid.Children.Add(endTurnButton, 0, 2);
//            contentGrid.Children.Add(buttonGrid, 0, 3);

//            Content = contentGrid;
//        }

//        void WhiteButton_Clicked(object sender, System.EventArgs e)
//        {
//            if (isPlayer1Turn)
//            {
//                Player2.Score += 4;
//            }
//        }

//    }
//}
