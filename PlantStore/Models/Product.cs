namespace Models;

public class Product 
{
    public int id { get; set; }
    public string name { get; set; }
    public double cost { get; set; }
    public void ChangePrice(float newPrice)
    {}
}