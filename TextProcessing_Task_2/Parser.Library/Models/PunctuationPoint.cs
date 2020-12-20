namespace Parser.Library.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class PunctuationPoint : SentenceItem, IPunctuationPoint
    {
        private IList<Symbol> _symbols;
        
        public PunctuationPoint()
        {
        }
        public PunctuationPoint(string s)
        {
            foreach (char variable in s)
            {
                Symbol c = new Symbol(variable);
                _symbols.Add(c);
            }

            //get legth
            //гласная
        }
    }
}