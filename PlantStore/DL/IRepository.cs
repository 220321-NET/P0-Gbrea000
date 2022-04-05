using Models;
namespace DL;
public interface IRepository
{
    Customer CreateCustomer(Customer newCustomer);
    int SigninCheck (Customer login);
    Customer GetCustomer(Customer customer);
}


// namespace DL;

// /// <summary>
// /// Interface for accessing data in PlantShop
// /// </summary>

// public interface IRepository
// {
//     /// <summary>
//     /// adds a new inventory
//     /// </summary>
//     /// <param name="inventoryToCreate">Inventory object to be inserted</param>
//     void CreateInventory(Inventory inventoryToCreate);

//     /// <summary>
//     /// Retrieves all inventory 
//     /// </summary>
//     /// <returns>List of inventory, if empty, returns an empty list</returns>

//     List<Inventory> GetAllInventory();
// }