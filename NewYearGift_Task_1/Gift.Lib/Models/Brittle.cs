namespace Gift.lib.Models
{
    public class Brittle : Candy //грильяж 
    {
        public NutType NutType { get; set; }
        
        public Brittle(string name, double weight,double sugarWeight,double price,Filing filing,NutType nutType) : base(name,weight,sugarWeight,price,filing)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            Filing = filing;
            NutType = nutType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFilling {Filing}\nNutType: {NutType}\n";
        }
    }
}