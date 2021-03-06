﻿using System.Text;

namespace Gift
{
    public class Waffle : Sweetness
    {
        public WaffleTaste WaffleTaste { get; set; }
        public bool IsGlaze { get; set; } //d

        public Waffle(string name, double weight, double sugarWeight, double price, bool isGlaze,
            WaffleTaste waffleTaste) : base(name, weight, sugarWeight, price)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            IsGlaze = isGlaze;
            WaffleTaste = waffleTaste;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\nWeight: {Weight}\n");
            stringBuilder.Append($"SugarWeight: {SugarWeight}\nPrice: {Price}\n");
            stringBuilder.Append($"Taste: {WaffleTaste}\n");
            string s = "no";
            if (IsGlaze == true) s = "yes"; //is glaze
            stringBuilder.Append($"Glaze: {s}");
            return stringBuilder.ToString();
        }
    }
}