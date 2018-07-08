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

        public static GameController getInstance(String player1Name, String player2Name)
        {
            if (instance == null)
            {
                instance = new GameController(player1Name, player2Name);
            }

            return instance;
        }

        public void startGame()
        {
            Console.WriteLine("Starting game between " + player1Name + " and " + player2Name);
            startPlayerTurn(player1Name);
        }

        // TODO: Use player object to start turn
        void startPlayerTurn(String player)
        {
            Console.WriteLine("\nStarting turn for " + player);
            int actionCount = 0;
            while (actionCount < 3)
            {
                String actionInput = Console.ReadLine();
                TurnAction action = handleActionInput(actionInput);
                if (action.attemptExecute())
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
            switchTurns(player);
        }

        private void switchTurns(String currentPlayer) 
        {
            if (turnCounter > MAXIMUM_TURNS) {
                Console.WriteLine("\nMaximum turns played...ending game");
                return;
            }
            if (currentPlayer == player1Name) {
                startPlayerTurn(player2Name);
            } else {
                startPlayerTurn(player1Name);
            }
        }

        private TurnAction handleActionInput(String input)
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