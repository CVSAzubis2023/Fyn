using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pac_Man
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlockHeadLine.Text = "Login";
            
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonToggleSize_OnClick(object sender, RoutedEventArgs e)
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

        private void TextBoxName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string test;
            test = TextBoxName.Text;
        }
    }
}