using System;
namespace CatanConsoleBuild
{
    public class Tile
    {
        public int tileNumber;
        public int resource;
        public int activatedBy;
        public bool tileBlocked;
        public int tradingPost;

        public Tile(int tileNumber, int resource, int activatedBy, int tradingPost)
        {
            this.tileNumber = tileNumber;
            this.resource = resource;
            this.activatedBy = activatedBy;
            this.tradingPost = tradingPost;
        }

        public int GetTileNumber()
        {
            return tileNumber;
        }

        public int GetResource()
        {
            return resource;
        }

        public int GetActivatedBy()
        {
            return activatedBy;
        }

        public int GetTradingPost()
        {
            return tradingPost; 
        }

        public bool HasTradingPost()
        {
            if (tradingPost != Constants.NONE)
            {
                return false;
            }
            return true;
        }

        public void BlockTile()
        {
            tileBlocked = true;
        }

        public void UnBlockTile()
        {
            tileBlocked = false;
        }
    }
}
