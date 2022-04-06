using DL;
namespace Models;

public class Cart
{
    public Product item {get; set; } = new Product();

    public int cartQuan {get; set; }
}

// public class Cart
// {
//     public Product item { get; set; } = new Product();

//     public int cartQuan { get; set; }
// }

// private List<Product> Products { get; set; } = new List<Product>();

// private double TotalCost { get; set; } = 0.00;

// public void AddProduct(Product item)
// {
//     Products.Remove(item);
//     TotalCost += item.Price;
// }

// public void RemoveProduct(Product item)
// {
//     Products.Remove(item);
//     TotalCost -= item.Price;

// }
