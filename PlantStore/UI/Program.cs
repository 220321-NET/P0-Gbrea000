using UI;
using BL;
using DL;


IRepository repo = new FileRepository ();
IPSBL bl = new PlantShopBL(repo);

new MainMenu(bl).Start(); 

