using System;
using Gift.lib.Gift;


namespace Gift.Console
{
    using Gift = lib.Gift.Gift;
    class Program
    {
        static void Main(string[] args)
        {
            IGift gift = new Gift()
            {
                new Candy("Maksum",456,465,864,FilingType.NoFilling),
                new Gummy("Markus",900,800,700,MarmeladeTaste.Sour,Color.Green)
            };
        }
    }
}
