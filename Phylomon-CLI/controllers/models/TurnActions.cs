using System;
namespace PhylomonCLI
{
    interface ITurnAction
    {
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

    class ActionUndefined: ITurnAction
    {
        public bool AttemptExecute()
        {
            return false;
        }
    }
}
