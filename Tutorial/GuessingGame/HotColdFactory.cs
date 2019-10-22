namespace Tutorial.GuessingGame
{
    public class HotColdFactory : GuessingGameFactory
    {
        public override IGuessingGame Create(bool automatic = true)
        {
            return new HotColdGuessingGame(automatic);
        }
    }
}