using Models;
namespace PlantShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //Choose Store Location
            System.Console.WriteLine("Welcome to PlantShop!");

            int storeLocation = chooseStoreLocation();
            while (storeLocation != 0)
            {
                System.Console.WriteLine("You chose " + storeLocation);
                switch (storeLocation)
                {
                    //Boston location
                    case 1:

                        //Boston Store
                        Store boston = new Store();

                        System.Console.WriteLine("Welcome to PlantShop Boston!");

                        int actionBoston = chooseActionBoston();
                        while (actionBoston != 0)
                        {
                            System.Console.WriteLine("You chose " + actionBoston);

                            switch (actionBoston)
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
                                    boston.PlantList.Add(newPlant);

                                    printBostonInventory(boston);
                                    break;

                                //Add plant to cart
                                case 2:
                                    System.Console.WriteLine("You chose to add plant to your cart");
                                    printBostonInventory(boston);
                                    System.Console.WriteLine("Which plant would you like to buy? (number)");
                                    int plantChosen = int.Parse(Console.ReadLine());

                                    boston.Cart.Add(boston.PlantList[plantChosen]);

                                    printBostonCart(boston);
                                    break;

                                //Checkout
                                case 3:
                                    printBostonCart(boston);
                                    System.Console.WriteLine("Your cart total is: $" + boston.Checkout());
                                    break;

                                default:
                                    break;
                            }
                            actionBoston = chooseActionBoston();
                        }
                        break;

                    //lancaster location
                    case 2:

                        //Lancaster Store
                        Store lancaster = new Store();

                        System.Console.WriteLine("Welcome to PlantShop Lancaster!");

                        int actionLancaster = chooseActionLancaster();
                        while (actionLancaster != 0)
                        {
                            System.Console.WriteLine("You chose " + actionLancaster);

                            //action = chooseAction();
                            switch (actionLancaster)
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
                                    lancaster.PlantList.Add(newPlant);

                                    printLancasterInventory(lancaster);
                                    break;

                                //Add plant to cart
                                case 2:
                                    System.Console.WriteLine("You chose to add plant to your cart");
                                    printLancasterInventory(lancaster);
                                    System.Console.WriteLine("Which plant would you like to buy? (number)");
                                    int plantChosen = int.Parse(Console.ReadLine());

                                    lancaster.Cart.Add(lancaster.PlantList[plantChosen]);

                                    printLancasterCart(lancaster);
                                    break;

                                //Checkout
                                case 3:
                                    printLancasterCart(lancaster);
                                    System.Console.WriteLine("Your cart total is: $" + lancaster.Checkout());
                                    break;

                                default:
                                    break;
                            }
                            actionLancaster = chooseActionLancaster();
                        }
                        break;
                }
                storeLocation = chooseStoreLocation();
            }
        }

        private static void printBostonCart(Store boston)
        {
            System.Console.WriteLine("Plants you have decided to purchase: ");
            for (int i = 0; i < boston.Cart.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + boston.Cart[i]);
            }
        }
        private static void printLancasterCart(Store lancaster)
        {
            System.Console.WriteLine("Plants you have decided to purchase: ");
            for (int i = 0; i < lancaster.Cart.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + lancaster.Cart[i]);
            }
        }

        private static void printBostonInventory(Store boston)
        {
            for (int i = 0; i < boston.PlantList.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + boston.PlantList[i]);
            }
        }
        private static void printLancasterInventory(Store lancaster)
        {
            for (int i = 0; i < lancaster.PlantList.Count; i++)
            {
                System.Console.WriteLine("Plant # " + i + " " + lancaster.PlantList[i]);
            }
        }
        static public int chooseActionBoston()
        {
            int choice = 0;
            System.Console.WriteLine("Choose an action (0) to quit (1) to add a new plant to the inventory (2) add plant to cart (3) checkout");

            choice = int.Parse(Console.ReadLine());
            return choice;


        }
        static public int chooseActionLancaster()
        {
            int choice = 0;
            System.Console.WriteLine("Choose an action (0) to quit (1) to add a new plant to the inventory (2) add plant to cart (3) checkout");

            choice = int.Parse(Console.ReadLine());
            return choice;


        }
        static public int chooseStoreLocation()
        {
            int choice = 0;
            System.Console.WriteLine("Choose a store (1) Boston (2) Lancaster (0) to exit");

            choice = int.Parse(Console.ReadLine());
            return choice;


        }
    }
}
