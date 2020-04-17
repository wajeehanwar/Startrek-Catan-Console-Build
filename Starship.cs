using System;
namespace CatanConsoleBuild
{
    public class Starship
    {
        BoardVerticePath location;
        Player owner;

        public Starship(Player owner, BoardVerticePath location)
        {
            this.location = location;
            this.owner = owner;
        }

        public BoardVerticePath GetLocation()
        {
            return location;
        }

        public Player GetOwner()
        {
            return owner;
        }
    }
}
