using System;
namespace CatanConsoleBuild
{
    public class BoardVertice
    {
        
        public int location;
        public Tile[] tiles;
        public BoardVerticePath[] paths;
        public Outpost outpost;
        public bool occupied;
        public BoardVertice(int location)
        {
            this.location = location;
        }

        public BoardVertice(int location, Tile[] tiles)
        {
            this.location = location;
            this.tiles = tiles;
            occupied = false;
        }

        public int GetLocation()
        {
            return location;
        }

        public void SetPaths(BoardVerticePath[] connections)
        {
            this.paths = connections;
        }

        public BoardVerticePath[] GetPaths()
        {
            return paths;
        }

        public void SetTiles(Tile[] tiles)
        {
            this.tiles = tiles;
        }

        public Tile[] GetTiles()
        {
            return tiles;
        }

        public void SetOutpost(Outpost outpost)
        {
            this.outpost = outpost;
            occupied = true;
        }

        public Outpost GetOutpost()
        {
            return outpost;
        }

        public bool HasOutpost()
        {
            return occupied;
        }
       

        
    }
}
