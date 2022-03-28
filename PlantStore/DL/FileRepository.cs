using System.Text.Json;
using Models;

namespace DL;

public class FileRepository
{
    private readonly string filePath = "../DL/PlantShop.json";

    public List<Inventory> GetAllInventory()
    {
        string jsonString = "";

        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {

        }

        List<Inventory> inventories = new List<Inventory>();
        try{
            inventories = JsonSerializer.Deserialize<List <Inventory>>(jsonString) ?? new List<Inventory();
        } 
        catch (JsonException ex)
        {
            Console.WriteLine("There was an issue with the format of jsonString");
        }

        return inventories;
        {

        }
    }

    public void CreateInventory(Inventory inventoryToCreate)
    {
        if(inventoryToCreate == null) throw new ArgumentNullException();

        List<Inventory> allInventory = GetAllInventory();

        allInventory.Add(inventoryToCreate); 

        string jsonString = JsonSerializer.Serialize(allInventory);

        File.WriteAllText(filePath, jsonString);
    }
}

//Json is used to store cutomer emails/account.