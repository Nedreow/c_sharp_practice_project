using System;

namespace Tutorial.GuessingGame
{
    public class HighLowAiHalfing
    {
        public static int MakeGuess(HighLow game)
        {
            int guessedNumber = GetHalfwayNumber(game);
            Console.WriteLine($"My guess is {guessedNumber}");
            game.Guesses++;
            
            return guessedNumber;
        }

        private static int GetHalfwayNumber(HighLow game)
        {
            return (game.MaxNumber - game.MinNumber) / 2 + game.MinNumber;
        }
    }
}