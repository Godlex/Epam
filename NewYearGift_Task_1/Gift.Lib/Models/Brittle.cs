namespace Gift
{
    public class Brittle : Candy //грильяж 
    {
        public NutType NutType { get; set; }
        
        public Brittle(string name, double weight,double caloric,double price,Filing filing,NutType nutType) : base(name,weight,caloric,price,filing)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            Filing = filing;
            NutType = nutType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nFilling {Filing}\nNutType: {NutType}\n";
        }
    }
}