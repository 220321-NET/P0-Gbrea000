namespace Models
{
    public class Plant
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Plant()
        {
            Name = "nothing yet";
            Price = 0.00M;
        }
        public Plant(string a, decimal c)
        {
            Name = a;
            Price = c;
        }

        override public string ToString()
        {
            return "Name: " + Name + " Price: $" + Price;
        }
    }
}
