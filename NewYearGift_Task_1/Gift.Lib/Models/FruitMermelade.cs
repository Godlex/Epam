namespace Gift
{
    public class FruitMermelade : Marmalade
    {
        public FruitType FruitType { get; set; }
        public FruitMermelade(string name, double weight,double caloric,double price,MarmeladeTaste marmeladeTaste,FruitType fruitType) : base(name,weight,caloric,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            MarmeladeTaste = marmeladeTaste;
            FruitType = fruitType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nFruitType: {FruitType}";
        }
    }
}