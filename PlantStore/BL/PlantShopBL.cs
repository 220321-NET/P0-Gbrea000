using DL;

namespace BL;
public class PlantShopBL  : IPSBL
{
    private readonly IRepository _repo;

    public PlantShopBL (IRepository repo)
    {
        _repo = repo;
    }

    public void CreateNewEmail(NewEmail newEmailToCreate)
    {
        StaticStorage.NewEmail.Add(newEmailToCreate); 
    }

    public List<NewEmail> GetNewEmails()
    {
        return new List<NewEmail>();
        // return _repo.NewEmail;
    }
    public void CreateInventory(Inventory inventoryToCreate)
    {
        _repo.CreateInventory(inventoryToCreate); 
    }

    public List<Inventory> GetInventory()
    {
        return _repo.GetAllInventory();
    }
}
