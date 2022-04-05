using UI;
using BL;
using DL;


String connectionString = File.ReadAllText("connectionString.txt");
IRepository repo = new DBRepository (connectionString);

IPSBL bl = new PlantShopBL(repo);

new MainMenu(bl).Start(); 

