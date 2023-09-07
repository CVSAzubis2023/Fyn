using System.Windows;
using System.Windows.Input;

namespace Pac_Man
{
    public partial class Game : Window
    {
        ghost ghostRed = new ghost();
        ghost ghostBlue = new ghost();
        ghost ghostYellow = new ghost();
        ghost ghostPurple = new ghost();

        player player1 = new player();
    
        gamesetup gamesetup = new gamesetup();
        gamefunctions game = new gamefunctions();
        
        public Game()
        {
            InitializeComponent();
        }
        
        private void Game_OnKeyDown(object sender, KeyEventArgs e)
        {
            player1.move(sender);
            //Blue ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostBlue.getPosX(), ghostBlue.getPosY());
            //Red ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostRed.getPosX(), ghostRed.getPosY());
            //Yellow ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostYellow.getPosX(), ghostYellow.getPosY());
            //Purple ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostPurple.getPosX(), ghostPurple.getPosY());
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToggleSize_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            ButtonPlay.Visibility = Visibility.Hidden;
            gamesetup.drawMapStart();
        }
    }
}