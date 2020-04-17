using System;
namespace CatanConsoleBuild
{
    public class BoardVerticePath
    {
        BoardVertice fromVertice;
        BoardVertice toVertice;
        Starship starship;
        bool occupied;
        public BoardVerticePath(BoardVertice fromVertice, BoardVertice toVertice)
        {
            this.fromVertice = fromVertice;
            this.toVertice = toVertice;
            occupied = false;
        }

        public bool HasStarship()
        {
            return occupied;
        }

        public void SetStarship(Starship starship)
        {
            occupied = true;
            this.starship = starship;
        }

        public Starship GetStarship()
        {
            return starship;
        }

        public BoardVertice GetFromVertice()
        {
            return fromVertice;
        }

        public BoardVertice GetToVertice()
        {
            return toVertice;
        }
    }
}
