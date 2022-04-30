using Models;
namespace PlantShop
{
    class Program
    {
        static void Main(string[] args)
        {

            Store s = new Store();

            System.Console.WriteLine("Welcome to PlantShop!");

            int action = chooseAction();
            while (action != 0)
            {
                System.Console.WriteLine("You chose " + action);
                //action = chooseAction();

                switch (action)
                {
                    //Add new plant to inventory
                    case 1:
                        System.Console.WriteLine("You choose to add a new plant to the inventory");

                        String plantName = "";
                        Decimal plantPrice = 0;

                        System.Console.WriteLine("What is the plant name you'd like to add?");
                        plantName = Console.ReadLine();

                        System.Console.WriteLine("What is the plant's price?");
                        plantPrice = int.Parse(Console.ReadLine());

                        Plant newPlant = new Plant(plantName, plantPrice);
                        s.PlantList.Add(newPlant);

                        printInventory(s);
                        break;

                    //Add plant to cart
                    case 2:
                        System.Console.WriteLine("You chose to add plant to your cart");
                        printInventory(s);
                        System.Console.WriteLine("Which plant would you like to buy? (number)");
                        int plantChosen = int.Parse(Console.ReadLine());

                        s.Cart.Add(s.PlantList[plantChosen]);

                        printCart(s);
                        break;

                    //Checkout
                    case 3:
                        printCart(s);
                        System.Console.WriteLine("Your cart total is: $" + s.Checkout());
                        break;

                    default:
                        break;
                }
                action = chooseAction();
            }
        }

        private static void printCart(Store s)
        {
            System.Console.WriteLine("Plants you have decided to purchase: ");
            for (int i = 0; i < s.Cart.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + s.Cart[i]);
            }
        }

        private static void printInventory(Store s)
        {
            for (int i = 0; i < s.PlantList.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + s.PlantList[i]);
            }
        }
        static public int chooseAction()
        {
            int choice = 0;
            System.Console.WriteLine("Choose an action (0) to quit (1) to add a new plant to the inventory (2) add plant to cart (3) checkout");

            choice = int.Parse(Console.ReadLine());
            return choice;


        }
    }
}
