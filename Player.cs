using System;
using System.Collections.Generic;

namespace CatanConsoleBuild
{
    public class Player
    {
        readonly int order;
        readonly string name;
        private int points;
        private bool longestSupplyRoute;
        private bool largestStarfleet;
        private bool active;
        private PlayerResources resources;
        private List<Outpost> outposts;
        private List<Starship> starShips;
        //public PlayerDevelopmentCards developmentCards;


        public Player(int order, string name)
        {
            this.order = order;
            this.name = name;
            points = 0;
            longestSupplyRoute = false;
            largestStarfleet = false;
            active = false;
            resources = new PlayerResources();
        }

        public int GetOrder()
        {
            return order;
        }

        public string GetName()
        {
            return name;
        }

        public PlayerResources GetResources()
        {
            return resources;
        }

        public void SetPoints(int points)
        {
            this.points = points;
        }
        
        public int GetPoints()
        {
            return points;
        }

        public void SetLongestSupplyRoute()
        {   
            longestSupplyRoute = true;
            points += 2;
            
        }

        public bool GetLongestSupplyRoute()
        {
            return longestSupplyRoute;
        }

        public void SetLargestStarfleet(bool toggle)
        {
            largestStarfleet = toggle;
        }

        public bool GetLargestStarfleet()
        {
            return largestStarfleet;
        }

        public void SetActive(bool toggle)
        {
            active = toggle;
        }

        public bool GetActive()
        {
            return active;
        }

        public bool SetFirstOutpost(Player player, BoardVertice vertice)
        {
            if (vertice.HasOutpost())
            {
                return false;
            } else
            {
                //create outpost
                Outpost newOutpost = new Outpost(player, vertice);
                // add outpost to player
                outposts.Add(newOutpost);
                // add outpost to vertice
                vertice.SetOutpost(newOutpost);
                //add points
                points++;
                return true;
            }
        }

        public bool SetOutpost(Player player, BoardVertice vertice)
        {
            // Disqualify if insufficiant resources.
            if (resources.GetDilithium() < 1 || resources.GetTritanium() < 1 || resources.GetFood() < 1 || resources.GetOxygen() < 1)
            {
                return false;
            }
            // Disqualify if outpost already present.
            if (vertice.HasOutpost())
            {
                return false;
            }
            // Disqualify if outpost at adjacent vertices and no starship present.
            bool hasStarship = false;
            foreach (BoardVerticePath path in vertice.GetPaths())
            {
                if (path.HasStarship() && path.GetStarship().GetOwner().GetOrder() == order)
                {
                    hasStarship = true;
                }
                if (path.GetToVertice().HasOutpost())
                {
                    return false;
                }
            }
            if (!hasStarship)
            {
                return false;
            }
            // Evaluate second degree starship
            foreach (BoardVerticePath path in vertice.GetPaths())
            {
                if (path.HasStarship())
                {
                    foreach (BoardVerticePath nextDegreePath in path.GetToVertice().GetPaths())
                    {
                        if (nextDegreePath.HasStarship() && nextDegreePath.GetStarship().GetOwner().GetOrder() == order && nextDegreePath.GetToVertice().GetLocation() != vertice.GetLocation())
                        {
                            //create outpost
                            Outpost newOutpost = new Outpost(player, vertice);
                            // Add outpost to player
                            outposts.Add(newOutpost);
                            // Add outpost to vertice
                            vertice.SetOutpost(newOutpost);
                            // Remove resources from player
                            resources.RemoveDilithium(1);
                            resources.RemoveTritanium(1);
                            resources.RemoveFood(1);
                            resources.RemoveOxygen(1);
                            // Add points
                            points++;
                            return true;
                        }
                    }
                }
            }
            // No second degree starship present.
            return false;
        }

        public bool SetStarship(Player player, BoardVerticePath path)
        {
            // Disqualify if insufficiant resources.
            if (resources.GetDilithium() < 1 || resources.GetTritanium() < 1)
            {
                return false;
            }
            // Disqualify if starship already present
            if (path.HasStarship())
            {
                return false;
            }


            // Qualify if player owns an outpost at either end of the path.
            if ((path.GetFromVertice().HasOutpost() && path.GetFromVertice().GetOutpost().GetOwner().GetOrder() == order)
                || (path.GetToVertice().HasOutpost() && path.GetToVertice().GetOutpost().GetOwner().GetOrder() == order))
            {
                // Add new starship
                Starship newStarship = new Starship(player, path);
                path.SetStarship(newStarship);
                // Remove resources from player
                resources.RemoveDilithium(1);
                resources.RemoveTritanium(1);
                return true;
            }
            // Qualify if player owns an existing starship on leading paths
            bool ownsExistingStarship = false;
            foreach (BoardVerticePath nextDegreePath in path.GetFromVertice().GetPaths())
            {
                if (nextDegreePath.HasStarship() && nextDegreePath.GetStarship().GetOwner().GetOrder() == order)
                {
                    ownsExistingStarship = true;
                }
            }
            foreach (BoardVerticePath nextDegreePath in path.GetToVertice().GetPaths())
            {
                if (nextDegreePath.HasStarship() && nextDegreePath.GetStarship().GetOwner().GetOrder() == order)
                {
                    ownsExistingStarship = true;
                }
            }
            if (ownsExistingStarship)
            {
                // Add new starship
                Starship newStarship = new Starship(player, path);
                path.SetStarship(newStarship);
                // Remove resources from player
                resources.RemoveDilithium(1);
                resources.RemoveTritanium(1);
                return true;
            }

            return false;
        }

        //private bool GameOver()
        //{
        //    if (points >= Constants.WINNINGPOINTS)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
