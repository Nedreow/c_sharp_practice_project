using System;

namespace Tutorial.GuessingGame
{
    // In this game the player enters a number in the console.
    // Then for every number the player enters afterwards the game returns 'hot' to indicate
    // the player is closer to the correct number, and 'cold' to indicate the player is further 
    // from the correct number
    public class HotColdGuessingGame : IGuessingGame
    {
        private readonly bool _automatic;
        private readonly Random _rand;
        
        private int _minNumber;
        private int _maxNumber;
        private int _goalNumber;
        private int _guesses;

        private bool _hasGuessed;
        private int _previousGuess;
        
        public HotColdGuessingGame(bool automatic = true)
        {
            _rand = new Random();
            _automatic = automatic;
        }
        
        public int Play(int minimumNumber = 1, int maximumNumber = 100)
        {
            InitializeGame(minimumNumber, maximumNumber);
            
            bool guessed = false;
            while (guessed == false)
            {
                int guessedNumber = ReceiveGuess();

                guessed = CompareGuess(guessedNumber);
            }
            Console.WriteLine($"Congratulations! You guessed {_goalNumber} correctly after {_guesses} guesses");
            return _guesses;
        }
        
        private int ReceiveGuess()
        {
            if (_automatic)
            {
                int guessedNumber = _rand.Next(_minNumber, _maxNumber);
                Console.WriteLine($"My guess is {guessedNumber}");
                _guesses++;

                return guessedNumber;
            }

            Console.WriteLine("Your integer guess is:");
            var userResponse = Console.ReadLine();

            try
            {
                var guessedNumber = Int32.Parse(userResponse ?? "0");
                Console.WriteLine($"Your guess is {guessedNumber}");
                _guesses++;

                return guessedNumber;
            }
            catch (FormatException)
            {
                Console.WriteLine("Your guess was invalid, please enter a valid number");
                return ReceiveGuess();
            }
        }
        
        private bool CompareGuess(int guessedNumber)
        {
            if (guessedNumber == _goalNumber)
            {
                return true;
            }
            
            if (!_hasGuessed)
            {
                _previousGuess = guessedNumber;
                
                return false;
            }

            return true;
        }
        
        private void InitializeGame(int minimumNumber, int maximumNumber)
        {
            _minNumber = minimumNumber;
            _maxNumber = maximumNumber;
            _goalNumber = _rand.Next(_minNumber, _maxNumber);
            _guesses = 0;

            _hasGuessed = false;
        }
    }
}