namespace Tutorial.GuessingGame
{
    public abstract class GuessingGameFactory
    {
        public abstract IGuessingGame Create(bool automatic = true);
    }
}