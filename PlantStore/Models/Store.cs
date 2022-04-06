using System.ComponentModel.DataAnnotations;
using DL;
namespace Models;

public class Store //: Default
{
    private string location = "";
    public string StoreLocation
    {
        get => location;
        set{
            if(String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Name cannot be empty");

            location = value.Trim();
        }
    }
    public override string ToString()
    {
        return $" {location} ";
    }
    public int ID { get; set; }
    public List<Product> Inventory {get; set; }
    public string city {get; set; }
}


// public class Store
// {
//     public int Id { get; set; }
//     public string City { get; set; }
//     private List<Order> OrderHistory;
//     public List<Product> Inventory;
//     public void DisplayStock()
//     {
//         foreach (Product product in Inventory)
//         {
//             Console.WriteLine($"{product.Name} | ${product.Price} | {product.Quantity}");
//         }
//     }
// }