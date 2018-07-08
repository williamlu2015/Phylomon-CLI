using System;
using PhylomonCLI.model;
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

    class ActionUndefined: ITurnAction
    {
        public bool AttemptExecute()
        {
            return false;
        }
    }
}
