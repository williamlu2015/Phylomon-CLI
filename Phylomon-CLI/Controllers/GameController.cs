using System;
namespace PhylomonCLI
{
    class GameController
    {
        static GameController instance = null;
        private static int MAXIMUM_TURNS = 6;

        String player1Name;
        String player2Name;
        int turnCounter = 0;

        private GameController(String player1, String player2)
        {
            this.player1Name = player1;
            this.player2Name = player2;
        }

        public static GameController GetInstance(String player1Name, String player2Name)
        {
            if (instance == null)
            {
                instance = new GameController(player1Name, player2Name);
            }

            return instance;
        }

        public void StartGame()
        {
            Console.WriteLine("Starting game between " + player1Name + " and " + player2Name);
            StartPlayerTurn(player1Name);
        }

        // TODO: Use player object to start turn
        void StartPlayerTurn(String player)
        {
            Console.WriteLine("\nStarting turn for " + player);
            int actionCount = 0;
            while (actionCount < 3)
            {
                String actionInput = Console.ReadLine();
                ITurnAction action = HandleActionInput(actionInput);
                if (action.AttemptExecute())
                {
                    if (action is ActionPass)
                    {
                        break;
                    }
                    ++actionCount;
                }
            }
            Console.WriteLine("Completed turn for " + player);
            ++turnCounter;
            NextTurn(player);
        }

        private void NextTurn(String currentPlayer) 
        {
            if (turnCounter > MAXIMUM_TURNS) {
                Console.WriteLine("\nMaximum turns played...ending game");
                return;
            }
            if (currentPlayer == player1Name) {
                StartPlayerTurn(player2Name);
            } else {
                StartPlayerTurn(player1Name);
            }
        }

        private ITurnAction HandleActionInput(String input)
        {
            String[] tokens = input.Split(new char[] { ' ' });
            if (tokens.Length == 0) return new ActionUndefined();
            String userAction = tokens[0].ToLower();
            switch (userAction)
            {
                case "play":
                    return new ActionPlay();
                case "move":
                    return new ActionMove();
                case "drop":
                    return new ActionDrop();
                case "pass":
                    return new ActionPass();
                default:
                    Console.WriteLine("No action matching " + userAction);
                    return new ActionUndefined();
            }
        }

    }
}