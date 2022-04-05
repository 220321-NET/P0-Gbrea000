// using System.Text.Json;

// namespace DL;

// public class FileRepository : IRepository
// {
//     private readonly string filePath = "//mac/Home/Desktop/P0-GBrea000/PlantStore/DL/PlantShop.json";
//     /// <summary>
//     /// Retrieves all Inventory from Plantshop.json
//     /// </summary>
//     /// <returns>List of Inventory if there is none, returns an empty list</returns>

//     public List<Inventory> GetAllInventory()
//     {
//         string jsonString = "";

//         try
//         {
//             jsonString = File.ReadAllText(filePath);
//         }
//         catch(Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         finally
//         {

//         }

//         List<Inventory> inventories = new List<Inventory>();
//         try{
//             inventories = JsonSerializer.Deserialize<List <Inventory>>(jsonString) ?? new List<Inventory>();
//         } 
//         catch (JsonException ex)
//         {
//             Console.WriteLine("There was an issue with the format of jsonString");
//         }

//         return inventories;
//     }
//     /// <summary>
//     /// Insert a new json inventory object to PlantShop.json
//     /// </summary>
//     /// <param name="inventoryToCreate">An inventory object to be inserted</param>

//     public void CreateInventory(Inventory inventoryToCreate)
//     {
//         if(inventoryToCreate == null) throw new ArgumentNullException();

//         List<Inventory> allInventory = GetAllInventory();

//         allInventory.Add(inventoryToCreate); 

//         string jsonString = JsonSerializer.Serialize(allInventory);

//         File.WriteAllText(filePath, jsonString);
//     }
// }

//Json is used to store cutomer emails/account.