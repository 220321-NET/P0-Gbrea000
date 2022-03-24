namespace StoreFront;

public class StoreFrontMenu
{
    public void MainMenu()
    {
        Console.WriteLine("Welcome to PlantStore!");
        Console.WriteLine("Have you shopped with us before?");

        string? input = Console.ReadLine();

        Console.WriteLine("You wrote: " + input);
    }
}