using Xamarin.Forms;

namespace SnookerMate
{
    public class App : Application
    {
        public App()
        {
            MainPage = new GamePage { BindingContext = new GameViewModel() };
        }
    }
}
