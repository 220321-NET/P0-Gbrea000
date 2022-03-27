using System.ComponentModel.DataAnnotations;

namespace Models; 

public class NewEmail : TextEntry
{ 
    private string title;

    public string Title 
    { 
        get => title; 
    
        set 
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("title cannot be empty"); 
            }
            title = value;
        }
    }
}

