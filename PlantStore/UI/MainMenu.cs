using Models;
using System.ComponentModel.DataAnnotations;
using BL;

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
            Console.WriteLine("Welcome to PlantStore!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Buy plants.");
            Console.WriteLine("[2] Join our mailing list.");
            Console.WriteLine("[3] Inquire about a past purchase.");
            Console.WriteLine("[x] Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //prompt "Have you shopped with us before?"
                    DisplayAllInventory();
                    SearchInventory();
                    SelectInventory();

                    break;

                case "2":
                    //prompt new customer gathering info prompts
                    CreateNewEmail();
                    break;

                case "3":
                    //prompt please enter your email address so we can look up your order..
                    //SearchEmails();
                    /**List<Customer>allCustomer = /thiswould have list of populated customers/
                    *string name = Console.ReadLine();
                   *allCustomer.Find(char =>.Name == name)
                   */
                    break;

                case "x":
                    Console.WriteLine("Thank you for shopping with us!");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid response, please try again.");
                    break;
            }
        } while (!exit);

    }

    private void CreateNewEmail()
    {
    EnterNewEmailData:
        Console.WriteLine("To join our mailing list");
        Console.WriteLine("please enter your email address.");
        string? title = Console.ReadLine();

        Console.WriteLine("Is this correct ");
        String? content = Console.ReadLine();

        NewEmail newemailToCreate = new NewEmail();
        try
        {
            newemailToCreate.Title = title!;
            newemailToCreate.Content = content!;
        }
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterNewEmailData;
        }

        _bl.CreateNewEmail(newemailToCreate);
    }
    private void CreateInventory()
    {
    EnterInventoryData:
        Console.WriteLine("Have you shopped with us before?");
        Console.WriteLine("If yes please enter your email address, if no you will be redirected to create a new account.");
        string? title = Console.ReadLine();

        Console.WriteLine("Is this correct ");
        String? content = Console.ReadLine();

        Inventory inventoryToCreate = new Inventory();
        try
        {
            inventoryToCreate.Title = title!;
            inventoryToCreate.Content = content!;
        }
        catch (ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterInventoryData;
        }
        finally
        {
            //clean up outside resource
        }

        _bl.CreateInventory(inventoryToCreate);
    }
    private void DisplayAllInventory()
    {
        Console.WriteLine("Here are the plants in stock:");
        List<Inventory> allInventory = _bl.GetInventory();

        foreach (Inventory InventoryToDisplay in allInventory)
        {
            Console.WriteLine(InventoryToDisplay);
        }
    }
    private Inventory? SelectInventory()
    {
        selectInventory:
        Console.WriteLine("Select a plant.");
        List<Inventory> allInventory = _bl.GetInventory();
        if (allInventory.Count == 0)
        {
            Console.WriteLine("No selection has been made.");
            return null;
        }
        for (int i = 0; i < allInventory.Count; i++)
        {
            Console.WriteLine($"[{i}] {allInventory[i]}");
        }
            int selection; 
        if (Int32.TryParse(Console.ReadLine(), out selection) && (selection >= 0 && selection < allInventory.Count))
        {
            Console.WriteLine(allInventory[selection]);
            return allInventory[selection];
        }

        else
        {
            Console.WriteLine("Please enter a valid response");
            goto selectInventory;
        }


    }
    private List<Inventory> SearchInventory()
    {
        Console.WriteLine("Enter keywords to search plants.");
        string input = Console.ReadLine()!.ToLower();

        List<Inventory> allInventory = _bl.GetInventory();
        List<Inventory> foundInventory = allInventory.FindAll(inventory => inventory.Title.Contains
        (input) && inventory.Content.Contains(input));
        foreach (Inventory inventory in foundInventory)
        {
            Console.WriteLine(inventory);
        }
        return foundInventory;
    }
}