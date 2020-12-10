using System;
using Gift.lib.Gift;


namespace Gift.Console
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Console = System.Console;
    using Gift = lib.Gift.Gift;
    class Program
    {
        static void Main(string[] args)
        {
            IGift gift = new Gift()
            {
                new Candy("Maksum",456,465,864,FilingType.NoFilling),
                new Candy("Maksum",456,465,864,FilingType.NoFilling),
                new Gummy("Markus",900,800,700,MarmeladeTaste.Sour,Color.Green),
                new Candy("Maksum",456,465,864,FilingType.NoFilling),
                new Waffle("Puprus",555,444,999,isGlaze:true,WaffleTaste.Lemon)
            }; 
            Console.WriteLine(gift);
            IEnumerable<Sweetness> s = gift.GetSorterSweetnessesBy(sweetness => sweetness.Weight);
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
            List<int> heavyCandeIndex = gift.GetHeavistCandyIndex();
            foreach (var item in heavyCandeIndex)
            {
                Console.WriteLine(item);
            }
        }
    }
}
