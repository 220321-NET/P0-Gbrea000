using System.ComponentModel.DataAnnotations;

namespace Models; 

public class Inventory : TextEntry
{ 
    private string title = "";
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
    public bool IsClosed { get; set; }
    
    public List<InventoryList> InventoryList { get; set; }

    public override string ToString()
        {
         return $"Title: {title}  \nContent: {Content} \nScore: {Score}";
        }

}        

