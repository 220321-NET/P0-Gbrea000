using Models;
using System.ComponentModel.DataAnnotations;
using BL;
using DL;

namespace UI;

public class MainMenu
{

    private readonly PlantShopBL _bl;

    public MainMenu(PlantShopBL bl)
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
                case "":
                    Signup();
                    break;
                case "Admin":
                    Console.WriteLine("Welcome Admin");
                    break;
                case "x":
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
        Console.WriteLine("/n***********************************/n");
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
        int results = _bl.SigninCheck(Signin);
        switch (results)
        {
            case 1:
            Signin1:
                Console.WriteLine("Unable to find an account with this username. \n Would you like to try again? [y/n]");
                string? responseSignin1 = Console.ReadLine();
                if (responseSignin1.Trim().ToUpper()[0] == 'y')
                    goto EnterSignin;
                else if (responseSignin1.Trim().ToUpper()[0] == 'n')
                    break;
                else
                {
                    Console.WriteLine("Invalid entry");
                    goto Signin1;
                }
            case 2:
            Signin2:
                Console.WriteLine("Unable to find an account with this password. \n Would you like to try again? [y/n]");
                string? responseSignin1 = Console.ReadLine();
                if (responseSignin1.Trim().ToUpper()[0] == 'y')
                    goto EnterSignin;
                else if (responseSignin1.Trim().ToUpper()[0] == 'n')
                    break;
                else
                {
                    Console.WriteLine("Invalid entry");
                    goto Signin2;
                }
            case 3:
            Signin3:
                Console.WriteLine("You have been signed in.");
                CustomerMenu(signin);
                break;
        }

    }
    public void CustomerMenu(Customer current)
    {
        Transition();
        Console.WriteLine($"Welcome {current.user}.");
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

        Customer createdCustomer = _b1.createCustomer(newcustomer);
        if (createCustomer != null)
            Console.WriteLine("\nAccount has been created.");
    }

    public void Admin()
    {
        Transition();
        Console.WriteLine("Main Menu");
        Console.WriteLine("[1]Update Product");
        Console.WriteLine("[2]View Inventory");
        Console.WriteLine("[x]Exit Admin");

    Input:
        String? response = Console.ReadLine();
        switch (response.Trim().ToUpper())
        {
            case "1":
                break;

            case "2":
                break;

            case "x":
                break;

            default:
                Console.WriteLine("Invalid response, please try again.");
                goto Input;

        }
    }
}
//     public void StoreMenu()
//     {
//         Console.WriteLine("Welcome to PlantStore!");

//     SigninRegister:
//         Console.WriteLine("[1] Sign in");
//         Console.WriteLine("[2] Sign up");
//         Console.WriteLine("[x] Exit");

//         string? answer = Console.ReadLine().Trim() ?? "";
//         bool isSignedIn = false;

//         if (answer == "1")
//         {
//             isSignedIn = Signin();
//         }
//         else if (answer == "2")
//         {
//             isSignedIn = Signup();
//         }
//         else if (answer.ToLower() == "x")
//         {
//             return;
//         }
//         else
//         {
//             Console.WriteLine("Invalid Input");
//             goto SigninRegister;
//         }
//         if (!isSignedIn)
//         {
//             return;
//         }

//         Store currentStore = new Store();
//         List<Store> stores = _bl.GetAllStores();

//     StoreLocation:
//         Console.WriteLine("Which PlantStore would you like to shop in?");
//         int i = 1;
//         foreach (Store store in stores)
//         {
//             Console.WriteLine($"[{i}] {store.Name} | {store.City}");
//             i++;
//         }

//         string? storeAnswer = Console.ReadLine().Trim() ?? "";

//         if (storeAnswer == "1")
//         {
//             currentStore = stores[0];
//         }
//         else if (storeAnswer == "2")
//         {
//             currentStore = Store[1];
//         }
//         else
//         {
//             Console.WriteLine("Invalid Input");
//             goto StoreLocation;
//         }
//         string result = Main(currentStore);

//         if (result == "6")
//         {
//             goto StoreLocation;
//         }
//     }
//     private string Menu(Store currentStore)
//     {
//     MenuChoices:

//         Console.WriteLine("[1] See plants");
//         Console.WriteLine("[2] Add plant(s) to cart");
//         Console.WriteLine("[3] Remove plant(s) from cart");
//         Console.WriteLine("[4] Show plant(s) in cart");
//         Console.WriteLine("[5] Checkout");
//         Console.WriteLine("[6] Change location");
//         Console.WriteLine("[x] Sign Out");

//         string? choice = Console.ReadLine().Trim() ?? "";

//         switch (choice)
//         {
//             case "1":
//                 Inventory(currentStore);
//                 break;
//             case "2":
//                 //
//                 break;
//             case "3":
//                 //
//                 break;
//             case "4":
//                 //
//                 break;
//             case "5":
//                 //
//                 break;
//             case "6":
//                 return choice;
//                 break;
//             case "x":
//                 Console.WriteLine("Thank you for shopping with us!");
//                 break;
//             default:
//                 Console.WriteLine("Please enter a valid response");
//                 goto MenuChoices;
//         }

//         goto MenuChoices;
//     }

//     private bool Signin()
//     {
//     Signin:
//         Console.WriteLine("Please enter Username:");
//         string? userName = Console.ReadLine().Trim() ?? "";

//         List<Customer> customers = _bl.GetAllCustomers();

//         foreach (Customer customer in customers)
//         {
//             if (customer.Username == userName)
//             {
//             Password:
//                 Console.WriteLine("Enter your Password:");
//                 string? password = Console.ReadLine().Trim() ?? "";

//                 if (userName.Password == password)
//                 {
//                     return true;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Wrong password, would you like to try again? [Y/N]?");
//                     string? innerResponse = Console.ReadLine().Trim().ToUpper() ?? "";

//                     if (innerResponse == "Y")
//                     {
//                         goto Password;
//                     }
//                 }
//             }
//         }
//         Console.WriteLine("Unable to find an account with this username. \n Would you like to try again or sign up? /n [1] Try Again/n[2] Sign Up)";
//         string? outerResponse = Console.ReadLine().Trim() ?? "";

//         if (outerResponse == "1")
//         {
//             goto Signin;
//         }
//         else if (outerResponse == "2")
//         {
//             bool isSignedIn = Signin();
//             return isSignedIn;
//         }

//         return false;
//     }
//     public bool Signup()
//     {
//     Signup:
//         Console.WriteLine("Please Enter Username:");
//         string? userName = Console.ReadLine().Trim() ?? "";

//         List<Customer> users = _bl.GetAllCustomers();

//         foreach (Customer customer in customers)
//         {
//             if (customer.Username == userName)
//             {
//                 Console.WriteLine("That username is already taken!\nTry another?[Y/N]");
//                 string? response = Console.ReadLine().Trim().ToUpper() ?? "";

//                 if (response == "N")
//                 {
//                     return false;
//                 }
//                 goto Signup;
//             }
//         }
//         Console.WriteLine("Enter Password");
//         string? password = Console.ReadLine().Trim() ?? "";

//         Customer newCustomer = new Customer();
//         newCustomer.Username = userName;
//         newCustomer.Password = password;

//         _bl.AddCustomer(newCustomer);
//         return true;
//     }
//     private void Checkout()
//     {

//     }
//     private void DisplayCart()
//     {

//     }
//     private void Inventory(Store currentStore)
//     {
//         currentStore = _bl.GetStoreInventory(currentStore);
//         int i =1;

//         foreach (Product item in currentStore.Inventory)
//         {
//             Console.WriteLine($"[{i}] ${item.Price} | {item.Name} | {item.Quantity} QTY.n{item.Description}");
//             i++;
//         }
//     }
// }