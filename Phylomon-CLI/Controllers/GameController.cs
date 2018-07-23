using System;
using PhylomonCLI.model;
using PhylomonCLI.providers;
namespace PhylomonCLI
{
    class GameController
    {
        static GameController instance = null;
        static int MAXIMUM_TURNS = 6;

        const String HELP = "Actions Available:\n\tPlay <No Functionality>\n\tMove <No Functionality>\n\tDrop <No Functionality>\n\tPass ends your turn\n\tShow shows the cards in your hand\n\tInspect <X-POS> <Y-POS> displays the cards in the vicinity\n";
       
        CardProvider cardProvider = CardProvider.GetInstance();
        public Board board;
        Player player1;
        Player player2;

        static Player currentPlayer;
        int turnCounter = 0;

        private GameController(string player1, string player2)
        {
            this.player1 = new Player(player1, CardProvider.GetDefaultCards());
            this.player2 = new Player(player2, CardProvider.GetDefaultCards());
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
                Console.WriteLine("Starting game between " + player1.Name + " and " + player2.Name);
                StartPlayerTurn(player1);
        }

        // TODO: Use player object to start turn
        void StartPlayerTurn(Player player)
        {
            Console.WriteLine("\nStarting turn for " + player.Name);
            currentPlayer = player;

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

        private void NextTurn(Player currentPlayer) 
        {
            if (turnCounter > MAXIMUM_TURNS) {
                Console.WriteLine("\nMaximum turns played...ending game");
                return;
            }
            if (currentPlayer.Name == player1.Name) {
                StartPlayerTurn(player2);
            } else {
                StartPlayerTurn(player1);
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
                case "show":
                    return new ActionShow(currentPlayer);
                case "inspect":
                    return new ActionInspect(input);
                case "debug":
                    return new ActionDebug();
                default:
                    Console.WriteLine("No action matching " + userAction);
                    Console.WriteLine(HELP);
                    return new ActionUndefined();
            }
        }

    }
}