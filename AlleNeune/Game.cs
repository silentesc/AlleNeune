using System;
using System.Collections.Generic;

namespace AlleNeune
{
    internal class Game
    {
        readonly List<int> numbers = new List<int>();
        int nextIndex;

        /*
         * Generate numbers for the game
         * Min 3
         * Max 9
         * Default 5
         */
        public Game(int amount)
        {
            // Check for min and max
            if (amount < 3 || amount > 9)
            {
                amount = 5;
            }

            // Generate random number
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                int randomNumber;
                do
                {
                    randomNumber = random.Next(1, 10); // 1 - 9
                } while (numbers.Contains(randomNumber));
                numbers.Add(randomNumber);
            }
            nextIndex = 0;
        }

        /*
         * Check if the input number is the next number
         * Returns:
         *   1 if game is over and player wins
         *   0 if player input is correct and game keeps running
         *   -1 if game is over and player loses
         */
        public int NumberInput(int number)
        {
            // Game over, player wins
            if (nextIndex + 1 >= numbers.Count)
            {
                return 1;
            }
            // Game over, player loses
            else if (number != numbers[nextIndex])
            {
                return -1;
            }
            // Game running
            else
            {
                nextIndex++;
                return 0;
            }
        }

        /*
         * Get numbers to show them on the buttons
         */
        public List<int> GetNumbers()
        {
            return numbers;
        }
    }
}
