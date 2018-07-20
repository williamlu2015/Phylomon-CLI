using System;
using PhylomonCLI.model;
using PhylomonCLI.model.cards;
namespace PhylomonCLI
{
    interface ITurnAction
    {
        /// <summary>
        /// Attempts to execute the given action
        /// </summary>
        /// <returns><c>true</c>, if execute succeeded, <c>false</c> otherwise.</returns>
        bool AttemptExecute();
    }

    class ActionPlay : ITurnAction
    {
        public bool AttemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Play");
            return true;
        }
    }

    class ActionMove : ITurnAction
    {
        public bool AttemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Move");
            return true;
        }
    }

    class ActionDrop : ITurnAction
    {
        public bool AttemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Drop");
            return true;
        }
    }

    class ActionPass : ITurnAction
    {
        public bool AttemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Pass");
            return true;
        }
    }


    class ActionInspect : ITurnAction
    {
        string input;

        public ActionInspect(string input) {
            this.input = input;
        }

        public bool AttemptExecute()
        {
            string[] tokens = input.Split(' ');
            try {
                string value = GameController
                    .GetInstance()
                    .board
                    .InspectPosition(
                        ConvertToPosition(tokens[1], tokens[2]));
                Console.Write(value);
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Invalid inspect command: " + input);
            }
            return false;
        }

        private Position ConvertToPosition(string token1, string token2) {
            return new Position(Int32.Parse(token1), Int32.Parse(token2));
        }
    }

    class ActionDebug : ITurnAction
    {
        public bool AttemptExecute()
        {
            // put all debug code here
            SpeciesCard card = SpeciesCard.parseWrappedFromString(Examples.marbledMurrelet);
            card.Properties().ForEach((obj) => Console.WriteLine(obj));
            Console.WriteLine();

            SpeciesCard card1 = SpeciesCard.parseWrappedFromString(Examples.killerWhale);
            card1.Properties().ForEach((obj) => Console.WriteLine(obj));
            Console.WriteLine();


            SpeciesCard card2 = SpeciesCard.parseWrappedFromString(Examples.seaOtter);
            card2.Properties().ForEach((obj) => Console.WriteLine(obj));
            Console.WriteLine();


            SpeciesCard card3 = SpeciesCard.parseWrappedFromString(Examples.himilayanBlackberry);
            card3.Properties().ForEach((obj) => Console.WriteLine(obj));
            Console.WriteLine();

            return false;
        }
    }

    class ActionUndefined: ITurnAction
    {
        public bool AttemptExecute()
        {
            return false;
        }
    }
}
