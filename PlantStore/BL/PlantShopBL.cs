// using DL;
// using Models;

// namespace BL;
// public class PlantShopBL  
// {
//     private readonly DBRepository _repo;

//     public PlantShopBL (DBRepository repo)
//     {
//         _repo = repo;
//     }

//     public List<Customer> GetAllCustomers()
//     {
//         return _repo.GetAllCustomers();
//     }

//     public Customer AddCustomer(Customer customerToAdd)
//     {
//         return _repo.CreateCustomer(customerToAdd);
//     }

//     public List<Store> GetAllStores()
//     {
//         return _repo.GetAllStores();
//     }
//     public Store GetStoreInventory(StackOverflowException currentStore)
//     {
//         return _repo.GetStoreInventory(currentStore);
//     }

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
}
