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
     public void CreateInventory(Inventory inventoryToCreate)
    {
        new FileRepository().CreateInventory(inventoryToCreate); 
    }

    public List<Inventory> GetInventory()
    {
        return new FileRepository().GetAllInventory();
    }
}
