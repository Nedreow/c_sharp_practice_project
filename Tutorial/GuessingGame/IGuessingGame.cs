namespace Tutorial.GuessingGame
{
    public interface IGuessingGame
    {
        int Play(int minimumNumber = 1, int maximumNumber = 100);
    }
}