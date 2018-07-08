using System;
using PhylomonCLI.model;
namespace PhylomonCLI
{
    class GameController
    {
        static GameController instance = null;
        private static int MAXIMUM_TURNS = 6;

        public Board board;
        string player1Name;
        string player2Name;
        int turnCounter = 0;

        private GameController(string player1, string player2)
        {
            this.player1Name = player1;
            this.player2Name = player2;
            board = new Board();
        }

        public static GameController GetInstance(string player1Name, string player2Name)
        {
            if (instance == null)
            {
                instance = new GameController(player1Name, player2Name);
            }

            return instance;
        }

        public static GameController GetInstance()
        {
            return GetInstance("defaultPlayer1", "defaultPlayer2");
        }

        public void StartGame()
        {
            Console.WriteLine("Starting game between " + player1Name + " and " + player2Name);
            StartPlayerTurn(player1Name);
        }

        // TODO: Use player object to start turn
        void StartPlayerTurn(string player)
        {
            Console.WriteLine("\nStarting turn for " + player);
            int actionCount = 0;
            while (actionCount < 3)
            {
                string actionInput = Console.ReadLine();
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

        private void NextTurn(string currentPlayer) 
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

        private ITurnAction HandleActionInput(string input)
        {
            string[] tokens = input.Split(new char[] { ' ' });
            if (tokens.Length == 0) return new ActionUndefined();
            string userAction = tokens[0].ToLower();
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
                case "inspect":
                    return new ActionInspect(input);
                default:
                    Console.WriteLine("No action matching " + userAction);
                    return new ActionUndefined();
            }
        }

    }
}