using Xamarin.Forms;

namespace SnookerMate
{
    public class App : Application
    {
        public static GameViewModel GameVM = new GameViewModel();

        public App()
        {
            var mainPage = new GamePage { BindingContext = new GameViewModel() };
            MainPage = mainPage;
        }
    }
}
