
using Xamarin.Forms;

namespace SnookerMate
{
    public class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            Content = new SettingsView
            {
                BindingContext = new SettingsViewModel()
            };
        }
    }
}
