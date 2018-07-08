using System;

namespace PhylomonCLI {
    class MainClass {
        public static void Main(string[] args) {
            if (args.Length != 2) 
            {
                Console.WriteLine("Usage: <player1Name: String> <player2Name: String>");
                return;
            } else {
                GameController mGameController = GameController.GetInstance(args[0], args[1]);
                mGameController.StartGame();
            }
        }
    }
}