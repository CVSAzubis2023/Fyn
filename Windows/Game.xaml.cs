using Pac_Man.Login;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
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
        gamesetup gamesetup = new gamesetup();
        gamefunctions game = new gamefunctions();
        log log = new log();

        player player1 = new player();

        ghost ghostRed = new ghost();
        ghost ghostBlue = new ghost();
        ghost ghostOrange = new ghost();
        ghost ghostPurple = new ghost();

        private string playerName;

        public Game()
        {
            InitializeComponent();
            log.updateLog("Game page initialized");
        }
            
        private void Game_OnKeyDown(object sender, KeyEventArgs e)
        {
            string keyString = null;
            
            if(e.Key == Key.W || e.Key == Key.Up)
            {
                Debug.WriteLine("W");
                if (Canvas.GetTop(PlayerPacMan) > 39)
                {
                    keyString = "W";
                }
            } 
            else
            {
                if (e.Key == Key.A || e.Key == Key.Left)
                {
                    Debug.WriteLine("A");
                    if (Canvas.GetLeft(PlayerPacMan) > 32)
                    {
                        keyString = "A";
                    }
                }
                else
                {
                    if (e.Key == Key.S || e.Key == Key.Down)
                    {
                        Debug.WriteLine("S");
                        if (Canvas.GetTop(PlayerPacMan) < 930)
                        {
                            keyString = "S";
                        }
                    }
                    else
                    {
                        if (e.Key == Key.D || e.Key == Key.Right)
                        {
                            Debug.WriteLine("D");
                            if (Canvas.GetLeft(PlayerPacMan) < 750)
                            {
                                keyString = "D";
                            }
                        }
                        else
                        {
                            Debug.WriteLine("No Key is pressed?");
                            keyString = null;
                        }
                    }
                }
            }
            
            player1.move(keyString, Canvas.GetLeft(PlayerPacMan), Canvas.GetLeft(PlayerPacMan));
            
            switch (keyString)
            {
                case "W":
                    PlayerPacMan.RenderTransform = new RotateTransform(90);
                    Canvas.SetTop(PlayerPacMan, (Canvas.GetTop(PlayerPacMan) - player1.getSpeed()));
                    player1.setOrientation(0);
                    break;
                case "A":
                    PlayerPacMan.RenderTransform = new RotateTransform(0);
                    Canvas.SetLeft(PlayerPacMan, Canvas.GetLeft(PlayerPacMan) - player1.getSpeed());
                    player1.setOrientation(3);
                    break;
                case "S":
                    PlayerPacMan.RenderTransform = new RotateTransform(270);
                    Canvas.SetTop(PlayerPacMan, Canvas.GetTop(PlayerPacMan) + player1.getSpeed());
                    player1.setOrientation(2);
                    break;
                case "D":
                    PlayerPacMan.RenderTransform = new RotateTransform(180);
                    Canvas.SetLeft(PlayerPacMan, Canvas.GetLeft(PlayerPacMan) + player1.getSpeed());
                    player1.setOrientation(1);
                    break;
            }

            
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
                log.updateLog("Window size toggled");
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            log.updateLog("Game starting");

            ButtonPlay.Visibility = Visibility.Hidden;
            ButtonBack.Visibility = Visibility.Hidden;

            drawMapStart();

            player1.setLifes(3);
            player1.setScore(0);
            //player1.setPos();
            
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
                            //fs.updateLogTimeStamp("Game init Done");
                        }
                    }
                }
            }
        }

        public void drawmap(int[,] map)
        {
            int[,] tempmap = new int[31,28];
            tempmap = gamesetup.getMap();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WIP");
        }

        public void setPlayer(string name)
        {
            playerName = name;
        }

        public void gameend()
        {
            savingscores savingscores = new savingscores();
            savingscores.setPlayer(playerName);
             
        }
    }
}