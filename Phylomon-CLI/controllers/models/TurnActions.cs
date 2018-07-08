using System;
namespace PhylomonCLI
{
    interface TurnAction
    {
        bool attemptExecute();
    }

    class ActionPlay : TurnAction
    {
        public bool attemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Play");
            return true;
        }
    }

    class ActionMove : TurnAction
    {
        public bool attemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Move");
            return true;
        }
    }

    class ActionDrop : TurnAction
    {
        public bool attemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Drop");
            return true;
        }
    }

    class ActionPass : TurnAction
    {
        public bool attemptExecute()
        {
            Console.WriteLine("\tAttempting to execute action: Pass");
            return true;
        }
    }

    class ActionUndefined: TurnAction
    {
        public bool attemptExecute()
        {
            return false;
        }
    }
}
