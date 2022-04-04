namespace DL;
public static class StaticStorage
{
    public static List<NewEmail> NewEmail { get; set; } = new List<NewEmail>(); 
    public static List<Inventory> Inventory { get; set; } = new List<Inventory>() 
    {
        new Inventory {
            Title = "Monstera",
            Content = "A species of evergreen tropical vines and shrubs that are native to Central America."
        },
        new Inventory {
            Title = "Begonia",
            Content = "A genus of perennial flowering plants."
        },
        new Inventory {
            Title = "Alocasia",
            Content = " A genus of broad-leaved perennial flowering plants from the family Araceae (otherwise known as the aroids)."
        },
        new Inventory {
            Title = "Pothos",
            Content = "An evergreen hanging plant with thick, waxy, green, heart-shaped leaves with splashes of yellow."
        },
         new Inventory {
            Title = "Dracaena",
            Content = "Are tropical trees and shrubs that thrive in low to bright light."
        },
    };
}

