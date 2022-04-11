namespace UI
{
    //main class
    class StoreFront
    {
        //greeting method
        GreetUser();
    }
    static void GreetUser()
    {
        //greet user and ask if they've shopped here before
        Console.WriteLine("Welcome to PlantShop");
        Console.WriteLine("Have you been here before?[Y/N]");
        //get answer
        string answer = Console.ReadLine().ToUpper();

        if (answer == "Y")
        {
            SignIn();
        }
        else if (answer == "N")
        {
            SignUp();
        }
        else
        {
            return;
        }

    }
    static void SignIn()
    {
        //ask for user name
        Console.WriteLine("What is your username?");
        string userName = Console.ReadLine();

        //ask for password
        Console.WriteLine("What is your password?");
        string password = Console.ReadLine();

        //verify userName and Password to sign in user
        //if can't verify user ask to try again [y/n]
        //if y take to signin
        //if n take to signup

        //greet returning user
        Console.WriteLine("Welcome back ", userName);

        //take to MainMenu
    }

    static void SignUp()
    {
        //ask user to create username
        Console.WriteLine("What would you like your username to be?");
        string userName = Console.ReadLine();

        //make sure username is unique

        //ask user to create password
        Console.WriteLine("What would you like your password to be?");
        string password = Console.ReadLine();

        //create new user in db
        //confirm user creation
        Console.WriteLine("Your account has been created.");

        //take to MainMenu
    }
    static void MainMenu()
    {
        Console.WriteLine("Welcome to Plant Shop!");
        Console.WriteLine("[1] Buy Plants");
        Console.WriteLine("[2] See Cart");
        Console.WriteLine("[3] View Past Order");
        Console.WriteLine("[x] Exit");
    }
}