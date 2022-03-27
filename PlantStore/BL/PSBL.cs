using Models;
using DL;
namespace BL;
public class PSBL
{
    public void CreateNewEmail(NewEmail newEmailToCreate)
    {
        StaticStorage.NewEmail.Add(newEmailToCreate); 
    }

    public List<NewEmail> GetNewEmails()
    {
        return StaticStorage.NewEmail;
    }
}
