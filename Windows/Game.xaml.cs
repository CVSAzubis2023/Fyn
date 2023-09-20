using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pac_Man
{
    public partial class Game : Window
    {
        ghost ghostRed = new ghost();
        ghost ghostBlue = new ghost();
        ghost ghostOrange = new ghost();
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
            string keyString = null;

            if(e.Key == Key.W || e.Key == Key.Up)
            {
                keyString = "W";
            } 
            else
            {
                if (e.Key == Key.A || e.Key == Key.Left)
                {
                    keyString = "A";
                }
                else
                {
                    if (e.Key == Key.S || e.Key == Key.Down)
                    {
                        keyString = "S";
                    }
                    else
                    {
                        if (e.Key == Key.D || e.Key == Key.Right)
                        {
                            keyString = "D";
                        }
                        else
                        {
                            keyString = null;
                        }
                    }
                }
            }

            player1.move(keyString);
            ghostRed.move(player1.getPosX(), player1.getPosY());
            if (player1.getTilesMoved() > 49)
            {
                ghostBlue.move(player1.getPosX(), player1.getPosY());
                if (player1.getTilesMoved() > 99)
                {
                    ghostOrange.move(player1.getPosX(), player1.getPosY());
                    if (player1.getTilesMoved() > 150)
                    {
                        ghostPurple.move(player1.getPosX(), player1.getPosY());
                    }
                }
            }
            //Blue ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostBlue.getPosX(), ghostBlue.getPosY());
            //Red ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostRed.getPosX(), ghostRed.getPosY());
            //Yellow ghost
            game.collisionDetection(player1.getPosX(), player1.getPosY(), ghostOrange.getPosX(), ghostOrange.getPosY());
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
            drawMapStart();
        }

        public void drawMapStart()
        {
            int[,] tempmap = new int[31,28];
            tempmap = gamesetup.getMap();

            if (gamesetup.getmapInitDone() == false)
            {
                if (gamesetup.checkMapState() == 0)
                {
                    for (int i = 0; i < 28; i++)
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            Rectangle mapTile = new Rectangle();

                            switch (tempmap[j,i])
                            {
                                case 0:
                                    Waende.Children.Add(mapTile);
                                    Grid.SetColumn(mapTile, i);
                                    Grid.SetRow(mapTile, j);
                                    mapTile.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                    break;
                                case 1:
                                    Waende.Children.Add(mapTile);
                                    Grid.SetColumn(mapTile, i);
                                    Grid.SetRow(mapTile, j);
                                    mapTile.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 70));
                                    mapTile.StrokeThickness = 12;
                                    mapTile.Stroke = new SolidColorBrush(Color.FromRgb(0,0,100));
                                    break;
                                case 2:
                                    Waende.Children.Add(mapTile);
                                    Grid.SetColumn(mapTile, i);
                                    Grid.SetRow(mapTile, j);
                                    mapTile.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 50));
                                    mapTile.StrokeThickness = 12;
                                    mapTile.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                                    break;
                                case 3:
                                    Waende.Children.Add(mapTile);
                                    Grid.SetColumn(mapTile, i);
                                    Grid.SetRow(mapTile, j);
                                    mapTile.Fill = new SolidColorBrush(Color.FromRgb(50, 0, 0));
                                    break;
                                default:
                                    Waende.Children.Add(mapTile);
                                    Grid.SetColumn(mapTile, i);
                                    Grid.SetRow(mapTile, j);
                                    mapTile.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                                    break;
                            }

                            gamesetup.setmapInitDone(true);
                        }
                    }
                }
            }
        }
    }
}