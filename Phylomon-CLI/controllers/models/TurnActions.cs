﻿using System;
using PhylomonCLI.model;
using PhylomonCLI.model.cards;
using PhylomonCLI.providers;
namespace PhylomonCLI
{
    interface ITurnAction
    {
        /// <summary>
        /// Attempts to execute the given action
        /// </summary>
        /// <returns><c>true</c>, if execute succeeded, <c>false</c> otherwise.
        /// When an action succeeds, it counts towards the 3 moves total</returns>
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
          
            CardProvider.GetDefaultCards().ForEach((obj) => {
                Console.WriteLine(obj);
                Console.WriteLine();
            });

            return false;
        }
    }

    class ActionShow: ITurnAction 
    {
        Player player;

        public ActionShow(Player player) {
            this.player = player;
        }

        public bool AttemptExecute()
        {
            foreach (String prop in player.CardsInHand()) {
                Console.WriteLine(prop);
            }
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
