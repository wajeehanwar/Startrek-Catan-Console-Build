using System;
namespace CatanConsoleBuild
{
    public class Board
    {
        public BoardVertice[] unlinkedBoardVertices = new BoardVertice[Constants.TOTALBOARDVERTICES];


        public Board()
        {
            // Create new board


            //Initialize random valued tiles
            int[] boardResources = Shuffle(Constants.BOARD_RESOURCES);
            int[] numberResources = Shuffle(Constants.TILE_ACTIVATORS);
            Tile[] unlinkedTiles = new Tile[Constants.TOTALTILES];
            for (int i = 0, j = 0; i < Constants.TOTALTILES; i++)
            {
                // Account for Asteroid
                if (boardResources[i] == Constants.NONE)
                {
                    unlinkedTiles[i] = new Tile(i, boardResources[i], 7, Constants.PORTS2VERTICE[i]);
                    
                }
                else
                {
                    unlinkedTiles[i] = new Tile(i, boardResources[i], numberResources[j], Constants.PORTS2VERTICE[i]);
                    j++;
                }   
            }

            //Initialize board vertices
            //BoardVertice[] unlinkedBoardVertices = new BoardVertice[Constants.TOTALBOARDVERTICES];
            for (int i = 0; i < Constants.TOTALBOARDVERTICES; i++)
            {
                unlinkedBoardVertices[i] = new BoardVertice(i);
            }

            //Set associated tiles to each board vertice
            for (int i = 0, j = 0; i < Constants.TOTALBOARDVERTICES; i++)
            {
                if (Constants.TILES2VERTICE[j] == Constants.NOTILE)
                {
                    j += 3;
                } else if (Constants.TILES2VERTICE[j+1] == Constants.NOTILE)
                {
                    Tile[] tiles = { unlinkedTiles[Constants.TILES2VERTICE[j]] };
                    unlinkedBoardVertices[i].SetTiles(tiles);
                    j += 3;
                } else if (Constants.TILES2VERTICE[j+2] == Constants.NOTILE)
                {
                    Tile[] tiles = { unlinkedTiles[Constants.TILES2VERTICE[j]], unlinkedTiles[Constants.TILES2VERTICE[j+1]] };
                    unlinkedBoardVertices[i].SetTiles(tiles);
                    j += 3;
                } else
                {
                    Tile[] tiles = { unlinkedTiles[Constants.TILES2VERTICE[j]], unlinkedTiles[Constants.TILES2VERTICE[j+1]], unlinkedTiles[Constants.TILES2VERTICE[j+2]] };
                    unlinkedBoardVertices[i].SetTiles(tiles);
                    j += 3;
                }
            }


           
            //Set associated paths to each board vertice
            for (int i = 0, j = 0; i < Constants.TOTALBOARDVERTICES; i++)
            {
                if (Constants.PATHS2VERTICE[j] == Constants.NONE)
                {
                    j += 3;
                }
                else if (Constants.PATHS2VERTICE[j+1] == Constants.NONE)
                {
                    BoardVerticePath[] paths = { new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j]]) };
                    unlinkedBoardVertices[i].SetPaths(paths);
                    j += 3;
                }
                else if (Constants.PATHS2VERTICE[j + 2] == Constants.NONE)
                {
                    BoardVerticePath[] paths = { new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j]]),
                                                    new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j+1]])
                    };
                    unlinkedBoardVertices[i].SetPaths(paths);
                    j += 3;
                }
                else
                {
                    BoardVerticePath[] paths = { new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j]]),
                                                    new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j+1]]),
                                                    new BoardVerticePath(unlinkedBoardVertices[i], unlinkedBoardVertices[Constants.PATHS2VERTICE[j+2]])
                    };
                    unlinkedBoardVertices[i].SetPaths(paths);
                    j += 3;
                }
            }
        }

        private static int[] Shuffle(int[] arr)
        {
            Random r = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = r.Next(0, i + 1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            return arr;
        }

        public void Print()
        {
            BoardVertice[] board = unlinkedBoardVertices;
            Console.WriteLine();
            Console.WriteLine("            o       o       o            ");
            Console.WriteLine("          /   \\   /   \\   /   \\          ");
            Console.WriteLine("        o       o       o       o        ");
            Console.WriteLine("        |  {0}  |  {1}  |  {2}  |        ", GetTileAttributes(board, 2, 0), GetTileAttributes(board, 5, 0), GetTileAttributes(board, 8, 0));
            Console.WriteLine("        o       o       o       o        ");
            Console.WriteLine("      /   \\   /   \\   /   \\   /   \\      ");
            Console.WriteLine("    o       o       o       o       o    ");
            Console.WriteLine("    |  {0}  |  {1}  |  {2}  |  {3}  |    ", GetTileAttributes(board, 12, 0), GetTileAttributes(board, 16, 1), GetTileAttributes(board, 16, 2), GetTileAttributes(board, 20, 0));
            Console.WriteLine("    o       o       o       o       o    ");
            Console.WriteLine("  /   \\   /   \\   /   \\   /   \\   /   \\  ");
            Console.WriteLine("o       o       o       o       o       o");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", GetTileAttributes(board, 22, 0), GetTileAttributes(board, 26, 1), GetTileAttributes(board, 26, 2), GetTileAttributes(board, 30, 1), GetTileAttributes(board, 32, 0));
            Console.WriteLine("o       o       o       o       o       o");
            Console.WriteLine("  \\   /   \\   /   \\   /   \\   /   \\   /  ");
            Console.WriteLine("    o       o       o       o       o    ");
            Console.WriteLine("    |  {0}  |  {1}  |  {2}  |  {3}  |    ", GetTileAttributes(board, 45, 0), GetTileAttributes(board, 38, 1), GetTileAttributes(board, 38, 2), GetTileAttributes(board, 53, 0));
            Console.WriteLine("    o       o       o       o       o    ");
            Console.WriteLine("      \\   /   \\   /   \\   /   \\   /      ");
            Console.WriteLine("        o       o       o       o        ");
            Console.WriteLine("        |  {0}  |  {1}  |  {2}  |        ", GetTileAttributes(board, 57, 0), GetTileAttributes(board, 60, 0), GetTileAttributes(board, 63, 0));
            Console.WriteLine("        o       o       o       o        ");
            Console.WriteLine("          \\   /   \\   /   \\   /          ");
            Console.WriteLine("            o       o       o            ");
            Console.WriteLine();

        }

        private string GetTileAttributes(BoardVertice[] board, int vertice, int tile)
        {
            string result = "";
            string activator = "";
            if (board[vertice].GetTiles()[tile].GetActivatedBy() < 10)
            {
                activator += "0";
            }
            activator += board[vertice].GetTiles()[tile].GetActivatedBy().ToString();
            int resource = board[vertice].GetTiles()[tile].GetResource();


            switch (resource)
            {
                case Constants.WATER:
                    result = "W" + activator;
                    break;
                case Constants.FOOD:
                    result = "F" + activator;
                    break;
                case Constants.DILITHIUM:
                    result = "D" + activator;
                    break;
                case Constants.TRITANIUM:
                    result = "T" + activator;
                    break;
                case Constants.OXYGEN:
                    result = "O" + activator;
                    break;
                default:
                    result = "E" + activator;
                    break;

            }
            return result;
        }
    }
}
