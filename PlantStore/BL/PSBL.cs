using Models;
using DL;
namespace BL;
public class PlantShopBL  
{
    public void CreateNewEmail(NewEmail newEmailToCreate)
    {
        StaticStorage.NewEmail.Add(newEmailToCreate); 
    }

    public List<NewEmail> GetNewEmails()
    {
        return StaticStorage.NewEmail;
    }
     public void CreateInventory(Inventory InventoryToCreate)
    {
        StaticStorage.Inventory.Add(InventoryToCreate); 
    }

    public List<Inventory> GetInventory()
    {
        return StaticStorage.Inventory;
    }
}
