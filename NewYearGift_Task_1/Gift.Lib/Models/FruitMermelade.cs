namespace Gift
{
    public class FruitMermelade : Marmalade
    {
        public FruitType FruitType { get; set; }
        public FruitMermelade(string name, double weight,double sugarWeight,double price,MarmeladeTaste marmeladeTaste,FruitType fruitType) : base(name,weight,sugarWeight,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            MarmeladeTaste = marmeladeTaste;
            FruitType = fruitType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nFruitType: {FruitType}";
        }
    }
}