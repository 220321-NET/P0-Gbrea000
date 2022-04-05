namespace Models;

public class Cart
{
    public List<Product> products {get; set; }
}
// {
//     private List<Product> Products { get; set; } = new List<Product>();

//     private double TotalCost { get; set; } = 0.00;

//     public void AddProduct(Product item)
//     {
//         Products.Remove(item);
//         TotalCost += item.Price;
//     }

//     public void RemoveProduct(Product item)
//     {
//         Products.Remove(item);
//         TotalCost -= item.Price;
        
//     }
// }