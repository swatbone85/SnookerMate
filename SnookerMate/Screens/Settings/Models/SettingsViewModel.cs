
using Xamarin.Forms;
namespace SnookerMate
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Back command
        Command backCommand;
        public Command BackCommand => backCommand ??
                    (backCommand = new Command(ExecuteBackCommand));

        async void ExecuteBackCommand(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        #endregion
    }
}
