namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class PunctuationPoint : SentenceItem, IPunctuationPoint
    {
        public PunctuationPoint() : base()
        {
        }
        public PunctuationPoint(string s) 
        {
            foreach (var variable in s)
            {
                Symbol symbol = new Symbol(variable);
                Symbols.Add(symbol);
            }
        }
    }
}