
using Xamarin.Forms;

namespace SnookerMate
{
    public class SettingsView : ContentView
    {
        Entry Player1Entry, Player2Entry;
        readonly CButton BackButton;

        public SettingsView()
        {
            BackgroundColor = ColorTheme.BackgroundGreen;

            #region
            Player1Entry = new Entry
            {
                Placeholder = "Player 1",
                BindingContext = App.GameVM
            };
            Player1Entry.SetBinding(Entry.TextProperty, nameof(GameViewModel.Player1Name));

            Player2Entry = new Entry
            {
                Placeholder = "Player 2",
                BindingContext = App.GameVM
            };
            Player2Entry.SetBinding(Entry.TextProperty, nameof(GameViewModel.Player2Name));

            BackButton = new CButton
            {
                Text = "BACK TO GAME",
                CornerRadius = 5
            };
            BackButton.SetBinding(Button.CommandProperty, nameof(SettingsViewModel.BackCommand));
            #endregion

            var contentLayout = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = GridLength.Auto }

                },
                RowSpacing = 10,
                Margin = new Thickness(40, 60, 40, 40)
            };
            contentLayout.Children.Add(Player1Entry, 0, 0);
            contentLayout.Children.Add(Player2Entry, 0, 1);
            contentLayout.Children.Add(BackButton, 0, 3);

            Content = contentLayout;
        }
    }
}
