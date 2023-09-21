using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlleNeune
{
    public partial class MainWindow : Window
    {
        private Game game;
        private bool gameRunning;
        private readonly Button[] gameButtons;

        public MainWindow()
        {
            InitializeComponent();
            gameRunning = false;
            gameButtons = new Button[] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
        }

        /*
         * Get button by number
         */
        private Button GetButtonByNumber(int number)
        {
            switch (number)
            {
                case 1: return b1;
                case 2: return b2;
                case 3: return b3;
                case 4: return b4;
                case 5: return b5;
                case 6: return b6;
                case 7: return b7;
                case 8: return b8;
                case 9: return b9;
                default: return null;
            }
        }

        /*
         * Called when game ended to return buttons to default state
         */
        private void GameEnd()
        {
            // Enable start button
            startButton.IsEnabled = true;
            startButton.Content = "Start Game";

            foreach (Button button in gameButtons)
            {
                button.Background = Brushes.LightBlue;
            }

            gameRunning = false;
        }

        /*
         * When any game button is clicked
         */
        private void ButtonClickEvent(object sender, RoutedEventArgs e)
        {
            // Check if game is running
            if (!gameRunning)
            {
                return;
            }

            // Get number
            int number = int.Parse(((Button)sender).Name.Substring(1));

            // Input number to game
            int response = game.NumberInput(number);

            // Check for response
            if (response == -1)
            {
                ((Button)sender).Background = Brushes.DarkOrange;
                MessageBox.Show("You lost :(");
                GameEnd();
            }
            else if (response == 0)
            {
                ((Button)sender).Background = Brushes.DarkOrange;
            }
            else if (response == 1)
            {
                ((Button)sender).Background = Brushes.DarkOrange;
                MessageBox.Show("You won :D");
                GameEnd();
            }
        }

        /*
         * When the "Start Game" button is clicked
         */
        private async void ButtonClickStartEvent(object sender, RoutedEventArgs e)
        {
            // Get amount textbox
            string amountTextBoxStr = amountTextBox.Text;
            if (!int.TryParse(amountTextBoxStr, out int amount))
            {
                MessageBox.Show("Wrong amount");
                return;
            }

            // Disable start button
            startButton.IsEnabled = false;
            startButton.Content = "Game running...";

            // Start game
            game = new Game(amount);

            // Show numbers
            List<int> numbers = game.GetNumbers();
            for (int i = 0; i < numbers.Count; i++)
            {
                Button button = GetButtonByNumber(numbers[i]);
                button.Background = Brushes.DarkOrange;
                await Task.Delay(1000);
            }
            foreach (Button button in gameButtons)
            {
                button.Background = Brushes.LightBlue;
            }

            gameRunning = true;
        }
    }
}
