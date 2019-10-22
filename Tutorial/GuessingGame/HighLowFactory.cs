namespace Tutorial.GuessingGame
{
    public class HighLowFactory : GuessingGameFactory
    {
        public override IGuessingGame Create(bool automatic = true)
        {
            return new HighLowGuessingGame(automatic);
        }
    }
}