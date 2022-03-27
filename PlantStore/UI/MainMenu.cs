using Models;
using System.ComponentModel.DataAnnotations;
using PSBL; 

namespace UI;

public class MainMenu 
{
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

        switch(input)
            {
            case "1":
                //prompt "Have you shopped with us before?" 
            break;

            case "2":
                //prompt new customer gathering info prompts
                CreateNewEmail();
                //DisplayNewEmail();
            break;

            case "3":
                //prompt please enter your email address so we can look up your order..
            break;

            case "x":
                Console.WriteLine( "Thank you for shopping with us!");
                exit = true;
            break;

            default:
                Console.WriteLine("Invalid response, please try again.");
            break;
            }
        } while(!exit);

    
        
    }

    private void CreateNewEmail()
    {
        EnterNewEmailData:
        Console.WriteLine("Joining our mailing list");
        Console.WriteLine("Please enter your email address.");
        string? title = Console.ReadLine();

        Console.WriteLine("Is this correct ");
        String? content = Console.ReadLine();

        NewEmail newemailToCreate = new NewEmail();
        try 
        {
            newemailToCreate.Title = title!;
            newemailToCreate.Content = content!;
        }
        catch(ValidationException ex)
        {
            Console.WriteLine(ex.Message);
            goto EnterNewEmailData;
        }

        new PSBL().CreateNewEmail(newemailToCreate); 
    }

    // private void DisplayNewEmail
    // {
    //     Console.WriteLine("Here are the plants in stock:");
    //     List <NewEmail> allNewEmail = new PSBL().GetNewEmails();

    //     foreach (NewEmail newemailToDisplay in allNewEmail)
    //     {
    //         Console.WriteLine($"Title: {newemailToDisplay.Title}, Content: {newemailToDisplay.Content}, 
    //         DateCreated: {newEmailToDisplay.DateCreated}, 
    //         Score: {newemailToDisplay.Score}");
        // }
    // }
}