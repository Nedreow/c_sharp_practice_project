using System;

namespace Tutorial.GuessingGame
{
    public class HighLow
    {
        private int _goalNumber;
        
        public int MinNumber;
        public int MaxNumber;
        public int Guesses;
        private readonly Random _rand;

        public HighLow()
        {
            _rand = new Random();
        }

        public int GetRandomNumberBetweenBounds()
        {
            return _rand.Next(MinNumber, MaxNumber);
        }
        
        public int Play(int minimumNumber = 1, int maximumNumber = 100)
        {
            InitializeGame(minimumNumber, maximumNumber);
            
            var guessed = false;
            while (guessed == false)
            {
                var guessedNumber = ReceiveGuess();

                guessed = CompareGuess(guessedNumber);
            }
            Console.WriteLine($"Congratulations! You guessed {_goalNumber} correctly after {Guesses} guesses");
            return Guesses;
        }

        private bool CompareGuess(int guessedNumber)
        {
            if (guessedNumber == _goalNumber)
            {
                return true;
            }
            
            if (guessedNumber > _goalNumber)
            {
                MaxNumber = guessedNumber;
                Console.WriteLine("Your guess was larger than the correct number\n");
            } else if (guessedNumber < _goalNumber)
            {
                MinNumber = guessedNumber + 1;
                Console.WriteLine("Your guess was smaller than the correct number\n");
            }
            return false;
        }

        private void InitializeGame(int minimumNumber, int maximumNumber)
        {
            MinNumber = minimumNumber;
            MaxNumber = maximumNumber;
            _goalNumber = GetRandomNumberBetweenBounds();
            Guesses = 0;
        }

        private int ReceiveGuess(bool automatic = true)
        {
            if (automatic)
            {
                return HighLowAiHalfing.MakeGuess(this);
            }
            else
            {
                Console.WriteLine("Your integer guess is:");
                int guessedNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Your guess is {guessedNumber}");
                Guesses++;
                
                return guessedNumber;
            }
        }
    }
}