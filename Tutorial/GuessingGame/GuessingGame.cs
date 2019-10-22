using System;
using System.Collections.Generic;

namespace Tutorial.GuessingGame
{
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
}