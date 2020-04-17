/*
* Port represents a port on a BoardVertice.  A port can be an outpost worth 1
* point or a starbase worth 2 points.
* */

using System;

namespace CatanConsoleBuild
{
    
    public class Outpost
    {
        private readonly Player owner;
        private readonly BoardVertice location;
        private int pointValue;

        public Outpost(Player owner, BoardVertice location)
        {
            pointValue = Constants.OUTPOST;
            this.owner = owner;
            this.location = location;
        }

        public bool UpgradeOutpost()
        {
            // Disqualify if already upgraded.
            if (pointValue == Constants.STARBASE)
            {
                return false;
            }
            // Disqualify if insufficiant resources.
            if (owner.GetResources().GetWater() < 3 || owner.GetResources().GetOxygen() < 2)
            {
                return false;
            }

            pointValue = Constants.STARBASE;
            return true;
        }

        public int GetPoints()
        {
            return pointValue;
        }

        public BoardVertice GetLocation()
        {
            return location;
        }

        public Player GetOwner()
        {
            return owner;
        }
    }
}
