using UI;
using BL;
using DL;


String connectionString = File.ReadAllText("Server=tcp:psserver.database.windows.net,1433;Initial Catalog=PlantShopDB;Persist Security Info=False;User ID=psadmin;Password={P0-GBrea000};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

IRepository repo = new DBRepository (connectionString);

IPSBL = new PlantShopBL(repo);

new MainMenu(bl).Start(); 

