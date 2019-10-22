using System;
using Tutorial.GuessingGame;

namespace Tutorial
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int totalGuesses = 0;
            const int gamesToPlay = 1;
            var guessingGame = GuessingGame.GuessingGame.InitializeFactories().ExecuteCreation(Games.HighLow, false);

            for (int i = 0; i < gamesToPlay; i++)
            {
                totalGuesses += guessingGame.Play(1, 200);
            }

            float averageGuesses = (float)totalGuesses / gamesToPlay;
            Console.WriteLine($"the total number of guesses is {totalGuesses}");
            Console.WriteLine($"average guesses per game is {averageGuesses}");
        }
    }
}