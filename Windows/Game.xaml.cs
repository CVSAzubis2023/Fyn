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
        //log log = new log();
        
        player player1 = new player("name", 0,0);

        ghost ghostRed = new ghost("Red", 0);
        ghost ghostBlue = new ghost("Blue", 1);
        ghost ghostOrange = new ghost("Orange", 2);
        ghost ghostPurple = new ghost("Purple", 3);

        #region Player Info

        private string playerName;
        private int score;
        private int level;
        private int moves;
        private int timesplayed;
        private int highscore;
        private double playtime;

        #endregion

        #region Constructors

        public Game()
        {
            InitializeComponent();
            //log.updateLog("Game page initialized");
        }

        public Game(string name)
        {
            playerName = name;

            InitializeComponent();
            //log.updateLog("Game page initialized");
        }

        #endregion

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
                        if (Canvas.GetTop(PlayerPacMan) < 850)
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
            
            switch (keyString)
            {
                case "W":
                    PlayerPacMan.RenderTransform = new RotateTransform(90);
                    Canvas.SetTop(PlayerPacMan, (Canvas.GetTop(PlayerPacMan) - player1.getSpeed()));
                    player1.setOrientation(0);
                    break;
                case "A":
                    PlayerPacMan.RenderTransform = new RotateTransform(0);
                    //Canvas.SetLeft(PlayerPacMan, Canvas.GetLeft(PlayerPacMan) - player1.getSpeed());
                    player1.setOrientation(3);
                    break;
                case "S":
                    PlayerPacMan.RenderTransform = new RotateTransform(270);
                    Canvas.SetTop(PlayerPacMan, Canvas.GetTop(PlayerPacMan) + player1.getSpeed());
                    player1.setOrientation(2);
                    break;
                case "D":
                    PlayerPacMan.RenderTransform = new RotateTransform(180);
                    //Canvas.SetLeft(PlayerPacMan, Canvas.GetLeft(PlayerPacMan) + player1.getSpeed());
                    player1.setOrientation(1);
                    break;
            }

            
            ghostRed.move(player1.getPos());
            if (player1.getTilesMoved() > 49)
            {
                ghostBlue.move(player1.getPos());
                if (player1.getTilesMoved() > 99)
                {
                    ghostOrange.move(player1.getPos());
                    if (player1.getTilesMoved() > 150)
                    {
                        ghostPurple.move(player1.getPos());
                    }
                }
            }
            
            //Blue ghost
            game.collisionDetection(player1.getPos(), ghostBlue.getPos());
            //Red ghost
            game.collisionDetection(player1.getPos(), ghostRed.getPos());
            //Yellow ghost
            game.collisionDetection(player1.getPos(), ghostOrange.getPos());
            //Purple ghost
            game.collisionDetection(player1.getPos(), ghostPurple.getPos());
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
                //log.updateLog("Window size toggled");
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            //log.updateLog("Game starting");

            ButtonPlay.Visibility = Visibility.Hidden;
            ButtonBack.Visibility = Visibility.Hidden;

            drawMapStart();

            player1.setLifes(3);
            player1.setScore(0);
            player1.setPos(200, 200);
            
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

        public void gameend()
        {
            score = player1.getScore();
            level = gamesetup.getCurrentMap();
            moves = player1.getTilesMoved();

            savingscores ssc = new savingscores(playerName, score, level, moves, timesplayed, highscore, playtime);

            ssc.SQLSetup();
            if (ssc.saveScores())
            {


            }
        }
    }
}