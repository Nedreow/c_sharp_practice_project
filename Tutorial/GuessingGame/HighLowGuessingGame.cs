using System;
using System.Collections.Generic;

namespace Tutorial.GuessingGame
{
    public enum Games
    {
        HighLow
    }
    
    public interface IGuessingGame
    {
        int Play(int minimumNumber = 1, int maximumNumber = 100);
    }
    
    public class GuessingGame
    {
        private readonly Dictionary<Games, GuessingGameFactory>_factories;

        private GuessingGame()
        {
            _factories = new Dictionary<Games, GuessingGameFactory>();

            foreach (Games game in Enum.GetValues(typeof(Games)))
            {
                var factory = (GuessingGameFactory)Activator.CreateInstance(Type.GetType("Tutorial.GuessingGame." + Enum.GetName(typeof(Games), game) + "Factory"));
                _factories.Add(game, factory);
            }
        }
        
        public static GuessingGame InitializeFactories() => new GuessingGame();
            
        public IGuessingGame ExecuteCreation(Games action, bool automatic) =>_factories[action].Create(automatic);
    }
 
    public abstract class GuessingGameFactory
    {
        public abstract IGuessingGame Create(bool automatic = true);
    }

    public class HighLowFactory : GuessingGameFactory
    {
        public override IGuessingGame Create(bool automatic = true)
        {
            return new HighLowGuessingGame(automatic);
        }
    }
    
    public class HighLowGuessingGame : IGuessingGame
    {
        private readonly bool _automatic;
        private readonly Random _rand;
        
        private int _minNumber;
        private int _maxNumber;
        private int _goalNumber;
        private int _guesses;

        public HighLowGuessingGame(bool automatic = true)
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

        private bool CompareGuess(int guessedNumber)
        {
            if (guessedNumber == _goalNumber)
            {
                return true;
            }
            
            if (guessedNumber > _goalNumber)
            {
                _maxNumber = guessedNumber;
                Console.WriteLine("Your guess was larger than the correct number\n");
            } else if (guessedNumber < _goalNumber)
            {
                _minNumber = guessedNumber + 1;
                Console.WriteLine("Your guess was smaller than the correct number\n");
            }
            return false;
        }

        private void InitializeGame(int minimumNumber, int maximumNumber)
        {
            _minNumber = minimumNumber;
            _maxNumber = maximumNumber;
            _goalNumber = _rand.Next(_minNumber, _maxNumber);
            _guesses = 0;
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
    }
}
