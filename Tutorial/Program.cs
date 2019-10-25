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
            
            Console.WriteLine("what game do you want to play: ");
            foreach (var game in Enum.GetNames(typeof(Games)))
            {
                Console.WriteLine($"{game}");
            }
            
            var guessingGame = GuessingGame.GuessingGame.InitializeFactories().ExecuteCreation(GetGameToPlay(), false);

            for (int i = 0; i < gamesToPlay; i++)
            {
                totalGuesses += guessingGame.Play(1, 20);
            }

            float averageGuesses = (float)totalGuesses / gamesToPlay;
            Console.WriteLine($"the total number of guesses is {totalGuesses}");
            Console.WriteLine($"average guesses per game is {averageGuesses}");
        }

        private static Games GetGameToPlay()
        {
            try
            {
                return (Games)Enum.Parse(typeof(Games),Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a valid game to play");
                return GetGameToPlay();
            }
        }
    }
}