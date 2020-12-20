namespace Parser.Library.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Word : SentenceItem, IWord
    {
        public Word()
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

        public int Lenght
        {
            get
            {
                return Symbols.Count;
            }
        }
        //get legth
        //гласная
    }
}