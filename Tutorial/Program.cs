using System;
using Tutorial.GuessingGame;

namespace Tutorial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PlayGuessingGame();
        }
        
        private static void PlayGuessingGame()
        {
             var totalGuesses = 0;
             const int gamesToPlay = 100;
             var highLow = new HighLow();
 
             for (var i = 0; i < gamesToPlay; i++)
             {
                 totalGuesses += highLow.Play();
             }
 
             var averageGuesses = (float)totalGuesses / gamesToPlay;
             Console.WriteLine($"the total number of guesses is {totalGuesses}");
             Console.WriteLine($"average guesses per game is {averageGuesses}");
        }
    }
}