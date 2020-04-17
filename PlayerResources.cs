using System;
namespace CatanConsoleBuild
{
    public class PlayerResources
    {
        public int tritanium;
        public int dilithium;
        public int oxygen;
        public int water;
        public int food;

        public PlayerResources()
        {
            tritanium = 0;
            dilithium = 0;
            oxygen = 0;
            water = 0;
            food = 0;
        }

        public PlayerResources(int tritanium, int dilithium, int oxygen, int water, int food)
        {
            this.tritanium = tritanium;
            this.dilithium = dilithium;
            this.oxygen = oxygen;
            this.water = water;
            this.food = food;
        }

        public int GetTritanium()
        {
            return tritanium;
        }

        public void AddTritanium(int amount)
        {
            tritanium += amount;
        }

        public void RemoveTritanium(int amount)
        {
            tritanium -= amount;
        }

        public int GetDilithium()
        {
            return dilithium;
        }

        public void AddDilithium(int amount)
        {
            dilithium += amount;
        }

        public void RemoveDilithium(int amount)
        {
            dilithium -= amount;
        }

        public int GetOxygen()
        {
            return oxygen;
        }
        public void AddOxygen(int amount)
        {
            oxygen += amount;
        }

        public void RemoveOxygen(int amount)
        {
            oxygen -= amount;
        }

        public int GetWater()
        {
            return water;
        }

        public void AddWater(int amount)
        {
            water += amount;
        }

        public void RemoveWater(int amount)
        {
            water -= amount;
        }

        public int GetFood()
        {
            return food;
        }

        public void AddFood(int amount)
        {
            tritanium += amount;
        }

        public void RemoveFood(int amount)
        {
            tritanium -= amount;
        }


    }
}
