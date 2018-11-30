using System;
using Xamarin.Forms;
namespace SnookerMate
{
    public class GamePage : ContentPage
    {
        public GamePage()
        {
            Content = new GameView
            {
                BindingContext = App.GameVM
            };
        }
    }
}
