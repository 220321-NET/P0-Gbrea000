namespace Models;

public class Store
{
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