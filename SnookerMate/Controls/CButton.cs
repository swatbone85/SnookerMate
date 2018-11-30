using Xamarin.Forms;
namespace SnookerMate
{
    public class CButton : Button
    {
        public CButton()
        {
            CornerRadius = 0;
            BackgroundColor = ColorTheme.ButtonGrey;
            TextColor = ColorTheme.ButtonTextGrey;
            HeightRequest = 50;
            FontSize = 24;
        }
    }
}
