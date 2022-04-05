using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models;

public class Customer : Default
{
    private string username = "";
    private string password = "";

    public string user
    {
        get => username;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Username cannot be empty");
            username = value;
        }
    }
    public string pass
    {
        get => password;
        set
        {
            if(String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Password cannot be empty");
            password = value;
        }
    }
    public List<Order> OrderHistory {get; set; } = new List<Order>();
}


// namespace Models;
// public class Customer 
// {
//     public int Id{ get; set; }
//     public string Username { get; set; }
//     public string Password { get; set; }
//     private List<Product> Cart { get; set; }
// }