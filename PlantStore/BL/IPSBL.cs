namespace BL;

public interface IPSBL
{
    void CreateNewEmail(NewEmail newEmailToCreate);
    
    public List<NewEmail> GetNewEmails();

    void CreateInventory(Inventory inventoryToCreate);
    
    public List<Inventory> GetInventory();
} 