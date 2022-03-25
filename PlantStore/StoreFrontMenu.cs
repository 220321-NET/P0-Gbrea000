namespace StoreFront;

public class StoreFrontMenu
{
    public void MainMenu()
    {
        List<Merchandise> merchandise = new List<Merchandise>();
        

        Console.WriteLine("Welcome to PlantStore!");
        Console.WriteLine("Have you shopped with us before?");

        bool exit = false;
        do
        {
            EnterTitle:
        string title = Console.ReadLine () ?? "";
        if (String.IsNullOrWhiteSpace(title)) {
                Console.WriteLine("Your title cannot be empty");
                goto EnterTitle;
        }

        EnterBody:
        Console.WriteLine("Tell us which plant you're interested in?");
        string content = Console.ReadLine() ?? "";

        if(String.IsNullOrWhiteSpace(content)) {
            Console.WriteLine("You can't have your body empty"); 
            goto EnterBody;
        }

        Merchandise createdMerchandise = new Merchandise(title, content);
        merchandise.Add(createdMerchandise);
        
        for (int i = 0; i < merchandise.Count; i++)
        {
            Console.WriteLine(merchandise[i]);
        }

        Another:
        Console.WriteLine("Would you like to buy another plant? [Y/N]");
        string enterAnother = Console.ReadLine() ?? "";
        if (String.IsNullOrWhiteSpace(enterAnother))
        {
            Console.WriteLine("Please enter valid input.");
            goto Another;
        }
        char responseChar = enterAnother.Trim().ToUpper()[0];

        if(responseChar == 'N')
        {
            Console.WriteLine("Thank you for shopping with us!");
            exit = true;
        }
        else if(responseChar !='Y')
        {
            Console.WriteLine("Please respond with valid response.");
            goto Another;
        }
        }while (!exit);
        


    }
}