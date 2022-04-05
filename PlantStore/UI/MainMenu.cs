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
                string? responseSignin2 = Console.ReadLine();
                if (responseSignin2.Trim().ToUpper()[0] == 'y')
                    goto EnterSignin;
                else if (responseSignin2.Trim().ToUpper()[0] == 'n')
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
