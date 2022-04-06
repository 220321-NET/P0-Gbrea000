using DL;
using Models;
namespace BL;


public class PlantShopBL : IPSBL
{
    private readonly IRepository _repo;
    public PlantShopBL(IRepository repo)
    {
        _repo = repo;
    }
    public Customer CreateCustomer(Customer newCustomer)
    {
        return _repo.CreateCustomer(newCustomer);
    }
    public int SigninCheck(Customer login)
    {
        return _repo.SigninCheck(login);
    }
    public Customer GetCustomer(Customer customer)
    {
        return _repo.GetCustomer(customer);
    }
    public Product CreateProduct(Product newPlant)
    {
        return _repo.CreateProduct(newPlant);
    }

    public Product GetProduct(int id)
    {
        return _repo.GetProduct(id);
    }

    public List<Product> GetInventory(Store getInventory)
    {
        return _repo.GetInventory(getInventory);
    }

    public List<Store> GetStores()
    {
        return _repo.GetStores();
    }

    public Order UpdateOrders(Order updateOrder)
    {
        throw new NotImplementedException();
    }
}
