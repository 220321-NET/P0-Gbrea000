namespace StoreFront;

public class StoreFrontMenu
{
    public void MainMenu()
    {
        Console.WriteLine("Welcome to PlantStore!");
        Console.WriteLine("Have you shopped with us before?");
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

        //Merchandise newMerchandise = new Merchandise();
       // newMerchandise.Title = title;
       // newMerchandise.Content = content;
        //newMerchandise.Likes = 0; 

        Merchandise createdMerchandise = new Merchandise(title, content);

        Console.WriteLine("You entered " +createdMerchandise.ToString());
        


    }
}