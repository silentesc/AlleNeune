using System;
using System.Windows;
using System.Windows.Controls;

namespace AlleNeune
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // When any game button is clicked
        private void ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(((Button)sender).Name);
        }

        // When the "Start Game" button is clicked
        private void ButtonClickStartEvent(object sender, RoutedEventArgs e)
        {
            Button startButton = (Button)sender;
            startButton.IsEnabled = false;
            startButton.Content = "Game running...";
        }
    }
}
