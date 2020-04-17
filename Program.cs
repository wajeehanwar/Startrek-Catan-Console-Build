using System;
using System.Collections.Generic;
using System.Linq;

namespace CatanConsoleBuild
{
    static class Constants
    {
        public const int TOTALBOARDVERTICES = 66;
        public const int TOTALTILES = 19;
        public const int WINNINGPOINTS = 10;
        public const int EMPTY_VERTICE = -1;
        public const int NONE = 0;
        public const int NOTILE = -1;
        public const int WATER = 1;
        public const int OXYGEN = 2;
        public const int FOOD = 3;
        public const int DILITHIUM = 4;
        public const int TRITANIUM = 5;
        public const int GENERAL_PORT = 6;
        public static int[] BOARD_RESOURCES = { NONE, WATER, WATER, WATER, OXYGEN, OXYGEN, OXYGEN, OXYGEN, FOOD, FOOD, FOOD, FOOD, DILITHIUM, DILITHIUM, DILITHIUM, TRITANIUM, TRITANIUM, TRITANIUM, TRITANIUM };
        public static int[] TILE_ACTIVATORS = { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };

        public static int[] PORTS2VERTICE = { NONE, NONE, GENERAL_PORT, GENERAL_PORT, NONE, FOOD, FOOD, NONE, NONE, NONE, NONE, NONE, TRITANIUM, NONE, NONE, NONE, NONE, NONE, NONE, GENERAL_PORT, GENERAL_PORT, NONE, NONE, TRITANIUM, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, GENERAL_PORT, NONE, DILITHIUM, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, GENERAL_PORT, NONE, DILITHIUM, NONE, NONE, NONE, NONE, NONE, NONE, OXYGEN, OXYGEN, NONE, NONE, NONE, GENERAL_PORT, GENERAL_PORT, NONE, WATER, WATER, NONE, NONE, NONE, NONE };

        public static int[] TILES2VERTICE = { NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, 0, NOTILE, NOTILE, 0, NOTILE, NOTILE, 0, 1, NOTILE, 1, NOTILE, NOTILE, 1, 2, NOTILE, 2, NOTILE, NOTILE, 2, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, 3, NOTILE, NOTILE, 3, 0, NOTILE, 0, 3, 4, 0, 1, 4, 1, 4, 5, 1, 2, 5, 2, 5, 6, 2, 6, NOTILE, 6, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, 7, NOTILE, NOTILE, 3, 7, NOTILE, 3, 7, 8, 3, 4, 8, 4, 8, 9, 4, 5, 9, 5, 9, 10, 5, 6, 10, 6, 10, 11, 6, 11, NOTILE, 11, NOTILE, NOTILE, 7, NOTILE, NOTILE, 7, 12, NOTILE, 7, 8, 12, 8, 12, 13, 8, 9, 13, 9, 13, 14, 9, 10, 14, 10, 14, 15, 10, 11, 15, 11, 15, NOTILE, 11, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, 12, NOTILE, NOTILE, 12, 16, NOTILE, 12, 13, 16, 13, 16, 17, 13, 14, 17, 14, 17, 18, 14, 15, 18, 15, 18, NOTILE, 15, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, 16, NOTILE, NOTILE, 16, NOTILE, NOTILE, 16, 17, NOTILE, 17, NOTILE, NOTILE, 17, 18, NOTILE, 18, NOTILE, NOTILE, 18, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE, NOTILE };

        public static int[] PATHS2VERTICE = { NONE, NONE, NONE, NONE, NONE, NONE, 3, 13, NONE, 2, 4, NONE, 3, 5, 15, 4, 6, NONE, 5, 7, 17, 6, 8, NONE, 7, 19, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, 13, 23, NONE, 2, 12, 14, 13, 15, 25, 4, 14, 16, 15, 17, 27, 6, 16, 18, 17, 19, 29, 8, 18, 20, 19, 31, NONE, NONE, NONE, NONE, 23, 33, NONE, 12, 22, 24, 23, 25, 35, 14, 24, 26, 25, 27, 37, 16, 26, 28, 27, 29, 39, 18, 28, 30, 29, 31, 41, 20, 30, 32, 31, 43, NONE, 22, 34, NONE, 33, 35, 45, 24, 34, 36, 35, 37, 47, 26, 36, 38, 37, 39, 49, 28, 38, 40, 39, 41, 51, 30, 40, 42, 41, 43, 53, 32, 42, NONE, NONE, NONE, NONE, 34, 46, NONE, 45, 47, 57, 36, 46, 48, 47, 49, 59, 38, 48, 50, 49, 51, 61, 40, 50, 52, 51, 53, 63, 42, 52, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, NONE, 46, 58, NONE, 57, 59, NONE, 48, 58, 60, 59, 61, NONE, 50, 60, 62, 61, 63, NONE, 52, 62, NONE, NONE, NONE, NONE, NONE, NONE, NONE };

        public const int OUTPOST = 1;
        public const int STARBASE = 2;

    }



    class Program
    {
        static void Main(string[] args)
        {
            //Player[] players = initializePlayers();
            Board board = new Board();
            board.Print();
            

           
            
        }

        


        static Player[] initializePlayers()
        {
            Player[] players = new Player[4];
            Random random = new Random();
            string[] playerNames = new string[4];

            // Get player names.
            Console.Write("Enter the name for first player: ");
            playerNames[0] = Console.ReadLine();
            Console.Write("Enter the name for second player: ");
            playerNames[1] = Console.ReadLine();
            Console.Write("Enter the name for third player: ");
            playerNames[2] = Console.ReadLine();
            Console.Write("Enter the name for fourth player: ");
            playerNames[3] = Console.ReadLine();

            Console.WriteLine("We have 4 players: Let the game begin!");

            // Order players randomly based on dice.
            Console.WriteLine("Let's role the dice for each player to determine the player order");
            
            for (int i = 0; i < playerNames.Length; i++)
            {
                Console.WriteLine("{0} Press <ENTER> to role the dice...", playerNames[i]);
                _ = Console.Read();
                int diceValue = rollDice(random);
                Console.WriteLine("{0} rolled a {1}", playerNames[i], diceValue);

                // Check for duplicate dice roll.
                for (int j = 0; j < i; j++)
                {
                    if (players[j].GetOrder() == diceValue)
                    {
                        Console.WriteLine("Looks like you rolled the same as {0}. Lets roll the dice again!", players[j].GetName());
                        Console.WriteLine("{0} Press <ENTER> to role the dice...", playerNames[i]);
                        _ = Console.Read();
                        diceValue = rollDice(random);
                        Console.WriteLine("{0} rolled a {1}", playerNames[i], diceValue);
                        // Restart duplicate roll check.
                        j = 0;
                    }
                }

                // Set player unordered.
                players[i] = new Player(diceValue, playerNames[i]);
            }

            // Order the players by highest dice roll first
            Player[] orderedPlayers = new Player[4];
            int k = 0;
            foreach (Player player in players.OrderBy(player => player.GetOrder()).Reverse())
            {
                orderedPlayers[k++] = player;
            }

            foreach (Player player in orderedPlayers)
            {
                Console.WriteLine("Player: {0}, Order: {1}", player.GetName(), player.GetOrder());
            }

            return orderedPlayers;

        }


        static int rollDice(Random random)
        {
            return random.Next(1, 7);
        }
    }
}





//00   01   02---03---04---05---06---07---08   09   10
//          |     0   |     1   |     2   |
//11   12---13---14---15---16---17---18---19---20   21
//     |     3   |     4   |     5   |     6   |
//22---23---24---25---26---27---28---29---30---31---32
//|     7   |     8   |     9   |    10   |    11   |
//33---34---35---36---37---38---39---40---41---42---43
//     |    12   |    13   |    14   |    15   |
//44   45---46---47---48---49---50---51---52---53   54
//          |    16   |    17   |    18   |
//55   56   57---58---59---60---61---62---63   64   65