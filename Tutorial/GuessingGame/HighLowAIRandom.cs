using System;

namespace Tutorial.GuessingGame
{
    public static class HighLowAiRandom
    {
        public static int MakeGuess(HighLow game)
        {
            int guessedNumber = game.GetRandomNumberBetweenBounds();
            Console.WriteLine($"My guess is {guessedNumber}");
            game.Guesses++;
            
            return guessedNumber;
        }
    }
}

