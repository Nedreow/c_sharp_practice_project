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
                int guessedNumber = _rand.Next(_minNumber, _maxNumber + 1);
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
                Console.WriteLine("Your guess was incorrect, please try again");
                _previousGuess = guessedNumber;
                _hasGuessed = true;
                
                return false;
            }

            while (guessedNumber == _previousGuess)
            {
                Console.WriteLine("That guess is the same as your last guess, please guess another integer");
                guessedNumber = ReceiveGuess();
            }

            var guessIsCloser = GuessIsCloser(guessedNumber);

            var difference = Math.Abs(guessedNumber - _previousGuess) / 2;
            
            if (guessIsCloser)
            {
                Console.WriteLine($"Your guess of {guessedNumber} is closer to the correct number than your last guess of {_previousGuess}");
                _previousGuess = guessedNumber;
                
                if (guessedNumber < _previousGuess)
                {
                    _maxNumber = guessedNumber + (difference > 0 ? difference : 1);
                }
                else
                {
                    _minNumber = guessedNumber - (difference > 0 ? difference : 1);
                }
            }
            else
            {
                Console.WriteLine($"Your guess of {guessedNumber} is farther from the correct number than your last guess of {_previousGuess}");

                if (guessedNumber < _previousGuess)
                {
                    _minNumber = guessedNumber + (difference > 0 ? difference : 1);
                }
                else
                {
                    _maxNumber = guessedNumber - (difference > 0 ? difference : 1);
                }
            }

            return false;
        }

        private bool GuessIsCloser(int guessedNumber)
        {
            return Math.Abs(guessedNumber - _goalNumber) < Math.Abs(_previousGuess - _goalNumber);
        }
        
        private void InitializeGame(int minimumNumber, int maximumNumber)
        {
            _minNumber = minimumNumber;
            _maxNumber = maximumNumber;
            _goalNumber = _rand.Next(_minNumber, _maxNumber + 1);
            _guesses = 0;

            _hasGuessed = false;
        }
    }
}