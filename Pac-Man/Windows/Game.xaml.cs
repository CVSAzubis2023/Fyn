using System.Windows;

namespace Pac_Man
{
    ghost ghostRed = new ghost();
    ghost ghostBlue = new ghost();
    ghost ghostYellow = new ghost();
    ghost ghostPurple = new ghost();

    player player = new player();
    
    
    
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            
            

        }
    }
}