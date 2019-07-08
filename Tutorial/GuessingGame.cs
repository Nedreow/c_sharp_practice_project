using System;

public class GuessingGame
{
    private const bool Automatic = true;
    
    private int _minNumber;
    private int _maxNumber;
    private int _goalNumber;
    private int _guesses;
    private readonly Random _rand;

    public GuessingGame()
    {
        _rand = new Random();
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
        if (Automatic)
        {
            int guessedNumber = _rand.Next(_minNumber, _maxNumber);
            Console.WriteLine($"My guess is {guessedNumber}");
            _guesses++;
            
            return guessedNumber;
        }
        else
        {
            Console.WriteLine("Your integer guess is:");
            int guessedNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Your guess is {guessedNumber}");
            _guesses++;
            
            return guessedNumber;
        }
    }
}