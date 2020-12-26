namespace Parser.Library.Models
{
    using System.Collections.Generic;

    public class Word : SentenceItem, IWord
    {
        public Word() : base()
        {
            Symbols = new List<Symbol>();
        }

        public Word(string s)
        {
            foreach (var variable in s)
            {
                Symbol symbol = new Symbol(variable);
                Symbols.Add(symbol);
            }
        }

        public int Lenght => Symbols.Count;
        //get legth
        //гласная
    }
}