using Models;
using DL;
namespace BL;

public interface IPSBL
{
    Product GetProduct(int id);
    List<Product> GetInventory(Store getInventory);

    List<Store> GetStores();
    Customer CreateCustomer(Customer newCustomer);
    int SigninCheck(Customer Signin);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newPlant);
    Order UpdateOrders(Order updateOrder);
}