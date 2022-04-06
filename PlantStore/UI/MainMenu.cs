using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using DL;

namespace UI;

public class MainMenu
{

    private readonly IPSBL _bl;

    public MainMenu(IPSBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        bool exit = false;
        do
        {
            Transition();
            Console.WriteLine("Welcome to PlantStore!");
            Console.WriteLine("[1] Sign in");
            Console.WriteLine("[2] Sign up");
            Console.WriteLine("[x] Exit");

        Input:
            String? response = Console.ReadLine();

            switch (response.Trim().ToUpper())
            {
                case "1":
                    Signin();
                    break;
                case "2":
                    Signup();
                    break;
                case "Admin":
                    Console.WriteLine("Welcome Admin");
                    break;
                case "X":
                    Console.WriteLine("Thank you for visiting PlantShop.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid response, please try again.");
                    goto Input;
            }

        } while (!exit);
    }

    public void Transition()
    {
        Console.WriteLine();
    }

    public void Signin()
    {
        Transition();

    EnterSignin:
        Console.WriteLine("Enter username:");
        string? userName = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string? password = Console.ReadLine();

        Customer signin = new Customer();

        try
        {
            signin.user = userName;
            signin.pass = password;
        }
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            goto EnterSignin;
        }
        int results = _bl.SigninCheck(signin);
        switch (results)
        {
            case 1:
            Signin1:
                Console.WriteLine("Unable to find an account with this username. \n Would you like to try again? [Y/N]");
                string? responseSignin1 = Console.ReadLine();
                if (responseSignin1.Trim().ToUpper()[0] == 'Y')
                    goto EnterSignin;
                else if (responseSignin1.Trim().ToUpper()[0] == 'N')
                    break;
                else
                {
                    Console.WriteLine("Invalid entry");
                    goto Signin1;
                }
            case 2:
            Signin2:
                Console.WriteLine("Unable to find an account with this password. \n Would you like to try again? [Y/N]");
                string? responseSignin2 = Console.ReadLine();
                if (responseSignin2.Trim().ToUpper()[0] == 'Y')
                    goto EnterSignin;
                else if (responseSignin2.Trim().ToUpper()[0] == 'N')
                    break;
                else
                {
                    Console.WriteLine("Invalid entry");
                    goto Signin2;
                }
            case 3:
            Signin3:
                Console.WriteLine("You have been signed in.");
                CustomerMenu(_bl.GetCustomer(signin));
                break;
        }

    }
    public void CustomerMenu(Customer current)
    {
        bool customerExit = false;
        do
        {
        CustomerMenuInput:
            Transition();
            // Console.WriteLine($"Welcome {current.user}.");
            Console.WriteLine("Welcome to Plant Shop!");
            Console.WriteLine("[1] Buy Plants");
            Console.WriteLine("[2] See Cart");
            Console.WriteLine("[3] View Past Order");
            Console.WriteLine("[x] Exit");
            string? cmResponse = Console.ReadLine();

            switch (cmResponse.Trim().ToUpper()[0])
            {
                case '1':
                    PlantStore(current);
                    break;

                case '2':
                    break;

                case '3':
                    break;

                case 'X':
                    customerExit = true;
                    break;

                default:
                    Console.WriteLine("Invalid response, please try again.");
                    goto CustomerMenuInput;
            }

        } while (!customerExit);
    }

    public void Signup()
    {
        Transition();
        Console.WriteLine("Let's set up your account");

    EnterCustomerInfo:
        Console.WriteLine("Please type in a username:");
        string? username = Console.ReadLine();

        Console.WriteLine("Please type in a password:");
        string? password = Console.ReadLine();

        Customer newcustomer = new Customer();

        try
        {
            newcustomer.user = username;
            newcustomer.pass = password;
        }

        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            goto EnterCustomerInfo;
        }

        Customer createdCustomer = _bl.CreateCustomer(newcustomer);
        if (createdCustomer != null)
            Console.WriteLine("Account has been created.");
    }
    public void AddToCart(Customer current, Store shopAt, Product shopPro, Order currentOrder, int count)
    {
        if (count == 0)
        {
            currentOrder.CustID = current.Id;
            currentOrder.StoreID = shopAt.ID;
        }

        currentOrder.AddCartItems(shopPro);


    }

    public void CheckOut(Order currentOrder)
    {
        currentOrder.DateCreated = DateTime.Now;
        if (_bl.UpdateOrders(currentOrder) == null) ;
        Console.WriteLine("Order Placed!!!");
    }
    public void PlantStore(Customer current)
    {
        Order currentOrder = new Order();
        int count = 0;
        Transition();
        Console.WriteLine("Which location would you like to buy from?");
    ContinueShopping:
        Store shopAt = SelectStore();

        if (shopAt == null)
        {
            Console.WriteLine("shopAt is null");
        }

        Console.WriteLine("Please select a plant to purchase.");
        Product shopPlant = SelectInventory(shopAt);
        if (shopPlant == null || shopPlant.productName.Length == 0){
            Console.WriteLine("No plants");
        }

        Transition();

    shopConfirm:
        Console.WriteLine($"You've selected \n{shopPlant.productName} (Y/N");
        string shopInput = Console.ReadLine();

        switch (shopInput.Trim().ToUpper()[0])
        {
            case 'Y':
                AddToCart(shopPlant);
                break;
            case 'N':
                Console.WriteLine("Plant has not been added to cart");
                break;
            default:
                Console.WriteLine("Invalid input, Try again");
                goto shopConfirm;
                return;
        }
    }

    private void AddToCart(Product shopPlant)
    {
        throw new NotImplementedException();
    }



    // public void Admin()
    // {
    //     Transition();
    //     Console.WriteLine("Main Menu");
    //     Console.WriteLine("[1]Update Product");
    //     Console.WriteLine("[2]View Inventory");
    //     Console.WriteLine("[x]Exit Admin");

    // Input:
    //     String? response = Console.ReadLine();
    //     switch (response.Trim().ToUpper())
    //     {
    //         case "1":
    //             ReplenishStock();
    //             break;

    //         case "2":
    //             ViewInventory();
    //             break;

    //         case "x":
    //             adminExit = true;
    //             break;

    //         default:
    //             Console.WriteLine("Invalid response, please try again.");
    //             goto Input;

    //     }
    //     while (!adminExit) ;

    public Store? SelectStore()
    {
        Console.WriteLine("PlantStore is in two cities: ");
        List<Store> allStores = _bl.GetStores();

        if (allStores == null || allStores.Count == 0)
            return null;

        SelectInput:
        for (int i = 0; i < allStores.Count; i++)
            Console.WriteLine(allStores[i].ToString());

        int select;

        if (Int32.TryParse(Console.ReadLine(), out select) && ((select - 1) >= 0 && (select - 1) < allStores.Count))
            return allStores[select - 1];
        else
        {
            Console.WriteLine("Invalid input, Try again");
            goto SelectInput;
        }
    }

    public void AddProduct()
    {
        Transition();

    EnterProductInfo:
        Console.WriteLine("What plant would you like to add?");
        string? plantName = Console.ReadLine();

        Console.WriteLine("How much is it?");
        double? plantPrice = Convert.ToDouble(Console.ReadLine());

        Product newPlant = new Product();

        try
        {
            newPlant.productName = plantName;
            newPlant.cost = plantPrice.Value;
        }
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            goto EnterProductInfo;
        }
        //Product createdProduct = _bl.CreateProduct(newPlant);
        //if (createdProduct != null)
        //    Console.WriteLine("/n New plant added to inventory.");
    }
    // public Store? SelectStore()
    // {
    //     Console.WriteLine("Here are all the stores by state: ");
    //     List<Store> allStores = _bl.GetStores();

    //     if (allStores.Count == 0)
    //         return null;

    //     SelectInput:
    //     for (int i = 0; i < allStores.Count; i++)
    //         Console.WriteLine(allStores[i].ToString());

    //     int select;

    //     if (Int32.TryParse(Console.ReadLine(), out select) && ((select - 1) >= 0 && (select - 1) < allStores.Count))
    //         return allStores[select - 1];
    //     else
    //     {
    //         Console.WriteLine("Invalid input, Try again");
    //         goto SelectInput;
    //     }
    // }

    public Product SelectInventory(Store getInv)
    {
        Transition();
        Console.WriteLine($"Here is the Inventory for the {getInv.StoreLocation} store:");
        List<Product> inventory = new List<Product>();
        try
        {
            inventory = _bl.GetInventory(getInv);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (inventory.Count == 0)
            return null;

        InvInput:
        for (int i = 0; i < inventory.Count; i++)
            Console.WriteLine(inventory[i].ToString());

        int proSelect;

        if (Int32.TryParse(Console.ReadLine(), out proSelect) && ((proSelect - 1) >= 0 && (proSelect - 1) < inventory.Count))
            return inventory[proSelect - 1];
        else
        {
            Console.WriteLine("Invalid input, Try again");
            goto InvInput;
        }
    }

    public void addProduct()
    {
        Transition();

    EnterProductInfo:
        Console.WriteLine("What is the name of the game you would like to add?");
        string? proName = Console.ReadLine();

        Console.WriteLine("What is the price?");
        double? proPrice = Convert.ToDouble(Console.ReadLine());

        Product newPro = new Product();

        try
        {
            newPro.productName = proName;
            newPro.Price = proPrice.Value;
        }
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);
            goto EnterProductInfo;
        }

        Product createdProduct = _bl.CreateProduct(newPro);
        if (createdProduct != null)
            Console.WriteLine("\nProduct created successfully");
    }

    public void ReplenishStock()
    {
        Transition();
        Console.WriteLine("Please choose a location to replenish stocks at");
        Store? replenishStore = SelectStore();

        Product? replenishPro = SelectInventory(replenishStore);

        Console.WriteLine($"Please enter the new quantity of {replenishPro.productName}");
        int newQuan = Convert.ToInt32(Console.ReadLine());
    }
    public void ViewInventory()
    {
        Transition();
        Console.WriteLine("Which store would you like to view the inventory for?");
        Store? viewStore = SelectStore();

        Console.WriteLine($"Here is the Inventory for the {viewStore.StoreLocation} store:");
        List<Product> inventory = _bl.GetInventory(viewStore);

        if (inventory.Count == 0)
        {
            Console.WriteLine("This store has no inventory");
            return;
        }
        for (int i = 0; i < inventory.Count; i++)
            Console.WriteLine(inventory[i].ToString());

        Console.WriteLine("Press any key to continue");
        string temp = Console.ReadLine();

    }
}


