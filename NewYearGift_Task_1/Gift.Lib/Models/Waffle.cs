using System.Text;

namespace Gift
{
    public class Waffle : Sweetness
    {
        public WaffleTaste WaffleTaste { get; set; }
        public bool IsGlaze;
        
        public Waffle(string name, double weight,double sugar,double price,bool isGlaze,WaffleTaste waffleTaste):base(name, weight, sugar, price)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            IsGlaze = isGlaze;
            WaffleTaste = waffleTaste;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Salad Item\n");
            stringBuilder.Append($"Name: {Name}\n Weight: {Weight}\n");
            stringBuilder.Append($"Caloric: {Sugar}\nPrice: {Price}\n");
            stringBuilder.Append($"Taste: {WaffleTaste}\n");
            string s = "no";
            if (IsGlaze == true) s = "yes"; //is glaze
            stringBuilder.Append($"\nGlaze: {s}");
        return stringBuilder.ToString();
        }
    }
}