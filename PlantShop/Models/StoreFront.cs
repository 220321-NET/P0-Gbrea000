using System.Collections.Generic;
namespace Models
{
    public class Store
    {
        public List<Plant> PlantList { get; set; }
        public List<Plant> Cart { get; set; }

        public Store()
        {
            PlantList = new List<Plant>();
            Cart = new List<Plant>();
        }

        public decimal Checkout()
        {
            //initializing total cost to be 0
            decimal totalCost = 0;

            foreach (var c in Cart)
            {
                totalCost = totalCost + c.Price;
            }
            Cart.Clear();
            return totalCost;
        }
    }
}
