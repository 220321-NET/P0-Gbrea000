
// namespace Models;

// public class Product 
// {
//     public int id { get; set; }
//     public string name { get; set; }
//     public double cost { get; set; }
//     public void ChangePrice(float newPrice)
//     {}

// }
using System.ComponentModel.DataAnnotations;
using System.Data;
using Models;
namespace DL; 

public class Product 
{
    public int id;
    public double cost;
    private string itemName = "";
    private double price = 0.00f;
    public string productName
    {
        get => itemName;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ValidationException("Name cannot be empty");
            itemName = value.Trim();
        }
    }
    public double Price
    {
        get => price;
        set
        {
            if (value <= 0.00)
                throw new ValidationException("Price must be greater than zero");
            price = value;
        }
    }

}
