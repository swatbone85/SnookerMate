using System;

namespace SnookerMate
{
    public class Player : ObservableObject
    {
        string name = "Player";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public int Score { get; set; } = 0;
    }
}
